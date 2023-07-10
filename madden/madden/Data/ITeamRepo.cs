using System.Collections.Generic;
using madden.Models;

namespace madden.Data
{
	public interface ITeamRepo
	{
		bool SaveChanges();
		IEnumerable<Team> GetAllTeams();
	}
}