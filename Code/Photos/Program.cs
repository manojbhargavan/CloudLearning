using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace Photos
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(option =>
                {
                    option.UseStartup<Startup>();
                })
                .Build()
                .Run();
        }
    }

}
