using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingStructure
{
    public abstract class Vehicle
    {
        public Vehicle(string vehiclenumber)
        {
            this.vehiclenumber = vehiclenumber;
        }
        public abstract int pay();
        public DateTime parkedtime;
        public string vehiclenumber;
    }
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string vehiclenumber) : base(vehiclenumber)
        {
        }

        public override int pay()
        {
            if ((DateTime.Now - parkedtime).TotalHours < 3)
                return 40;
            else
                return 60;
        }
    }
    public class Car : Vehicle
    {
        public Car(string vehiclenumber) : base(vehiclenumber)
        {
        }

        public override int pay()
        {
            if ((DateTime.Now - parkedtime).TotalHours < 3)
                return 60;
            else
                return 100;
        }
    }
    public abstract class ParkingSpace
    {

        private bool isOccupied { get; set; }
        private int slotNumber;
        private Vehicle vehicle;


        public ParkingSpace(int slotNumber)
        {
            isOccupied = false;
            this.slotNumber = slotNumber;
        }

        void park()
        {
            isOccupied = true;
        }

        void unPark()
        {
            isOccupied = false;
        }

    
        public  string GetTicketNumber()
        {
            var uniquenumber = Guid.NewGuid().ToString();
            return uniquenumber;
        }

        public class SmallSlot : ParkingSpace
        {

            public SmallSlot(int slotNumber) : base(slotNumber)
            { 
            }
        }
        public class LargeSlot : ParkingSpace
        {

            public LargeSlot(int slotNumber) : base(slotNumber)
            {
            }
        }
        public class ParkingLot
        {

            private static  int NUMBER_OF_SMALL_SLOTS;
        
            private static  int NUMBER_OF_LARGE_SLOTS ;
            public Dictionary<string, ParkingSpace> occupiedSlots;
            private List<ParkingSpace> smallSlots;
          
            private List<ParkingSpace> largeSlots;

            public ParkingLot(int numofsmallslots,int numoflargeslots)
            {
                NUMBER_OF_SMALL_SLOTS = numofsmallslots;
                NUMBER_OF_LARGE_SLOTS = numoflargeslots;
                smallSlots = new List<ParkingSpace>(NUMBER_OF_SMALL_SLOTS);
                largeSlots = new List<ParkingSpace>(NUMBER_OF_LARGE_SLOTS);
                createSlots();
                occupiedSlots = new Dictionary<string, ParkingSpace>();
            }

            private void createSlots()
            {

                for (int i = 1; i <= NUMBER_OF_SMALL_SLOTS; i++)
                {
                    smallSlots.Add(new SmallSlot(i));
                }
               
                for (int i = 1; i <= NUMBER_OF_LARGE_SLOTS; i++)
                {
                    largeSlots.Add(new LargeSlot(i));
                }

            }

            public string park(Vehicle vehicle)
            {

                ParkingSpace slot;
                string uniqueToken = string.Empty;
                switch(vehicle.GetType().Name)
                {
                    case "Motorcycle":
                        if ((slot = getFirstEmptySlot(smallSlots)) != null)
                        {
                            uniqueToken = parkHelper(slot, vehicle);
                        }
                        break;
                    case "Car":
                        if ((slot = getFirstEmptySlot(largeSlots)) != null)
                        {
                            uniqueToken = parkHelper(slot, vehicle);
                        }
                        break;

                }
              
                return uniqueToken;
            }

            public void unPark(string ticket)
            {
                var slot = occupiedSlots[ticket];
               
                slot.unPark();
                occupiedSlots.Remove(ticket);
              

            }

            private ParkingSpace getFirstEmptySlot(List<ParkingSpace> slots)
            {
 
                ParkingSpace emptySlot = null;

                foreach(var slot in slots)
                {
                    emptySlot = slot;
                    if (!emptySlot.isOccupied)
                    {
                    
                        return emptySlot;
                    }
                }
                return null;
            }

            private string parkHelper(ParkingSpace slot, Vehicle vehicle)
            {
                slot.park();
                string ticketnumber = slot.GetTicketNumber() + "@" + slot.slotNumber;
                slot.vehicle = vehicle;
                vehicle.parkedtime = DateTime.Now;
                occupiedSlots.Add(ticketnumber, slot);
                return ticketnumber;
            }
        }

    }
}
