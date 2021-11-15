using pim.api.Models.Medico;
using pim.api.Models.Paciente;

namespace pim.api.Configurations
{
    public interface IAuthenticationServiceCustom
    {
        string PacienteToken(PacienteViewModelOutput pacienteViewModelOutput);

        string MedicoToken(MedicoViewModelOutput medicoViewModelOutput);
    }
}
