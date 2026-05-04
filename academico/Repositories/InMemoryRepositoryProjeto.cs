using academico.Models;

namespace academico.Repositories
{
    public class InMemoryRepositoryProjeto : IProjetoRepository
    {
        private readonly List<Projeto> _projetos = new List<Projeto>();
        private int _nextId = 1;
        private readonly object _lock = new object();

        public InMemoryRepositoryProjeto()
        {
            _projetos.Add(new Projeto
            {
                Nome = "Projeto Teste",
                Sigla = "MF",
                Ano = "2026",


            });
        }


        public Task Create(Projeto projeto, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                projeto.ProjetoId = _nextId++;
                _projetos.Add(projeto);
            }
            return Task.CompletedTask;
        }

        public Task Delete(int id, CancellationToken cancelationToken = default)
        {
            lock (_lock)
            {
                var existing = _projetos.FirstOrDefault(a => a.ProjetoId == id);
                if (existing != null)
                {
                    _projetos.Remove(existing);
                }
                return Task.CompletedTask;
            }
        }

        public Task Edit(Projeto projeto, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                var existing = _projetos.FirstOrDefault(a => a.ProjetoId == projeto.ProjetoId);
                if (existing != null)
                {
                    existing.Nome = projeto.Nome;

                }
            }
            return Task.CompletedTask;
        }

        public Task<bool> Exists(int id, CancellationToken cancelationToken = default)
        {
            bool exists;
            lock (_lock)
            {
                exists = _projetos.Any(a => a.ProjetoId.Equals(id));
            }
            return Task.FromResult(exists);
        }

        public Task<IEnumerable<Projeto>> GetAll(CancellationToken cancelationToken = default)
        {
            IEnumerable<Projeto> result;
            lock (_lock)
            {
                result = _projetos.Select(a => a).ToList();
            }
            return Task.FromResult(result);
        }

        public Task<Projeto> GetId(int Id, CancellationToken cancelationToken = default)
        {
            Projeto? projeto;
            lock (_lock)
            {
                projeto = _projetos.FirstOrDefault(a => a.ProjetoId == Id);
            }
            return Task.FromResult(projeto);
        }
    }
}
