using CRUD_COLEGIO_APP_0609.Context;
using CRUD_COLEGIO_APP_0609.Models;
using CRUD_COLEGIO_APP_0609.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CRUD_COLEGIO_APP_0609.Repository
{
    public class AlumnoRepository : IAlumnoRepository<Alumno>

    {
        private readonly ColegioPgContext _dbcontext;
        private readonly DbSet<Alumno> _dbSet;

        public AlumnoRepository(ColegioPgContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = dbcontext.Set<Alumno>();
            
        }

        public async Task<Alumno> Create(Alumno entity)
        {
            Alumno alumno = new Alumno()
            {
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Direccion = entity.Direccion,
                Telefono = entity.Telefono,
                Correo = entity.Correo,
                IdCursos = entity.IdCursos
            };

            EntityEntry<Alumno> result = await _dbcontext.Alumnos.AddAsync(alumno);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
            

            
        }

        public async Task<bool> Delete(int id)
        {
            var alumno = await GetByID(id);
            if (alumno != null)
            {
                return false;
            }

            _dbcontext.Remove(alumno);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Alumno>> GetAll()
        {
            return await _dbSet.Include(c => c.IdCursosNavigation).ToListAsync();
        }

        public async Task<Alumno> GetByID(int id)
        {
            return await _dbSet.FirstAsync(x => x.Id == id);
        }

        public async Task<Alumno> Update(Alumno entity)
        {
            var alumno = await GetByID(entity.Id);
            if (alumno == null) 
            {
                return null;
            }

            alumno.Nombre = entity.Nombre;
            alumno.Apellido = entity.Apellido;
            alumno.Telefono = entity.Telefono;
            alumno.Correo = entity.Correo;
            alumno.Direccion  = entity.Direccion;
            alumno.IdCursos = entity.IdCursos;

            await _dbcontext.SaveChangesAsync();
            return alumno;
        }
    }
}
