using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.Models;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;


namespace RecruitmentManagementSystem.API.Services
{
    public interface IVerificationService
    {
        Task UploadDocumentAsync(Guid verificationId, Guid candidateUserId, UploadVerificationDocumentDto dto);

        Task RequestDocumentsAsync(Guid verificationId, List<string> documentTypes);

        Task VerifyDocumentAsync(Guid documentId, Guid hrId, VerifyDocumentDto dto);

        Task<VerificationResponseDto> GetVerificationAsync(Guid verificationId);
    }

    public class VerificationService : IVerificationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;
        public VerificationService(AppDbContext context, IMapper mapper, IFileUploadService fileUploadService)
        {
            _context = context;
            _mapper = mapper;
            _fileUploadService = fileUploadService;

        }
        public async Task UploadDocumentAsync(Guid verificationId, Guid candidateUserId, UploadVerificationDocumentDto dto)
        {
            var verification = await _context.CandidateVerifications
                .Include(v => v.Documents)
                .FirstOrDefaultAsync(v => v.CandidateVerificationId == verificationId);

            if (verification == null)
                throw new Exception("Verification not found");

            if (verification.Documents.Any(d => d.DocumentType == dto.DocumentType))
                throw new Exception("Document already uploaded");

            var fileUrl = await _fileUploadService.SaveAsync(dto.File);

            verification.Documents.Add(new VerificationDocument
            {
                VerificationDocumentId = Guid.NewGuid(),
                CandidateVerificationId = verificationId,
                DocumentType = dto.DocumentType,
                FileUrl = fileUrl,
                Status = VerificationStatus.Pending
            });

            await _context.SaveChangesAsync();
        }
        public async Task RequestDocumentsAsync(
            Guid verificationId,
            List<string> documentTypes)
        {
            var verification = await _context.CandidateVerifications
                .Include(v => v.Documents)
                .FirstOrDefaultAsync(v => v.CandidateVerificationId == verificationId);

            if (verification == null)
                throw new Exception("Verification not found");

            foreach (var type in documentTypes)
            {
                if (!verification.Documents.Any(d => d.DocumentType == type))
                {
                    verification.Documents.Add(new VerificationDocument
                    {
                        VerificationDocumentId = Guid.NewGuid(),
                        CandidateVerificationId = verificationId,
                        DocumentType = type,
                        Status = VerificationStatus.Pending
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task VerifyDocumentAsync(Guid documentId,Guid hrId,VerifyDocumentDto dto)
        {
            var document = await _context.VerificationDocuments
                .FirstOrDefaultAsync(d => d.VerificationDocumentId == documentId);

            if (document == null)
                throw new Exception("Document not found");

            document.Status = dto.Status;
            document.Remarks = dto.Remarks;
            document.VerifiedBy = hrId;
            document.VerifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task<VerificationResponseDto> GetVerificationAsync(Guid verificationId)
        {
            var verification = await _context.CandidateVerifications
                .Include(v => v.Documents)
                .FirstOrDefaultAsync(v => v.CandidateVerificationId == verificationId);

            if (verification == null)
                throw new Exception("Verification not found");

            // overall status logic
            var overallStatus =
                verification.Documents.All(d => d.Status == VerificationStatus.Approved)
                    ? VerificationStatus.Approved
                    : verification.Documents.Any(d => d.Status == VerificationStatus.Rejected)
                        ? VerificationStatus.Rejected
                        : VerificationStatus.Pending;

            return new VerificationResponseDto
            {
                VerificationId = verification.CandidateVerificationId,
                OverallStatus = overallStatus,
                Documents = verification.Documents.Select(d => new VerificationDocumentResponseDto
                {
                    DocumentId = d.VerificationDocumentId,
                    DocumentType = d.DocumentType,
                    Status = d.Status,
                    Remarks = d.Remarks,
                    FileUrl = d.FileUrl
                }).ToList()
            };
        }

    }
}
