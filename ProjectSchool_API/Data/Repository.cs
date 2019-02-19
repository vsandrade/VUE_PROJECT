using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query
                    .Include(pe => pe.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(p => p.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(aluno => aluno.Id)
                        .Where(aluno => aluno.Id == AlunoId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(p => p.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(aluno => aluno.Id)
                        .Where(aluno => aluno.ProfessorId == ProfessorId);

            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetAllProfessoresAsync(bool includeAlunos = true)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(c => c.Alunos);
            }

            query = query.AsNoTracking()
                        .OrderBy(professor => professor.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAlunos = true)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query
                    .Include(pe => pe.Alunos);
            }

            query = query.AsNoTracking()
                        .OrderBy(aluno => aluno.Id)
                        .Where(aluno => aluno.Id == ProfessorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}