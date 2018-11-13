using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerServices.Model
{
    public class Tournament
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public string Game { get; set; }
        public List<User> PlayerList { get; set; }
    }
}
