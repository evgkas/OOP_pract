/*Для создания программы по управлению автопарком нужно реализовать следующие сущности в виде отдельных классов: 
"Двигатель"(включает в себя поля мощность, объем, тип, серийный номер), "Шасси"(количество колес, номер, 
    допустимая нагрузка), "Трансмиссия"(тип, количество передач, производитель).

С использованием этих классов реализовать сущности "Легковой автомобиль", "Грузовик", "Автобус", "Скутер" 
(отличающиеся уникальными полями), и обеспечить вывод полной информации об объектах этих типов. */

/*Заполнить единую коллекцию, содержащую объекты типа "Грузовик", "Легковой автомобиль", "Автобус", "Скутер" (из предыдущего задания по ООП) с различными значениями полей.
Записать в соответствующие XML файлы следующую информацию:
Полную информацию о всех транспортных средствах, обьем двигателя которых больше чем 1.5 литров;
Тип двигателя, серийный номер и его мощность для всех автобусов и грузовиков;
Полную информацию о всех транспортных средствах, сгруппированную по типу трансмиссии.*/
using OOP_pract;
using System.Xml;
using System.Xml.Linq;


public class Program
{
    private static void Main()
    {
        var cars = new List<Car>
        {
            new ("car", "auto", 6, "Reno", 4, "AA200914_ch", 2000, 190, 1.6, "gas", "1124267eng"), //cars
            new ("car", "auto", 6, "Audi", 4, "AA200915_ch", 2000, 230, 1.9, "diesel", "0000001eng"),
            new ("car", "manual", 5, "KIA", 4, "AA200916_ch", 1700, 140, 1.4, "gas", "0000002eng"),
            new ("truck", "auto", 8, "MAN", 6, "CHS121314123", 12000, 450, 5, "diesel", "ENG11234A213"), //trucks
            new ("truck", "manual", 9, "MAZ", 6, "CHS121314124", 8000, 355, 3.8, "diesel", "ENG11234A214"),
            new ("truck", "auto", 8, "MAN", 6, "CHS121314125", 11000, 400, 5, "gas", "ENG11234A215"),
            new ("bus", "manual", 8, "Toyota", 6, "CH1235165", 20000, 350, 4.5, "diesel", "ENG123549346"), //buses
            new ("bus", "auto", 9, "Mercedes", 8, "CH1235166", 15000, 280, 3.2, "diesel", "ENG123549347"),
            new ("scooter", "auto", 2, "Suzuki", 2, "CH764112", 200, 50, 0.0448, "gas", "ENG65124") //scooters
        };

        var carsByVolume = from c in cars
                           where c.volume > 1.5
                           select c;
        
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = ("    ");
        settings.CloseOutput = true;
        settings.OmitXmlDeclaration = true;

        using (XmlWriter writer = XmlWriter.Create("carsByVolume.xml", settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Vechiles");
            int i = 1;
            foreach (var car in carsByVolume)
            {
                writer.WriteStartElement($"{car.CarType}{i}"); 
                i++;

                writer.WriteStartElement($"Transmission");
                writer.WriteElementString("Type", $"{car.TransmissionType}");
                writer.WriteElementString("GearsNumber", $"{car.GearsNumber}");
                writer.WriteElementString("Manufacture", $"{car.manufacture}");
                writer.WriteEndElement();

                writer.WriteStartElement("Chassis");
                writer.WriteElementString("NumberOfWhhels", $"{car.WheelsNumber}");
                writer.WriteElementString("SerialNumber", $"{car.ChassisSerial}");
                writer.WriteElementString("MaxWeight", $"{car.MaxWeight}");
                writer.WriteEndElement();

                writer.WriteStartElement("Engine");
                writer.WriteElementString("Power", $"{car.power}");
                writer.WriteElementString("Volume", $"{car.volume}");
                writer.WriteElementString("Type", $"{car.EngineType}");
                writer.WriteElementString("SerialNumber", $"{car.EngineSerial}");
                writer.WriteEndElement();

                writer.WriteEndElement();               
            }
            writer.WriteEndDocument();
            writer.Flush();
        }

        var engines = from c in cars
                      where (c.CarType == "bus") || (c.CarType == "truck")
                      select c;
        
        using (XmlWriter writer = XmlWriter.Create("engines.xml", settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Vechiles");
            foreach (var car in engines)
            {
                writer.WriteStartElement($"{car.CarType}");

                writer.WriteElementString("Power", $"{car.power}");
                writer.WriteElementString("Type", $"{car.EngineType}");
                writer.WriteElementString("SerialNumber", $"{car.EngineSerial}");

                writer.WriteEndElement();
            }
            writer.WriteEndDocument();
            writer.Flush();
        }

        var orderedCars = from c in cars
                          orderby c.TransmissionType
                          select c;        

        using (XmlWriter writer = XmlWriter.Create("orderedCars.xml", settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Vechiles");

            foreach (var car in orderedCars)
            {
                writer.WriteStartElement($"{car.CarType}");

                writer.WriteStartElement($"Transmission");
                writer.WriteElementString("Type", $"{car.TransmissionType}");
                writer.WriteElementString("GearsNumber", $"{car.GearsNumber}");
                writer.WriteElementString("Manufacture", $"{car.manufacture}");
                writer.WriteEndElement();

                writer.WriteStartElement("Chassis");
                writer.WriteElementString("NumberOfWhhels", $"{car.WheelsNumber}");
                writer.WriteElementString("SerialNumber", $"{car.ChassisSerial}");
                writer.WriteElementString("MaxWeight", $"{car.MaxWeight}");
                writer.WriteEndElement();

                writer.WriteStartElement("Engine");
                writer.WriteElementString("Power", $"{car.power}");
                writer.WriteElementString("Volume", $"{car.volume}");
                writer.WriteElementString("Type", $"{car.EngineType}");
                writer.WriteElementString("SerialNumber", $"{car.EngineSerial}");
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
        }





        /*
        Engine careng = new(221, 1.8, "v6", "AA1234532");
        //careng.PrintE();
        Chassis carch = new(4, "AA001S88", 1600);
        //carch.PrintC();
        Chassis carch1 = new(4, "AA002S99", 2000, 330, 2.5, "v6", "AA1422345eng");
        //carch1.PrintC();
        Transmission cartrs = new Transmission("automatic", 4, "Toyota");
        //cartrs.PrintT();
        //Transmission car = new("automatic", 6, "Reno", 4, "AA200914_ch", 2000, 190, 1.6, "v6", "1124267eng");
        //Console.WriteLine("CAR");
        // car.Print();
        //Transmission truck = new("manual", 8, "MAN", 6, "CHS121314123", 12000, 450, 5, "diesel", "ENG11234A213");
        // Console.WriteLine("TRUCK");
        // truck.Print();
        //Transmission bus = new("manual", 8, "Toyota", 6, "CH1235165", 20000, 350, 4.5, "diesel", "ENG123549346");
        //Transmission scooter = new("auto", 2, "Suzuki", 2, "CH764112", 200, 50, 44.8, "gas", "ENG65124");
        //Console.WriteLine("BUS");
        //bus.Print();
        //Console.WriteLine("SCOOTER");
        //scooter.Print(); */
    }
}