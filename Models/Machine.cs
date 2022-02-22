using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMPA_monitoring.Models
{
    public class Machine
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string IP { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public MachineState state { get; set; }

        public Boolean Check { get; set; }

        public string Role { get; set; }



        public Machine()
        {

        }

        public Machine(long id, string name, string iP, string username, string password, Boolean check,string role)
        {
            Id = id;
            Name = name;
            IP = iP;
            Username = username;
            Password = password;
            state = MachineState.Down;
            Check = check;
            Role = role;
        }

    }
}
