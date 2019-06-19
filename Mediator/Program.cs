using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    interface Command
    {
        void land();
    }
    interface IAirTrafficControl
    {
        void registerRunway(Runway runway);
        void registerFlight(Flight flight);
        bool isLandingOk();
        void setLandingStatus(bool status);
    }

    class AirTrafficController : IAirTrafficControl
    {
        private Flight flight;
        private Runway runway;
        public bool landingOK;
        public bool isLandingOk()
        {
            return this.landingOK;
        }
        public void registerFlight(Flight flight)
        {
            this.flight = flight; ;
        }
        public void registerRunway(Runway runway)
        {
            this.runway = runway;
        }
        public void setLandingStatus(bool status)
        {
            this.landingOK = status;
        }
    }

    class Flight : Command
    {
        private IAirTrafficControl airTrafficController;

        public Flight(IAirTrafficControl airTrafficControl)
        {
            this.airTrafficController = airTrafficControl;
        }

        public void land()
        {
            if (airTrafficController.isLandingOk())
            {
                Console.WriteLine("Successfully Landed.");
                airTrafficController.setLandingStatus(true);
            }
            else
                Console.WriteLine("Waiting for landing.");
        }

        public void getReady()
        {
            Console.WriteLine("Ready for landing.");
        }

    }

    class Runway : Command
    {
        private IAirTrafficControl airTrafficController;

        public Runway(IAirTrafficControl atControl)
        {
            this.airTrafficController = atControl;
            atControl.setLandingStatus(true);
        }
        public void land()
        {
            Console.WriteLine("Landing permission granted.");
            airTrafficController.setLandingStatus(true);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            AirTrafficController controlCenter = new AirTrafficController();
            Flight boeing101 = new Flight(controlCenter);
            Runway mainRunway = new Runway(controlCenter);
            controlCenter.registerFlight(boeing101);
            controlCenter.registerRunway(mainRunway);
            boeing101.getReady();
            mainRunway.land();
            boeing101.land();
            Console.ReadLine();
        }
    }
}
