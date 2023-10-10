using System.Data;

namespace WebAppCawa.Pages {
    public class Chamados {

        /* Utilizamos este arquivo para conseguir passar os dados do arquivo inserido para o sql. Criamos primeiros as variaveis de cada item do arquivo excel e logo após isso criamos um construtor salvando os dados do arquivo para serem passados no SQL. Então logo após essa função "chamados" ser passada, o arquivo DataBase, ja salva os dados coletados. */

        public string Numero { get; set; }
        public string Criado_Em { get; set; }
        public string Tipo_tarefa { get; set; }
        public string Descricao_resumida { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string Solicitante_incidentes { get; set; }
        public string Solicitante_item { get; set; }
        public string Solucionador { get; set; }
        public string Grupo_designado { get; set; }
        public string Termino_real { get; set; }
        public string Encerrado { get; set; }

        public Chamados() { }

        public Chamados(string numero, string criado_em, string tipo_tarefa, string descricao_resumida, string descricao, string estado, string solicitante_incidente ,string solicitante_item, string solucionador, string grupo_designado, string termino_real, string encerrado) {
            Numero = numero;
            Criado_Em = criado_em;
            Tipo_tarefa = tipo_tarefa;
            Descricao_resumida = descricao_resumida;
            Descricao = descricao;
            Estado = estado;
            Solicitante_incidentes = solicitante_incidente;
            Solicitante_item = solicitante_item;
            Solucionador = solucionador;
            Grupo_designado = grupo_designado;
            Termino_real = termino_real;
            Encerrado = encerrado;
        }

        public List<Chamados> GetChamados() {
            var listaChamados = new List<Chamados>();
            var dt = Excel.GetChamados();
            foreach (DataRow item in dt.Rows) {
                listaChamados.Add(new Chamados(item["Número"].ToString(), item["Criado em"].ToString(), item["Tipo de tarefa"].ToString(), item["Descrição resumida"].ToString(), item["Descrição"].ToString(), item["Estado"].ToString(), item["Solicitante (Incidentes)"].ToString(),item["Solicitante (Item solicitado)"].ToString(), item["Solucionador"].ToString(), item["Grupo designado"].ToString(), item["Término real"].ToString(), item["Encerrado"].ToString()));
            }

            return listaChamados;

        }

        public bool AdicionarChamado() {
            return DataBase.AdicionarChamado(this);
        }

    }
}
