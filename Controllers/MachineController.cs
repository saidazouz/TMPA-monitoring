using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPA_monitoring.Models;
using TMPA_monitoring.Models.Repositories;
using Renci.SshNet;
using System.Net.NetworkInformation;

namespace TMPA_monitoring.Controllers
{
    public class MachineController : Controller
    {
        private readonly IMachineRepositories<Machine> machineRepisotories;

        public MachineController(IMachineRepositories<Machine> machineRepisotories)
        {
            this.machineRepisotories = machineRepisotories;
        }
        // GET: MachineController
        public ActionResult Index()
        {
            var machines = machineRepisotories.List();
            foreach (var machine in machines)
            {
                machine.state = GetMachineState(machine);
            }
            return View(machines);
        }

        private MachineState GetMachineState(Machine machine)
        {
            MachineState state = MachineState.Down;
            var ping = new Ping();
            var reply = ping.Send(machine.IP, 10 * 1000); // 1 minute time out (in ms)
            if (reply.Status == IPStatus.Success)
            {
                state = MachineState.Up;
            }
            return state;
        }

        // GET: MachineController/Details/5
        public ActionResult Details(int id)
        {
            var machine = machineRepisotories.Find(id);
            return View(machine);
        }

        // GET: MachineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MachineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Machine  machine)
        {
            try
            {
                machineRepisotories.Add(machine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MachineController/Edit/5
        public ActionResult Edit(int id)
        {
            var machine = machineRepisotories.Find(id);
            return View(machine);
        }

        // POST: MachineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Machine newMachine)
        {
            try
            {
                machineRepisotories.Update(id, newMachine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MachineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MachineController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
