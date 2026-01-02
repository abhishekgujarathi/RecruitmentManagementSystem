using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RecruitmentManagementSystem.API.Services
{

    public interface IAuthService
    {
        Task<User?> RegisterAsync(RegisterRequestDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<TokenResponseDto?> LoginAsync(UserDto request)
        {
            // getting the user from table if there or default,
            // FirstOrDefaultAsync gets first record for the given id or column value
            // similar to select * from tabl where col=val;
            var user = await _context.Users
                .Include(u => u.UserType)
                .Include(u => u.EmployeeUserRoles)
                    .ThenInclude(eur => eur.EmployeeRole)
                .FirstOrDefaultAsync(u => u.Email == request.Email);


            // call user table to check if anyasync username present
            // return as no user found
            if (user is null)
            {
                return null;
            }

            // check user password match
            // return as incorrect password
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password)
                == PasswordVerificationResult.Failed)
            {
                return null;
            }

            // if reached here means user & pwd is valid 
            // update user lastLogin value to now.
            user.LastLogin = DateTime.UtcNow;
            TokenResponseDto response = await CreateResponseToken(user);

            // save user lastlogin into table
            await _context.SaveChangesAsync();

            return response;
        }


        public async Task<User?> RegisterAsync(RegisterRequestDto request)
        {
            // call user table to check if any user exists with the same email
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return null;
            }

            // requested role is invalid or admin?
            var userType = await _context.UserTypes.FirstOrDefaultAsync(ut => ut.TypeName == request.Role); // candidate or emploee

            if (userType is null)
                return null;

            if (userType.TypeName == "Admin")
                return null;

            // creating user object
            var user = new User()
            {
                Fname = request.Fname,
                Lname = request.Lname,
                Email = request.Email,
                UserTypeId = userType.UserTypeId,
                MobileNumber = request.MobileNumber,
                DOB = request.DOB,
                Gender = request.Gender,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, request.Password);

            // save that object to db
            _context.Users.Add(user);

            // commit the changes in db
            await _context.SaveChangesAsync();

            return user;
        }


        public async Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request)
        {

            var user = await ValidateRefreshTokensAsync(request.userId, request.RefreshToken);

            if (user is null)
                return null;

            return await CreateResponseToken(user);
        }

        public async Task<User?> ValidateRefreshTokensAsync(Guid userId, string refreshToken)
        {
            // not working to refresh roles in claims 
            // [now working]
            var user = await _context.Users
                .Include(u => u.UserType)
                .Include(u => u.EmployeeUserRoles)
                    .ThenInclude(eur => eur.EmployeeRole)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user is null
                || user.RefreshToken != refreshToken
                || user.RefreshTokenExpiryTime <= DateTime.UtcNow
                )
            {
                return null;
            }

            return user;
        }
        private async Task<TokenResponseDto> CreateResponseToken(User user)
        {
            return new TokenResponseDto()
            {
                AuthToken = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshTokenAsync(user)
            };


        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> GenerateAndSaveRefreshTokenAsync(User user)
        {
            var refToken = GenerateRefreshToken();
            user.RefreshToken = refToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(2);

            await _context.SaveChangesAsync();

            return refToken;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Fname),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.UserType.TypeName) //add candi/employee
            };

            //if the user is emplye then add its roles
            if (user.UserType.TypeName == "Employee")
            {
                foreach (var eur in user.EmployeeUserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, eur.EmployeeRole.RoleName)); // addingg rev/int/rec
                }
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }


    }
}
