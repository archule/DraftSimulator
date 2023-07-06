using System.Collections.Generic;
using madden.Models;

namespace madden.Data
{
	public interface IPlayerRepo
	{
		bool SaveChanges();
		IEnumerable<Player> GetAllPlayers();
		Player GetPlayerById(int id);
	}
}