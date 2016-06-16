using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindsInterview.Services.Models {
    public class ResistorDTO {
        public int Id { get; set; }
        public string Color { get; set; }
        public int SigFig { get; set; }
        public int Multiplier { get; set; }
        public double Tolerance { get; set; }
        public string HexColor { get; set; }
    }
}
