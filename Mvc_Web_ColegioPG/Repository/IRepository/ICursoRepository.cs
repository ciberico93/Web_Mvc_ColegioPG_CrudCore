namespace CRUD_COLEGIO_APP_0609.Repository.IRepository
{
    public interface ICursoRepository<T>
    {
        Task<List<T>> GetAll();

    }
}
