using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroBot.Core.Users
{
    //A member of the server that has existed/interacted with the server
    public class User
    {
        //Username
        public string Username { get; set; }

        //Unique ID of a user
        public ulong UserId { get; set; }

        //Points gained from being in the server or allocated from server moderators
        public ulong UserPoints { get; set; }

        //Points gained from interacting with the server text channels
        public ulong ExperiencePoints { get; set; }

        //Level of the User
        public ulong UserLevel { get; set; }

        //Message XP gain timeout
        public DateTime XpTimeout { get; set; }
    }
}
