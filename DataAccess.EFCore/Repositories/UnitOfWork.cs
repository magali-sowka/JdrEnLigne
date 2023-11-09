using DataAccess.EFCore.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JdrContext _context;
        public IGenericRepository<Campagne> Campagnes { get; private set; }
        public IGenericRepository<Genre> Genres { get; private set; }
        public IGenericRepository<JdrUser> Joueurs { get; private set; }
        public IGenericRepository<Oneshot> Oneshots { get; private set; }
        public IGenericRepository<Seance> Seances { get; private set; }
        public IGenericRepository<Partie> Parties { get; private set; }

        public UnitOfWork(JdrContext context)
        {
            _context = context;
            Campagnes = new GenericRepository<Campagne>(_context);
            Genres = new GenericRepository<Genre>(_context);
            Joueurs = new GenericRepository<JdrUser>(_context);
            Oneshots = new GenericRepository<Oneshot>(_context);
            Seances = new GenericRepository<Seance>(_context);
            Parties = new GenericRepository<Partie>(_context);
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
	}
}
