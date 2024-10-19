using CRUD_COLEGIO_APP_0609.Context;
using CRUD_COLEGIO_APP_0609.Models;
using CRUD_COLEGIO_APP_0609.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CRUD_COLEGIO_APP_0609.Repository
{
    public class CursoRepository : ICursoRepository<Curso>
    {

        private readonly ColegioPgContext _dbcontext;
        private readonly DbSet<Curso> _dbSet;

        public CursoRepository(ColegioPgContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = dbcontext.Set<Curso>();
        }

        public async Task<List<Curso>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
