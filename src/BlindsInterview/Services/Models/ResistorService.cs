using BlindsInterview.Infrasturcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindsInterview.Services.Models {
    public interface IOhmValueCalculator {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }

    public class ResistorService : IOhmValueCalculator {
        private IResistorRepository _resistorRepo;

        public ResistorService(IResistorRepository resistorRepo) {
            _resistorRepo = resistorRepo;
        }

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor) {
            var colorOne = this.GetResistor(bandAColor);
            if (colorOne == null) {
                throw new System.ArgumentException("Parameter cannot be null", "bandAColor");
            }
            var colorTwo = this.GetResistor(bandBColor);
            if (colorTwo == null) {
                throw new System.ArgumentException("Parameter cannot be null", "bandBColor");
            }
            var multi = this.GetResistor(bandCColor);
            if (multi == null) {
                throw new System.ArgumentException("Parameter cannot be null", "multi");
            }
            var tol = this.GetResistor(bandDColor);
            if (tol == null) {
                throw new System.ArgumentException("Parameter cannot be null", "tol");
            }
            var averageValue = ((colorOne.SigFig * 10) + colorTwo.SigFig) * Math.Pow(10, multi.Multiplier);

            return (int)averageValue;
        }
        public ResistorDTO GetResistor(string resistorColor) {

            return (from r in _resistorRepo.GetResistor(resistorColor)
                    select new ResistorDTO {
                        Id = r.Id,
                        Color = r.Color,
                        SigFig = r.SigFig,
                        Multiplier = r.Multiplier,
                        Tolerance = r.Tolerance,
                        HexColor = r.HexColor
                    }).FirstOrDefault();
        }

        public List<ResistorDTO> GetAllResistors() {
            return (from r in _resistorRepo.GetAllResistors()
                    select new ResistorDTO {
                        Id = r.Id,
                        Color = r.Color,
                        SigFig = r.SigFig,
                        Multiplier = r.Multiplier,
                        Tolerance = r.Tolerance,
                        HexColor = r.HexColor
                    }).ToList();
        }
    }
}

