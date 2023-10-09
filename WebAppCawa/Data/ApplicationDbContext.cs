using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppCawa.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        /*
        Data Source=;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False 

         * */

        private static string server = @"(localdb)\ProjectModels";
        private static string dataBase = "MonitoramentoDiario";

        public static string StrCon {
            get { return $"Data Source = {server};Initial Catalog = {dataBase}; Integrated Security = True; Connect Timeout = 30; Encrypt=False;"; }
        }
    }
}