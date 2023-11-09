using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Campagne> Campagnes { get; }
		IGenericRepository<Genre> Genres { get; }
		IGenericRepository<JdrUser> Joueurs { get; }
		IGenericRepository<Oneshot> Oneshots { get; }
		IGenericRepository<Seance> Seances { get; }	
		IGenericRepository<Partie> Parties { get; }
		Task<int> CompleteAsync();
	}
}
