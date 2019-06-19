using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public enum Battery { mAH_1000, mAH_1500, mAH_2000, mAH_3300 };

    public enum OperatingSystem { ANDROID_8, ANDROID_9, ANDROID_ONE, WINDOWS };

    public enum Camera { Single_12MP, Single_16MP, Dual_8MP, Dual_16MP };

    public class MobileDevice
    {
        
        public MobileDevice(string Name)
        {
            this.DeviceName = Name;
        }

        string DeviceName { get; }
        public Battery phoneBattery { get; set; }
        public OperatingSystem phoneOS { get; set; }
        public Camera phoneCamera { get; set; }

        public string ProductSpecs()
        {
            return string.Format("Name: {0},\nBattery: {1},\nOS: {2},\nCamera: {3}", this.DeviceName, this.phoneBattery, this.phoneOS, this.phoneCamera);
        }
    }

    interface IDeviceBuilder //the Builder interface
    {
        void SetBattery();
        void SetOperatingSystem();
        void SetCamera();

        MobileDevice mobile_device { get; }
    }


    public class SonyMobileBuilder : IDeviceBuilder //the Concrete Builder class
    {
        MobileDevice sony_mobile;
        public SonyMobileBuilder()
        {
            sony_mobile = new MobileDevice("Sony Xperia Z1");
        }

        #region IdeviceBuilder members

        public MobileDevice mobile_device
        {
            get
            {
                return sony_mobile;
            }
        }
        public void SetCamera()
        {
            sony_mobile.phoneCamera = Camera.Single_16MP;
        }

        public void SetBattery()
        {
            sony_mobile.phoneBattery = Battery.mAH_2000;
        }

        public void SetOperatingSystem()
        {
            sony_mobile.phoneOS = OperatingSystem.ANDROID_9;
        }

        #endregion
    }

    public class MotorolaMobileBuilder : IDeviceBuilder //the Concrete Builder class
    {
        MobileDevice moto_mobile;
        public MotorolaMobileBuilder()
        {
            moto_mobile = new MobileDevice("Moto Plus F4");
        }

        #region IdeviceBuilder members

        public MobileDevice mobile_device
        {
            get
            {
                return moto_mobile;
            }
        }
        public void SetCamera()
        {
            moto_mobile.phoneCamera = Camera.Dual_16MP;
        }

        public void SetBattery()
        {
            moto_mobile.phoneBattery = Battery.mAH_1500;
        }

        public void SetOperatingSystem()
        {
            moto_mobile.phoneOS = OperatingSystem.ANDROID_ONE;
        }

        #endregion
    }

    class Manufacturer //the director class
    {
        public void Construct(IDeviceBuilder phoneBuilder)
        {
            phoneBuilder.SetBattery();
            phoneBuilder.SetOperatingSystem();
            phoneBuilder.SetCamera();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Manufacturer mf = new Manufacturer(); //initializing manufacturer
            IDeviceBuilder device_builder = null; //initializng the builder

            //making sony device 
            device_builder = new SonyMobileBuilder();
            mf.Construct(device_builder);
            Console.WriteLine(device_builder.mobile_device.ProductSpecs());

            device_builder = new MotorolaMobileBuilder();
            mf.Construct(device_builder);
            Console.WriteLine(device_builder.mobile_device.ProductSpecs());

            Console.ReadLine();

        }
    }
}
