using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Lights
    {
        public void TurnOn()
        {
            Console.WriteLine("Lights - Switched ON");
        }
        public void TurnOff()
        {
            Console.WriteLine("Lights - Switched OFF");
        }
    }
    //'SubsystemB' class - a single unit of complex subsystem
    public class MusicSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Music System - Switched ON");
        }
        public void TurnOff()
        {
            Console.WriteLine("Music System - Switched OFF");
        }
    }
    //'SubsystemC' class - a single unit of complex subsystem
    public class TV
    {
        public void TurnOn()
        {
            Console.WriteLine("TV - Switched ON");
        }
        public void TurnOff()
        {
            Console.WriteLine("TV - Switched OFF");
        }
    }

    public class HomeFacade
    {
        Lights light;
        MusicSystem musicSystem;
        TV tv;

        public HomeFacade()
        {
            light = new Lights();
            musicSystem = new MusicSystem();
            tv = new TV();
        }
        //'operation in facade class'
        public void LeaveHome()
        {
            light.TurnOff();
            musicSystem.TurnOff();
            tv.TurnOff();
        }

        public void EnterHome()
        {
            light.TurnOn();
            musicSystem.TurnOn();
            tv.TurnOn();
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            HomeFacade facade = new HomeFacade();
            Console.WriteLine("--------------- Leaving Home ---------------");
            facade.LeaveHome();
            Console.WriteLine("--------------- Arriving Home --------------");
            facade.EnterHome();
            Console.ReadLine();
        }
    }
}
