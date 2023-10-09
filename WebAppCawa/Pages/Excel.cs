using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace WebAppCawa.Pages {
    public class Excel {

        public Excel() {

        }

        public static string fileName;

        public static DataTable GetChamados() {



            string diretorioAtual = Directory.GetCurrentDirectory();

            var arquivo = $@"{diretorioAtual}\wwwroot\{fileName}";
            var planilha = "SELECT * FROM [Page 1$]";

            var strCon = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + arquivo + "; Extended Properties=\"Excel 12.0; HDR=Yes; IMEX=0\"";

            var dt = new DataTable();

            using (OleDbConnection con = new OleDbConnection(strCon)) {
                using(OleDbDataAdapter da = new OleDbDataAdapter(planilha, con)) {
                    da.Fill(dt);
                }
            }

            return dt;
        
        }

    }
}
