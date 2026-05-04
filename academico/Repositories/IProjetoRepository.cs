using academico.Models;

namespace academico.Repositories
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> GetAll(CancellationToken cancelationToken = default);
        Task<Projeto> GetId(int Id, CancellationToken cancelationToken = default);
        Task Create(Projeto projeto, CancellationToken cancellationToken = default);
        Task Edit(Projeto projeto, CancellationToken cancellationToken = default);
        Task Delete(int id, CancellationToken cancelationToken = default);
        Task<bool> Exists(int id, CancellationToken cancelationToken = default);
    }
}
