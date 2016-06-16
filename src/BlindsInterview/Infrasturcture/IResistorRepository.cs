using System.Linq;
using BlindsInterview.Models;

namespace BlindsInterview.Infrasturcture {
    public interface IResistorRepository {
        IQueryable<Resistor> GetResistor(string color);
        IQueryable<Resistor> GetAllResistors();
    }

}