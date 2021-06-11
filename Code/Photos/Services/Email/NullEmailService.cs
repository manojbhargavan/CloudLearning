using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Photos.Services.Email
{
    //This is just a conceptual example you would really need everything in below case for building the object
    public class NullEmailService : IEmailService
    {
        private readonly ILogger<NullEmailService> logger;

        public string Body { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Subject { get; set; }

        public NullEmailService(ILogger<NullEmailService> logger)
        {
            this.logger = logger;
        }

        public IEmailService AddBody(string value)
        {
            Body = value;
            return this;
        }

        public IEmailService AddFromAddress(string value)
        {
            FromAddress = value;
            return this;
        }

        public IEmailService AddSubject(string value)
        {
            Subject = value;
            return this;
        }

        public IEmailService AddToAddress(string value)
        {
            ToAddress = value;
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void SendMail()
        {
            logger.LogInformation($"Mail sent to : {this.ToString()}");
        }
    }
}