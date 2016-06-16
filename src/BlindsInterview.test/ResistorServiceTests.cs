using BlindsInterview.Infrasturcture;
using BlindsInterview.Models;
using BlindsInterview.Services.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlindsInterview.Tests {
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class ResistorServiceTests {

        [Fact]
        public void CanaryTest() {
            Assert.True(true);
        }

        List<Resistor> TestResistors = new List<Resistor>() {
            new Resistor() {
                Color =  "red",
                SigFig = 2,
                Multiplier = 2,
                Tolerance = 2
            },
              new Resistor() {
                  Color = "yellow",
                  SigFig = 4,
                  Multiplier = 4,
                  Tolerance = 5
              },
              new Resistor() {
                  Color = "blue",
                  SigFig = 6,
                  Multiplier = 6,
                  Tolerance = .25
              },
              new Resistor() {
                  Color = "violet",
                  SigFig = 7,
                  Multiplier = 7,
                  Tolerance = .1
              }


        };

        public IMock<IResistorRepository> MockRepository {
            get {
                var mock = new Mock<IResistorRepository>();
                mock.Setup(x => x.GetResistor(It.IsAny<string>()))
                    .Returns<string>(x => TestResistors.Where(r => r.Color == x).AsQueryable());

                return mock;
            }
        }

        [Fact]
        public void TestRYBV() {

            //Arrange
            var resistorService = new ResistorService(MockRepository.Object);

            // Act
            var ohms = resistorService.CalculateOhmValue("red", "yellow", "blue", "violet");

            // Assert
            Assert.Equal(24000000, ohms);
        }
        [Fact]
        public void TestYBVR() {
            //Arrange
            var resistorService = new ResistorService(MockRepository.Object);

            //Act
            var ohms = resistorService.CalculateOhmValue("yellow", "blue", "violet", "red");

            //Assert
            Assert.Equal(460000000, ohms);
        }
        [Fact]
        public void TestBYRR() {
            //Arrange
            var resistorService = new ResistorService(MockRepository.Object);

            //Act
            var ohms = resistorService.CalculateOhmValue("blue", "yellow", "red", "red");

            //Assert
            Assert.Equal(6400, ohms);
        }

        [Fact]
        public void TestBadColor() {

            var mock = new Mock<IResistorRepository>();
            mock.Setup(x => x.GetResistor(It.IsAny<string>())).Returns(new List<Resistor>().AsQueryable());

            var resistorService = new ResistorService(mock.Object);
            
            Assert.Throws<ArgumentException>(() => 
                resistorService.CalculateOhmValue("bad", "bad", "bad", "bad")
            );
        }
    }
}
