
namespace CRUD_COLEGIO_APP_0609.Repository.IRepository
{
    public interface IAlumnoRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T> Create(T entity);

        Task<T>GetByID(int id);

        Task<T> Update(T entity);

        Task<bool> Delete (int id);

    }
}
