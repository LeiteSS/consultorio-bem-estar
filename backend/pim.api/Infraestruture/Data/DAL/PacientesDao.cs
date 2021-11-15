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
    public class PacientesDao : IPacientesDao
    {
        public void Adicionar(Paciente paciente)
        {
            string sql = @"INSERT INTO pacientes_tb" +
            "(Nome, Sobrenome, DtNascimento, TelefoneFixo, TelefoneCelular, " +
            "Cpf, Senha, Email) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                OdbcTransaction transaction = conn.BeginTransaction();

                try
                {
                    OdbcCommand command = new OdbcCommand(sql, conn, transaction);

                    command.Parameters.AddWithValue("@Nome", paciente.Nome);
                    command.Parameters.AddWithValue("@sobrenome", paciente.Sobrenome);
                    command.Parameters.AddWithValue("@DtNascimento", paciente.DtNascimento);
                    command.Parameters.AddWithValue("@TelefoneFixo", paciente.TelefoneFixo);
                    command.Parameters.AddWithValue("@TelefoneCelular", paciente.TelefoneCelular);
                    command.Parameters.AddWithValue("@Cpf", paciente.Cpf);
                    command.Parameters.AddWithValue("@Senha", paciente.Senha);
                    command.Parameters.AddWithValue("@Email", paciente.Email);

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

        public async Task<Paciente> ObterPaciente(string cpf)
        {
            string sql = @"SELECT Id, Nome, Sobrenome, DtNascimento, TelefoneFixo, " +
                "TelefoneCelular, Email FROM pacientes_tb WHERE Cpf = ?";

            using (OdbcConnection conn = DbConnectionFactory.CreateConnection())
            {
                OdbcCommand command = new OdbcCommand(sql, conn);

                command.Parameters.AddWithValue("@Cpf", cpf);

                conn.Open();

                OdbcDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.Id = Convert.ToInt32(result["Id"]);
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
