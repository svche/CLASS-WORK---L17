using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Util;

namespace CLASS_WORK___L17
{
    class Program
    {
        static void Main(string[] args)
        {
            Transport car = new Car();
           // Console.WriteLine(car.getInformation() + "\n");

            Transport plane = new Airplane();
            //   Console.WriteLine(car.getInformation());

            Transport boat = new Ship();

            List<Transport> list = new List<Transport>();
            list.Add(car);
            list.Add(plane);
            list.Add(boat);

            //    foreach (Transport t in list) Console.WriteLine(t.getInformation() + "\n");

            FileWork fw = new FileWork();
            //fw.writeAllToFile(list);
            //fw.readAllFromFile();
            List<Transport> fromFile = fw.readAllFromFile();

            PrintWork.prinByCategory(fromFile, "Car");

        }
    }
}
