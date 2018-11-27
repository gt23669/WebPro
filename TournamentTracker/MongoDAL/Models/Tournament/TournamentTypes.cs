using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL.Models
{
    public enum TournamentTypes
    {
        SingleElimination,
        DoubleElimination,
        RoundRobin
    }

    public enum SecurityLevels
    {
        Open,
        FriendsOnly,
        InviteOnly
    }

    public enum Status
    {
        Open,
        InProgress,
        Full,
        Ended
    }
}
