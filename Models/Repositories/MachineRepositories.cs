using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace TMPA_monitoring.Models.Repositories
{
    public class MachineRepositories : IMachineRepositories<Machine>
    {
        List<Machine> machines;
        public MachineRepositories()
        {
            machines = new List<Machine>();

               /*{
                   new Machine(1,"Fret Test","192.168.7.165","ufret","YrEc@6353"),
                   new Machine(2,"Test01","192.168.7.0","ufret","YrEc@6353"),
                   new Machine(3,"Test02","192.168.7.1","ufret","YrEc@6353")
               }*/
        }
        public void Add(Machine machine)
        {
            machines.Add(machine);
        }

        public void Delete(long id)
        {
            var machine = Find(id);
            machines.Remove(machine);
        }

        public Machine Find(long id)
        {
            var machine = machines.SingleOrDefault(a => a.Id == id);
            return machine;
        }

        public IList<Machine> List()
        {
            return machines;
        }

        public void Update(long id ,Machine newMachine)
        {
            var machine = Find(id);
            machine.Name = newMachine.Name;
            machine.IP = newMachine.IP;
            machine.Username = newMachine.Username;
            machine.Password = newMachine.Password;
            machine.state = newMachine.state;
        }
    }
}
