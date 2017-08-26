using ParkingStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingStructure.ParkingSpace;

namespace ConsoleApplication27
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberofsmallslots = 3;
            int numberoflargeslots = 3;
            Console.WriteLine("Number of slots for motorcycle " + numberofsmallslots);
            Console.WriteLine("Number of slots for cars " + numberoflargeslots);

            ParkingLot obj = new ParkingLot(numberofsmallslots, numberoflargeslots);

            Vehicle vehicle1 = new Motorcycle("MH1024");
            var uniquetoken1 = obj.park(vehicle1);
            if (!string.IsNullOrEmpty(uniquetoken1))
                Console.WriteLine("Parking Successful for motorcycle " + vehicle1.vehiclenumber + " at Slot : " + uniquetoken1.Split('@')[1]);
            else
                Console.WriteLine("Parking unsuccessful for motorcycle. Please wait... " + vehicle1.vehiclenumber);

            Vehicle vehicle2 = new Motorcycle("TN4555");
            var uniquetoken2 = obj.park(vehicle2);
            if (!string.IsNullOrEmpty(uniquetoken2))
                Console.WriteLine("Parking Successful for motorcycle " + vehicle2.vehiclenumber + " at Slot : " + uniquetoken2.Split('@')[1]);
            else
                Console.WriteLine("Parking unsuccessful for motorcycle. Please wait... " + vehicle2.vehiclenumber);

            Vehicle vehicle3 = new Motorcycle("HM4444");

            var uniquetoken3 = obj.park(vehicle3);
            if (!string.IsNullOrEmpty(uniquetoken3))
                Console.WriteLine("Parking Successful for motorcycle " + vehicle3.vehiclenumber + " at Slot : " + uniquetoken3.Split('@')[1]);
            else
                Console.WriteLine("Parking unsuccessful for motorcycle. Please wait... " + vehicle3.vehiclenumber);

            Vehicle vehicle4 = new Motorcycle("MH1025");
            var uniquetoken4 = obj.park(vehicle4);
            if (!string.IsNullOrEmpty(uniquetoken4))
                Console.WriteLine("Parking Successful for motorcycle " + vehicle4.vehiclenumber + " at Slot : " + uniquetoken4.Split('@')[1]);
            else
                Console.WriteLine("Parking unsuccessful for motorcycle. Please wait... " + vehicle4.vehiclenumber);

            //Unpark Vehicle 2
            obj.unPark(uniquetoken2);
            Console.WriteLine("motorcycle unparked from slot " + uniquetoken2.Split('@')[1]);

            var amount = vehicle2.pay();
            Console.WriteLine("Pay amount to the ticket collector " + amount);

            //Again try parking Vehicle 4

            uniquetoken4 = obj.park(vehicle4);
            if (!string.IsNullOrEmpty(uniquetoken4))
                Console.WriteLine("Parking Successful for motorcycle " + vehicle4.vehiclenumber + " at Slot : " + uniquetoken4.Split('@')[1]);
            else
                Console.WriteLine("Parking unsuccessful for motorcycle. Please wait... " + vehicle4.vehiclenumber);

            Vehicle car1 = new Car("KN5555");

            var uniquetoken5 = obj.park(car1);
            if (!string.IsNullOrEmpty(uniquetoken4))
                Console.WriteLine("Parking Successful for car " + car1.vehiclenumber + " at Slot : " + uniquetoken5.Split('@')[1]);
            else
                Console.WriteLine("Parking unsuccessful for car " + car1.vehiclenumber);

            Console.Read();
        }
    }
}
