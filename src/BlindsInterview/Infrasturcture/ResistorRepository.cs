using BlindsInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindsInterview.Infrasturcture {
    public class ResistorRepository : IResistorRepository {
        private ApplicationDbContext _db;

        public ResistorRepository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<Resistor> GetResistor(string color) {

            return from r in _db.Resistors
                   where r.Color == color
                   select r;
        }

        public IQueryable<Resistor> GetAllResistors() {
            return from g in _db.Resistors
                   select g;
        }
    }
}
