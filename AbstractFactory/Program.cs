using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IFan { } //abstract product
    public interface ILight { } //abstract product
    public class BajajFan : IFan { } //concrete product
    public class BajajLight : ILight { } //concrete product
    public class PhilipsFan : IFan { } //concrete product
    public class PhilipsLight : ILight { } //concrete product
    interface IElectricalFactory //abstract factory
    {
        IFan GetFan();
        ILight GetLight();
    }

    public class BajajFactory : IElectricalFactory //concrete factory
    {
        public IFan GetFan()
        {
            return new BajajFan();
        }        
        public ILight GetLight()
        {
            return new BajajLight();
        }
    }

    public class PhilipsFactory : IElectricalFactory //concrete factory
    {
        public IFan GetFan()
        {
            return new PhilipsFan();
        }
        public ILight GetLight()
        {
            return new PhilipsLight();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IElectricalFactory electrical_factory = new BajajFactory();
            IFan bajaj_fan= electrical_factory.GetFan();

            electrical_factory = new PhilipsFactory();
            ILight philips_light = electrical_factory.GetLight();
        }
    }
}
