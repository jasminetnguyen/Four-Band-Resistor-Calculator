namespace BlindsInterview.Controllers {

    export class HomeController {
        public resistors;
        public toleranceResistors;
        public selectedBandOne;
        public selectedBandTwo;
        public selectedBandThree;
        public selectedBandFour;
        public averageValue;
        public toleranceValue;

        constructor(private $http: ng.IHttpService) {
            $http({
                url: '/api/resistor',
                method: 'GET'
            }).then((res: any) => {
                console.log(res);
                this.resistors = res.data;
                this.selectedBandOne = this.resistors[2];
                this.selectedBandTwo = this.resistors[1];
                this.selectedBandThree = this.resistors[5];
                this.toleranceResistors = res.data.filter((resistor) => {
                    if (resistor.tolerance !== 0) {
                        return true;
                    } else {
                        return false;
                    }
                });
                this.selectedBandFour = this.toleranceResistors[4]
                console.log(this.resistors);
                console.log(this.toleranceResistors);
                this.calculateValue();
            }).catch((err) => {
                alert('Could not get resistors');
            });;

        }

        calculateValue() {
            this.$http({

                url: '/api/resistor',
                method: "POST",
                params: {
                    bandOne: this.selectedBandOne.color,
                    bandTwo: this.selectedBandTwo.color,
                    multiplier: this.selectedBandThree.color,
                    tolerance: this.selectedBandFour.color
                }
            }).then((response : any) => {
                this.averageValue = response.data.averageValue;
                this.toleranceValue = response.data.tolerance;

            }).catch((err) => {
                alert('Could not calculate resistor');
            });
        };
    }



    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
