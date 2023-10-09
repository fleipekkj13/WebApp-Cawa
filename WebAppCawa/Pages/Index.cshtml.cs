using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAppCawa.Data;

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
        public IActionResult OnPost() {
            ExcelBancoD();
            return RedirectToPage("Index");
        }
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