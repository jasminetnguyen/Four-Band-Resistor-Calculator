using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlindsInterview.Models {
    public class SampleData {
   
        

        public async static Task Initilizer(IServiceProvider serviceProvider) {
            var _db = serviceProvider.GetService<ApplicationDbContext>();
            var resistorDbContext = _db.Resistors;
            _db.Database.EnsureCreated();

            var Resistors = new List<Resistor>() {
                new Resistor() {
                    Color = "Black",
                    SigFig = 0,
                    Multiplier = 0,
                    Tolerance = 0,
                    HexColor = "#000000"
                },
                new Resistor () {
                    Color = "Brown",
                    SigFig = 1,
                    Multiplier = 1,
                    Tolerance = .01,
                    HexColor = "#795548"
                },
                new Resistor() {
                    Color = "Red",
                    SigFig = 2,
                    Multiplier = 2,
                    Tolerance = .02,
                    HexColor = "#F44336"
                },
                new Resistor() {
                    Color = "Orange",
                    SigFig = 3,
                    Multiplier = 3,
                    Tolerance = 0,
                    HexColor = "#FF9800"
                },
                new Resistor() {
                    Color = "Yellow",
                    SigFig = 4,
                    Multiplier = 4,
                    Tolerance = .05,
                    HexColor = "#FFEB3B"
                },
                new Resistor() {
                    Color ="Green",
                    SigFig = 5,
                    Multiplier = 5,
                    Tolerance = 0.005,
                    HexColor = "#4CAF50"
                },
                new Resistor() {
                    Color = "Blue",
                    SigFig = 6,
                    Multiplier = 6,
                    Tolerance = 0.0025,
                    HexColor = "#2196F3"
                },
                new Resistor() {
                    Color = "Violet",
                    SigFig = 7,
                    Multiplier = 7,
                    Tolerance = 0.001,
                    HexColor = "#AB47BC"
                },
                new Resistor() {
                    Color = "Gray",
                    SigFig = 8,
                    Multiplier = 8,
                    Tolerance = .005,
                    HexColor = "#9E9E9E"
                },
                new Resistor() {
                    Color = "White",
                    SigFig = 9,
                    Multiplier = 9,
                    Tolerance = 0,
                    HexColor = "#ffffff"
                },
                new Resistor() {
                    Color = "Gold",
                    SigFig = 0,
                    Multiplier = -1,
                    Tolerance = .05,
                    HexColor = "#FFD700"
                },
                new Resistor() {
                    Color = "Silver",
                    SigFig = 0,
                    Multiplier = -2,
                    Tolerance = .10,
                    HexColor = "#C0C0C0"
                },
                new Resistor() {
                    Color = "None",
                    SigFig = 0,
                    Multiplier = 0,
                    Tolerance = .20,
                    HexColor = "transparent"
                }
            };

            for (int i = 0; i < Resistors.Count; i++) {
                var resistor = Resistors[i];

                var dbResistor = (from r in resistorDbContext
                                  where r.Color == resistor.Color
                                  select r).FirstOrDefault();

                if (dbResistor == null) {
                    resistorDbContext.Add(resistor);
                }
                else {
                    Resistors[i] = dbResistor;
                }
            }

            await _db.SaveChangesAsync();

        }
    }
}
