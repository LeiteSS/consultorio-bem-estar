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
    public class ConsultasDao : IConsultasDao
    {
        public void Agendar(Consulta consulta)
        {
            string sql = @"INSERT INTO consultas_tb" +
            "(Descricao, Anexo, DtHora, Status, TransacaoID, " +
            "PacienteId) VALUES (?, ?, ?, ?, ?, ?)";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                OdbcTransaction transaction = conn.BeginTransaction();

                try
                {
                    OdbcCommand command = new OdbcCommand(sql, conn, transaction);

                    command.Parameters.AddWithValue("@Descricao", consulta.Descricao);
                    command.Parameters.AddWithValue("@Anexo", consulta.Anexo);
                    command.Parameters.AddWithValue("@DtHora", consulta.DtHora);
                    command.Parameters.AddWithValue("@Status", consulta.Status);
                    command.Parameters.AddWithValue("@TransacaoID", consulta.TransacaoID.ToString());
                    command.Parameters.AddWithValue("@PacienteId", consulta.PacienteId);

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

        public IList<Consulta> ObterPorPaciente(int pacienteId)
        {
            List<Consulta> consultas = new List<Consulta>();

            string sql = @"SELECT * FROM consultas_tb WHERE PacienteId = ?";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                OdbcCommand command = new OdbcCommand(sql, conn);

                command.Parameters.AddWithValue("@PacienteId", pacienteId);

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

        public async Task<Paciente> ObterPaciente()
        {
            string sql = @"SELECT Cpf, Nome, Sobrenome, DtNascimento, TelefoneFixo, " +
                "TelefoneCelular, Email FROM pacientes_tb JOIN consultas_tb ON pacientes_tb.Id = consultas_tb.PacienteId";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                OdbcCommand command = new OdbcCommand(sql, conn);

                conn.Open();

                OdbcDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.Cpf = result["Cpf"] as string;
                    paciente.Nome = result["Nome"] as string;
                    paciente.Sobrenome = result["Sobrenome"] as string;
                    paciente.DtNascimento = result["DtNascimento"] as string;
                    paciente.TelefoneFixo = result["TelefoneFixo"] as string;
                    paciente.TelefoneCelular = result["TelefoneCelular"] as string;
                    paciente.Email = result["Email"] as string;

                    return paciente;
                }
                return null;
            }
        }

 
    }
}
