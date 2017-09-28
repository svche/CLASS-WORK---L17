using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Domain;


namespace Util
{
    public class FileWork
    {
        private const string fileName = "file.txt";

        public void writeAllToFile(List<Transport> list)
        {
            StreamWriter sw = new StreamWriter(fileName, true);

            foreach (Transport t in list)
            {
                sw.WriteLine(t.infoToWrite());
            }
            sw.Close();
        }

        public List<Transport> readAllFromFile()
        {
            List<Transport> result = new List<Transport>();

            string[] fromFile = File.ReadAllLines(fileName);

            foreach (string s in fromFile)
            {
                string[] items = s.Split('\t');

                switch (items[1])
                {
                    case "Car":
                        {
                            result.Add(getCarObject(items));
                            break;
                        }
                    case "Airplane":
                        {
                            result.Add(getAirplaneObject(items));
                            break;
                        }
                    case "Ship":
                        {
                            result.Add(getCarObject(items));
                            break;
                        }
                }

            }
            return result;
        }

        private Car getCarObject(string[] items)
        {
            Car car = new Car();
            car.Manufacturer = items[2];
            car.Speed = int.Parse(items[3]);
            car.Weight = double.Parse(items[4]);
            car.Height = double.Parse(items[5]);
            car.Engine = getEngine(items);
            car.Amount = int.Parse(items[10]);
            car.Transmission = items[11];
            car.Body = items[12];

            return car;
        }

        private Airplane getAirplaneObject(string[] items)
        {
            Airplane plane = new Airplane();
            plane.Manufacturer = items[2];
            plane.Speed = int.Parse(items[3]);
            plane.Weight = double.Parse(items[4]);
            plane.Height = double.Parse(items[5]);
            plane.Engine = getEngine(items);
            plane.Amount = int.Parse(items[10]);
            plane.MaxHeight = int.Parse(items[11]);

            return plane;
        }

        private Ship getShipeObject(string[] items)
        {
            Ship boat = new Ship();
            boat.Manufacturer = items[2];
            boat.Speed = int.Parse(items[3]);
            boat.Weight = double.Parse(items[4]);
            boat.Height = double.Parse(items[5]);
            boat.Engine = getEngine(items);
            boat.Amount = int.Parse(items[10]);
            boat.WaterVal = int.Parse(items[11]);

            return boat;
        }

        public Engine getEngine(string[] items)
        { 
            Engine engine = null;
            switch (items[6])
            {
                case "PetrolEngine":
                    {
                        engine = getPetrolEngine(items);
                        break;
                    }

                case "DieselEngine":
                    {
                        engine = getDieselEngine(items);
                        break;
                    }
                case "ReactiveEngine":
                    {
                        engine = getReactiveEngine(items);
                        break;
                    }
            }
            return engine;
        }

        public PetrolEngine getPetrolEngine(string[] items)
        {
            PetrolEngine petrolEngine = new PetrolEngine();
            petrolEngine.Power = int.Parse(items[7]);
            petrolEngine.Manufacturer = items[8];
            petrolEngine.Cubes = int.Parse(items[9]);

            return petrolEngine;
        }

        public DieselEngine getDieselEngine(string[] items)
        {
            DieselEngine dieselEngine = new DieselEngine();
            dieselEngine.Power = int.Parse(items[7]);
            dieselEngine.Manufacturer = items[8];
            dieselEngine.DCubes = int.Parse(items[9]);

            return dieselEngine;
        }

        public ReactiveEngine getReactiveEngine(string[] items)
        {
            ReactiveEngine reactiveEngine = new ReactiveEngine();
            reactiveEngine.Power = int.Parse(items[7]);
            reactiveEngine.Manufacturer = items[8];
            reactiveEngine.VoiceVal = int.Parse(items[9]);

            return reactiveEngine;
        }
    }

    public static class PrintWork
    {
        public static void printAll(List<Transport> list)
        {
            foreach (Transport t in list) Console.WriteLine(t.getInformation());
        }

        public static void prinByCategory(List<Transport> list, string category)
        {
            foreach (Transport t in list)
            {
                if (category.Trim().Equals(t.GetType().Name))
                {
                    Console.WriteLine(t.getInformation());
                }
            }

        }
    }

    public static class SortWork
    {
        public static void sortByModel(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.Manufacturer.CompareTo(l2.Manufacturer));
        }

        public static void sortBySpeed(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.Speed.CompareTo(l2.Speed));
        }

        public static void sortByCategory(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.GetType().Name.CompareTo(l2.GetType().Name));
        }

    }

    public class SalesWork
    {
        public void sellItem(Transport transport, int amount)
        {
            int currentAmount = transport.Amount;
            if (amount < 0 || amount > currentAmount)
            {
                throw new ArithmeticException();
            }
            transport.Amount -= amount;
        }

        public void buyItem (Transport transport, int amount)
        {
            transport.Amount -= amount;
        }
    }

    public class Menu
    {
        public void use()
        {
            SalesWork sw = new SalesWork();
            FileWork fw = new FileWork();
            List<Transport> workList = new List<Transport>();
            bool flag = true;
            bool readFromFileFlag = false;
            string choice;
            Console.WriteLine("Welcome to the system!");

            do
            {
                printMenu();

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            readFromFileItem(ref readFromFileFlag, workList, fw);
                            break;
                        }
                    case "2":
                        {
                            printAllInformationItem(workList);
                            break;
                        }
                    
                      
                }
            } while (flag);
            
        }

        private void printMenu()
        {
            Console.WriteLine(@"

Make choise:
1. Read all from file
2. Print all information
3. Sorting:
3.1     by model
3.2     by speed
3.3     by category
4. Sell items
5. Buy items
6. Add new item
0. Exit ");
        }

        private void readFromFileItem(ref bool readFromFileFlag, List<Transport> workList, FileWork fw)
        {
            if (!readFromFileFlag)
            {
                workList.AddRange(fw.readAllFromFile());
                readFromFileFlag = true;
                Console.WriteLine("Database loaded");
            }
            else
            {
                Console.WriteLine("Database is up to date");
            }
        }

        private void printAllInformationItem(List<Transport> workList)
        {
            if (workList.Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                PrintWork.printAll(workList);
            }
        }
         
    }

}
