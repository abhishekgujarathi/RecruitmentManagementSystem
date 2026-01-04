using RecruitmentManagementSystem.API.DTOS.Response;

namespace RecruitmentManagementSystem.API.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadPdfAsync(Guid userID, IFormFile file);
        (byte[] FileBytes, string FileName)? DownloadPdf(Guid userId);
        Task<CvResponseDto> GetPdfAsync(Guid userID);
    }
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        public async Task<string> UploadPdfAsync(Guid userID, IFormFile file)
        {
            // checkif file passed
            if (file == null || file.Length == 0)
                throw new ArgumentException("no file uploaded");

            // check file type
            if (Path.GetExtension(file.FileName).ToLower() != ".pdf")
                throw new ArgumentException("file uploaded not pdf");

            // checking if file is in threshold size ex=5mb
            if (file.Length > 5 * 1024 * 1024)
                throw new ArgumentException("file size more than 5mb");

            var uploadFolder = Path.Combine(_environment.ContentRootPath, "Uploads");
            Directory.CreateDirectory(uploadFolder);


            // creating file name and path
            var fileName = $"{userID}.pdf";
            var filePath = Path.Combine(uploadFolder, fileName);

            // writing to stream
            using var stream = new FileStream(filePath, FileMode.Create);

            // to disc
            await file.CopyToAsync(stream);

            return fileName;
        }

        public Task<CvResponseDto> GetPdfAsync(Guid userID)
        {
            var uploadFolder = Path.Combine(_environment.ContentRootPath, "Uploads");
            var filePath = Path.Combine(uploadFolder, $"{userID}.pdf");

            if (!File.Exists(filePath))
                return Task.FromResult<CvResponseDto>(null);


            var fileInfo = new FileInfo(filePath);

            var response = new CvResponseDto
            {
                FileName = fileInfo.Name,
                FileSize = fileInfo.Length / 1024,
                UploadedAt = fileInfo.CreationTimeUtc,
            };

            return Task.FromResult(response);
        }

        public (byte[] FileBytes, string FileName)? DownloadPdf(Guid userId)
        {
            var uploadFolder = Path.Combine(_environment.ContentRootPath, "Uploads");
            var filePath = Path.Combine(uploadFolder, $"{userId}.pdf");

            if (!File.Exists(filePath))
                return null;

            var fileBytes = File.ReadAllBytes(filePath);



            return (fileBytes,"cv.pdf");
        }
    }
}
