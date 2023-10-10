using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAppCawa.Pages {
    public class DataBase {


        /* Dentro deste arquivo é tratado toda a parte do SQL, deste a conexão até os comandos como pode ser ver na variavel: "var sql".
         */

        public static bool AdicionarChamado(Chamados chamados) {
            try {
                using (SqlConnection cn = new SqlConnection(Data.ApplicationDbContext.StrCon)) {
                    cn.Open();

                    var sql = "INSERT INTO T_REL_EXTRACAO_CHAMADOS (Numero, Criado_Em, Tipo_Tarefa, Descricao_Resumida, Descricao, Estado, Solicitante_Incidentes, Solicitante_Item, Solucionador, Grupo_Designado,  Termino_Real, Encerrado) " +
                        "VALUES (@Numero, @Criado_em, @Tipo_tarefa, @Descricao_Resumida, @Descricao, @Estado, @Solicitante_Incidentes, @Solicitante_item, @Solucionador, @Grupo_designado, @Termino_real, @Encerrado)";

                    using (SqlCommand cmd = new SqlCommand(sql, cn)) {
                        cmd.Parameters.AddWithValue("@Numero", chamados.Numero);
                        cmd.Parameters.AddWithValue("@Criado_Em", chamados.Criado_Em);
                        cmd.Parameters.AddWithValue("@Tipo_Tarefa", chamados.Tipo_tarefa);
                        cmd.Parameters.AddWithValue("@Descricao_Resumida", chamados.Descricao_resumida);
                        cmd.Parameters.AddWithValue("@Descricao", chamados.Descricao);
                        cmd.Parameters.AddWithValue("@Estado", chamados.Estado);
                        cmd.Parameters.AddWithValue("@Solicitante_Incidentes", chamados.Solicitante_incidentes);
                        cmd.Parameters.AddWithValue("@Solicitante_Item", chamados.Solicitante_item);
                        cmd.Parameters.AddWithValue("@Solucionador", chamados.Solucionador);
                        cmd.Parameters.AddWithValue("@Grupo_Designado", chamados.Grupo_designado);
                        cmd.Parameters.AddWithValue("@Termino_Real", chamados.Termino_real);
                        cmd.Parameters.AddWithValue("@Encerrado", chamados.Encerrado);
                        cmd.ExecuteNonQuery();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Registros excluídos: {rowsAffected}");

                    }
                }
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }


    }
}
