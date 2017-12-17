using System;
namespace Decorator
{
    public class DecoratorPattern
    {
        interface ICar {
            void park();
        }

        class Car: ICar {
            public void park(){
                Console.WriteLine("car is parking ...");
            }

            public void move(){
                Console.WriteLine("car is moving ...");
            }

            public void brake()
            {
                Console.WriteLine("car is braking ...");
            }
        }

        class DecoratorParkingCamera: ICar {
            ICar car;

            public DecoratorParkingCamera(ICar c) {
                car = c;
            }

            public void park() {
                car.park();
                Console.WriteLine("and camera is monitoring ...");
            }
        }

        class MainClass {

            public static void Main() {
                Car car = new Car();
                car.move();
                car.brake();
                car.park();

                Console.WriteLine("\n");

                // Adding decorator dynamically
                DecoratorParkingCamera decoratedcar = new DecoratorParkingCamera(car);
                decoratedcar.park();
            }
        }
    }
}
