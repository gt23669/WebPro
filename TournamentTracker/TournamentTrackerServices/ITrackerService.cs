using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerServices.Model;

namespace TournamentTrackerServices
{
    public interface ITrackerService
    {
        TournamentListModel GetListOfTournaments();
        Tournament GetTournamentByName(string name);
        UserListModel GetAllUsers();
        UserListModel GetTournamentUsers();
    }
}
