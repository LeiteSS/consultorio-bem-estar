using pim.api.Business.DAL;
using pim.api.Business.Entities;
using pim.api.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Infraestruture.Data.DAL
{
    public class MedicosDao : IMedicosDao
    {
        public void Adicionar(Medico medico)
        {
            string sql = @"INSERT INTO medicos_tb" +
            "(Nome, Sobrenome, DtNascimento, TelefoneFixo, TelefoneCelular, " +
            "Especialidade, Crm, Senha, Email) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                OdbcTransaction transaction = conn.BeginTransaction();

                try
                {
                    OdbcCommand command = new OdbcCommand(sql, conn, transaction);

                    command.Parameters.AddWithValue("@Nome", medico.Nome);
                    command.Parameters.AddWithValue("@sobrenome", medico.Sobrenome);
                    command.Parameters.AddWithValue("@DtNascimento", medico.DtNascimento);
                    command.Parameters.AddWithValue("@TelefoneFixo", medico.TelefoneFixo);
                    command.Parameters.AddWithValue("@TelefoneCelular", medico.TelefoneCelular);
                    command.Parameters.AddWithValue("@Especialidade", medico.Especialidade);
                    command.Parameters.AddWithValue("@Crm", medico.Crm);
                    command.Parameters.AddWithValue("@Senha", medico.Senha);
                    command.Parameters.AddWithValue("@Email", medico.Email);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<Medico> ObterMedico(string crm)
        {
            string sql = @"SELECT Id, Nome, Sobrenome, DtNascimento, TelefoneFixo, " +
                "TelefoneCelular, Especialidade, Email  FROM medicos_tb WHERE Crm = ?";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                OdbcCommand command = new OdbcCommand(sql, conn);

                command.Parameters.AddWithValue("@Crm", crm);

                conn.Open();

                OdbcDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    Medico medico = new Medico();

                    medico.Id = Convert.ToInt32(result["Id"]);
                    medico.Nome = result["Nome"] as string;
                    medico.Sobrenome = result["Sobrenome"] as string;
                    medico.DtNascimento = result["DtNascimento"] as string;
                    medico.TelefoneFixo = result["TelefoneFixo"] as string;
                    medico.TelefoneCelular = result["TelefoneCelular"] as string;
                    medico.Especialidade = result["Especialidade"] as string;
                    medico.Email = result["Email"] as string;

                    return medico;
                }
                return null;
            }
        }

        public void Remarcar(int id, Consulta consulta)
        {
            string sql = @"UPDATE consultas_tb SET " +
                "Descricao = '" + consulta.Descricao + "', " +
                "Anexo = '" + consulta.Anexo + "', " +
                "DtHora = '" + consulta.DtHora + "', " +
                "Status = '" + consulta.Status + "', " +
                "TransacaoID = '" + consulta.TransacaoID.ToString() + "' WHERE Id = ?";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                OdbcTransaction transaction = conn.BeginTransaction();

                try
                {
                    OdbcCommand command = new OdbcCommand(sql, conn, transaction);

                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Finalizar(int id, Consulta consulta)
        {
            string sql = @"UPDATE consultas_tb SET " +
                "Descricao = '" + consulta.Descricao + "', " +
                "Anexo = '" + consulta.Anexo + "', " +
                "DtHora = '" + consulta.DtHora + "', " +
                "Status = '" + consulta.Status + "', " +
                "TransacaoID = '" + consulta.TransacaoID.ToString() + "' WHERE Id = ?";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                OdbcTransaction transaction = conn.BeginTransaction();

                try
                {
                    OdbcCommand command = new OdbcCommand(sql, conn, transaction);

                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public IList<Consulta> ObterConsultas()
        {
            List<Consulta> consultas = new List<Consulta>();

            string sql = @"SELECT * FROM consultas_tb";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                OdbcCommand command = new OdbcCommand(sql, conn);

                conn.Open();

                OdbcDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    Consulta consulta = new Consulta();

                    consulta.Descricao = result["Descricao"] as string;
                    consulta.Anexo = result["Anexo"] as string;
                    consulta.DtHora = result["DtHora"] as string;
                    consulta.Status = result["Status"] as string;
                    consulta.TransacaoID = Guid.Parse(result["TransacaoID"] as string);

                    consultas.Add(consulta);
                }
                return consultas;
            }
        }
    }
}
