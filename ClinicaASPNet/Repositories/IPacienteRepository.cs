using ClinicaASPNet.Models;

namespace ClinicaASPNet.Repositories
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente> Listar(string? nome = null);
        Paciente? BuscarPorId(int id);
        bool CpfJaCadastrado(string cpf, int? ignorarId = null);
        Paciente Adicionar(Paciente paciente);
        bool Atualizar(Paciente paciente);
        bool Excluir(int id);


    }
}
