using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Transport
    {
        protected int speed;
        protected string manufacturer;
        protected double weight;
        protected double height;
        protected Engine engine;
        protected int amount;

        public virtual string getInformation()
        {
            return "Manufacturer: " + manufacturer
               + "\nSpeed: " + speed
               + "\nWeight: " + weight
               + "\nHeight: " + height
               + "\nEngine: " + engine.getInformation()
               + "\nAmount: " + amount;
        }

        public virtual string infoToWrite()
        {
            return  GetType().BaseType.Name + "\t"
               + GetType().Name + "\t"
               + manufacturer + "\t"
               + speed + "\t"
               + weight + "\t"
               + height + "\t"
               + engine.infoToWrite()
               + amount + "\t";
        }


        public Transport()
        {
            manufacturer = "unknown";
        }

        public Transport(int speed, string manufacturer, double weight, double height, Engine engine, int amount)
        {
            this.speed = speed;
            this.manufacturer = manufacturer;
            this.weight = weight;
            this.height = height;
            this.engine = engine;
            this.amount = amount;
        }

        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return engine;
            }
            set
            {
                engine = value;
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }


    }

    public abstract class WaterTransport : Transport
    {
        public WaterTransport() : base()
        {
            engine = new DieselEngine();

        }

        public WaterTransport(int speed, string manufacturer, double weight, double height, Engine engine, int amount)
            : base(speed, manufacturer, weight, height, engine, amount)
        {

        }

    }
    public abstract class AirTransport : Transport
    {
        public AirTransport() : base()
        {
            engine = new ReactiveEngine(); 
        }

        public AirTransport(int speed, string manufacturer, double weight, double height, Engine engine, int amount)
            : base(speed, manufacturer, weight, height, engine, amount)
        {

        }
    }
    public abstract class LandTransport : Transport
    {
        public LandTransport() : base()
        {
            engine = new PetrolEngine();

        }

        public LandTransport(int speed, string manufacturer, double weight, double height, Engine engine, int amount)
            : base(speed, manufacturer, weight, height, engine, amount)
        {

        }
    }

    public class Car : LandTransport
    {
        private string transmission;
        private string body;

        public Car() : base()
        {
            transmission = "unknown";
            body = "unknown";
        }

        public Car(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string transmission,
                string body)
                : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.transmission = transmission;
            this.body = body;
        }

        public string Transmission
        {
            get { return transmission; }
            set { transmission = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\nTransmission: " + transmission
                + "\nBody: " + body
                + "\n";
        }

        public override string infoToWrite()
        {
            return base.infoToWrite()
                + transmission + "\t"
                + body + "\t";
        }
    }

    public class Airplane : AirTransport
    {
        private int maxHeight;

        public Airplane() : base()
        {
        }

        public Airplane(int speed, string manufacturer, double weight, double height, Engine engine, int amount, int maxHeight)
                : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.maxHeight = maxHeight;
        }

        public int MaxHeight
        {
            get { return maxHeight; }
            set { maxHeight = value; }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\nMaxHeight: " + maxHeight
                + "\n";
        }

        public override string infoToWrite()
        {
            return base.infoToWrite() 
                + maxHeight + "\t";
        }
    }

    public class Ship : WaterTransport
    {
        private double waterVal;

        public Ship() : base()
        {
        }

        public Ship(int speed, string manufacturer, double weight, double height, Engine engine, int amount, double waterVal)
                : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.waterVal = waterVal;
        }

        public double WaterVal
        {
            get { return waterVal; }
            set { waterVal = value; }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\nWaterVal: " + waterVal
                + "\n";
        }

        public override string infoToWrite()
        {
            return base.infoToWrite()
                + waterVal + "\t";
        }

    }

    public class Train : LandTransport
    {
        private string type;

        public Train() : base()
        {
            type = "unknown";
        }

        public Train(int speed, string manufacturer, double weight, double height, Engine engine, int amount, string type)
                : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.type = type;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\nType: " + type
                + "\n";
        }

        public override string infoToWrite()
        {
            return base.infoToWrite()
                + type + "\t";
        }


    }

    public class Bike : LandTransport
    {
        private double sizeWheel;

        public Bike() : base()
        {
        }

        public Bike(int speed, string manufacturer, double weight, double height, Engine engine, int amount, double sizeWheel)
                : base(speed, manufacturer, weight, height, engine, amount)
        {
            this.sizeWheel = sizeWheel;
        }

        public double SizeWheel
        {
            get { return sizeWheel; }
            set { sizeWheel = value; }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\nSizeWheel: " + sizeWheel
                + "\n";
        }

        public override string infoToWrite()
        {
            return base.infoToWrite()
                + sizeWheel + "\t";
        }
    }

    public abstract class Engine
    {
        protected double power;
        protected string manufacturer;


        public Engine()
        {
            manufacturer = "unknown";
        }

        public Engine(int power, string manufacturer)
        {
            this.power = power;
            this.manufacturer = manufacturer;
        }

        public double Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public virtual string getInformation()
        {
            return "\nPower: " + power
                + "\nManufacturer: " + manufacturer;
        }

        public virtual string infoToWrite()
        {
            return GetType().Name + "\t" 
                + power + "\t"
                + manufacturer + "\t";
        }

    }

    public class PetrolEngine : Engine
    {
        protected int cubes;

        public PetrolEngine() : base()
        {
        }

        public PetrolEngine(int power, string manufacturer, int cubes) : base(power, manufacturer)
        {
            this.cubes = cubes;
        }

        public int Cubes
        {
            get { return cubes; }
            set { cubes = value; }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\nCubes: " + cubes;
        }

        public override string infoToWrite()
        {
            return base.infoToWrite() + cubes + "\t";
        }
    }

    public class DieselEngine : Engine
    {
        protected int dCubes;

        public DieselEngine() : base()
        {
        }

        public DieselEngine(int power, string manufacturer, int dCubes) : base(power, manufacturer)
        {
            this.dCubes = dCubes;
        }

        public int DCubes
        {
            get { return dCubes; }
            set { dCubes = value; }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\nDCubes: " + dCubes
                + "\n";
        }

        public override string infoToWrite()
        {
            return base.infoToWrite() + dCubes + "\t";
        }

    }

    public class ReactiveEngine : Engine
    {
        protected int voiceVal;

        public ReactiveEngine() : base()
        {
        }

        public ReactiveEngine(int power, string manufacturer, int voiceVal) : base(power, manufacturer)
        {
            this.voiceVal = voiceVal;
        }

        public int VoiceVal
        {
            get { return voiceVal; }
            set { voiceVal = value; }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\nVoiceVal: " + voiceVal;
        }

        public override string infoToWrite()
        {
            return base.infoToWrite() + voiceVal + "\t";
        }

    }

}    
    




    
