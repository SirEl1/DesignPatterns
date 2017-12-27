using System;
namespace Proxy
{
    public class ProxyPattern
    {
        interface ICheckIn {
            void AllowBoarding(string passengername);
        }

        public class Flight: ICheckIn {

            public void AllowBoarding(string passengername) {
            
                Console.WriteLine("Passenger " + passengername  + " is allowed to board the flight.");
            
            }
        }

        public class Passenger {
            public string name;
            public bool hasValidPassport;
            public bool hasValidBoardingPass;

            public Passenger(string n, bool validpassport, bool validboardingpass) {
                name = n;
                hasValidPassport = validpassport;
                hasValidBoardingPass = validboardingpass;
            }
        }

        public class ProxyCheckIn: ICheckIn {
            private Passenger passenger;
            private Flight flight;

            public ProxyCheckIn(Passenger p)
            {
                this.passenger = p;
                this.flight = new Flight();
            }


            public void AllowBoarding(string passengername) {

                if(passenger.hasValidPassport && passenger.hasValidBoardingPass) {
                    this.flight.AllowBoarding(passenger.name);
                }
                else{
                    Console.WriteLine("The passenger " + passenger.name + " is not allowed to board the flight.");
                }

            }
        }

        class MainClass
        {

            public static void Main()
            {
                Passenger passenger1 = new Passenger("John Doe", true, false);
                ICheckIn checkin = new ProxyCheckIn(passenger1);
                checkin.AllowBoarding(passenger1.name);

                Passenger passenger2 = new Passenger("Judy Summers", true, true);
                checkin = new ProxyCheckIn(passenger2);
                checkin.AllowBoarding(passenger2.name);
            }
        }
    }
}
