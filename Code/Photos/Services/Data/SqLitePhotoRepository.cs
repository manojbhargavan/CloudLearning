using Microsoft.Extensions.Logging;

namespace Photos.Services.Data
{
    public class SqLitePhotoRepository : IPhotoRepository
    {
        private readonly ILogger<SqLitePhotoRepository> logger;

        public SqLitePhotoRepository(ILogger<SqLitePhotoRepository> logger)
        {
            this.logger = logger;

        }
        void IPhotoRepository.PrintRepoType()
        {
            logger.LogInformation("This is the SQLite Repository");
        }
    }
}