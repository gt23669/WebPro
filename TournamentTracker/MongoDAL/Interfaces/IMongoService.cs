using MongoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL.Interfaces
{
    interface IMongoService
    {
        void CreateTournament(TournamentModel tournament);
        void DeleteTournamentById(int tournamentId);
        void ModifyTournamentById(int tournamentId, TournamentModel changeTo);

        TournamentListModel GetAllActiveTournaments();
        TournamentListModel GetAllInactiveTournaments();
        TournamentListModel GetTournamentsByOwnerEmail(string ownerEmail);
        TournamentTypes GetTournamentById(int tournamentId);
    }
}
