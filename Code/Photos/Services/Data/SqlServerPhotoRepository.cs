using Microsoft.Extensions.Logging;

namespace Photos.Services.Data
{
    public class SqlServerPhotoRepository : IPhotoRepository
    {
        private readonly ILogger<SqlServerPhotoRepository> logger;

        public SqlServerPhotoRepository(ILogger<SqlServerPhotoRepository> logger)
        {
            this.logger = logger;

        }
        void IPhotoRepository.PrintRepoType()
        {
            logger.LogInformation("This is the SQL Server Repository");
        }
    }
}