using ClinicaASPNet.Models;
using System.Runtime.CompilerServices;

namespace ClinicaASPNet.Repositories
{
    public class PacienteRepositoryMemoria : IPacienteRepository
    {

        private readonly List<Paciente> _pacientes = [
       new Paciente
        {
            Id = 1,
            Nome = "João das Neves",
            Cpf = "01254874521",
            Telefone = "(24)99999-9652",
            DataNascimento = new DateTime(2010, 05, 05)

    }, new Paciente{
            Id = 2,
            Nome = "Maria das Candongas ",
            Cpf = "25896563214",
            Telefone = "(24)98754-6658",
            DataNascimento = new DateTime(2010, 05, 05)

    },

    ];


        private int _proximoId = 3;
        public Paciente Adicionar(Paciente paciente)
        {
            paciente.Id = _proximoId++;
            _pacientes.Add(paciente);
            return paciente;
        }

        public bool Atualizar(Paciente paciente)
        {
            var existente = BuscarPorId(paciente.Id);
            if (existente is null) return false;
            existente.Nome = paciente.Nome;
            existente.Cpf = paciente.Cpf;
            existente.Telefone = paciente.Telefone;
            existente.DataNascimento = paciente.DataNascimento;
            return true;
        }

        public Paciente? BuscarPorId(int id)
        {
                 return _pacientes.FirstOrDefault(x => x.Id == id);  
           
        }

        public bool CpfJaCadastrado(string cpf, int? ignorarId = null)
        {
            return _pacientes.Any(x => x.Cpf == cpf && x.Id != ignorarId);
        }

        public bool Excluir(int id)
        {
            var paciente = BuscarPorId(id);
            if (paciente is null) return false;
            _pacientes.Remove(paciente);
            return true;
        }

        public IEnumerable<Paciente> Listar(string? nome = null)
        {
            IEnumerable<Paciente> consulta = _pacientes;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                consulta = consulta.Where(p => p.Nome.Contains(nome,
                    StringComparison.OrdinalIgnoreCase));
            }
            return consulta.OrderBy(p => p.Nome);

        }
    }
}
