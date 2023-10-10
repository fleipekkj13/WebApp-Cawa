using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAppCawa.Data;

/*Esta é a pagina main do site. Todas as funções passadas no site são enviadas para este arquivo. 
 * Após isso nós chamamos outras funções para realizar as tarefas desejadas. 
 * 
 * Aqui é aonde o back-end da página se comunica.
 */

namespace WebAppCawa.Pages {
    public class IndexModel : PageModel {
        public string fileName { get; private set; }
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public void OnGet() {

        }

        public void ExcelBancoD() {
            var chamado = new Chamados();
            var listaChamados = chamado.GetChamados();

            foreach (var chamadoItem in listaChamados) {
                chamado = chamadoItem;
                if (!chamado.AdicionarChamado()) {
                }
            }
        }

        /* 
         
        Construtor para salvar o arquivo enviado. Quando o cliente inserir o arquivo, este construtor é chamado para poder salvar o arquivo na pasta "wwwroot".
         
         */
        public IActionResult OnPost(IFormFile file) {
            try {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create)) {
                    file.CopyTo(stream);
                }
                Excel.fileName = file.FileName;
                ExcelBancoD();
                return RedirectToAction("Privacy");
            }
            catch (Exception e) {
                return RedirectToAction("Error!" + e);
            }
        }


    }
}