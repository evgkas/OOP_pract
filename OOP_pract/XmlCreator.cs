using OOP_pract.Cars;
using System.Xml;
using System.Xml.Linq;

namespace OOP_pract
{
    public class XmlCreator
    {
        private XmlWriterSettings settings;

        public XmlCreator()
        {
            settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
        }

        public void CarsEngineVolumeAbove(List<Car> cars, double minValue, string fileName)
        {
            var carsByVolume = from c in cars
                               where c.engine.volume > minValue
                               select c;

            List<Car> carsList = carsByVolume.ToList();
            CreateFullInfo(carsList, fileName);
        }

        public void BusAndTrucksEnginesInfo(List<Car> cars, string fileName)
        {
            var enginesToXML = new XElement("Root",
            from c in cars
            where ((c is Bus) || (c is Truck))
            select new XElement("Vechile",
                       new XElement("Serial", c.engine.serialNumber),
                       new XElement("Power", c.engine.power),
                       new XElement("Type", c.engine.type)
                    )
                );
            enginesToXML.Save(fileName);
        }

        public void OrderByTransmissionType(List<Car> cars, string fileName)
        {
            var orderedCars = from c in cars
                              orderby c.transmission.type
                              select c;

            List<Car> carsList = orderedCars.ToList();
            CreateFullInfo(carsList, fileName);
        }

        public void CreateFullInfo(List<Car> cars, string fileName)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Vechiles");
                foreach (var car in cars)
                {
                    writer.WriteStartElement($"{car.brand}");
                    writer.WriteElementString("id", $"{car.id}");

                    if (car is Truck truck)
                    {
                        writer.WriteElementString($"maxTrailers", $"{truck.maxTrailers}");
                    }
                    else if (car is Bus bus)
                    {
                        writer.WriteElementString($"maxPassengers", $"{bus.maxPassengers}");
                    }
                    else if (car is Scooter scooter)
                    {
                        writer.WriteElementString($"luggageVolume", $"{scooter.luggageVolume}");
                    }

                    writer.WriteStartElement($"Transmission");
                    writer.WriteElementString("Type", $"{car.transmission.type}");
                    writer.WriteElementString("gearsNumber", $"{car.transmission.gearsNumber}");
                    writer.WriteElementString("manufacture", $"{car.transmission.manufacture}");
                    writer.WriteEndElement();

                    writer.WriteStartElement("Chassis");
                    writer.WriteElementString("numberOfWhhels", $"{car.chassis.wheelsNumber}");
                    writer.WriteElementString("serialNumber", $"{car.chassis.chassisSerial}");
                    writer.WriteElementString("maxWeight", $"{car.chassis.maxWeight}");
                    writer.WriteEndElement();

                    writer.WriteStartElement("Engine");
                    writer.WriteElementString("power", $"{car.engine.power}");
                    writer.WriteElementString("volume", $"{car.engine.volume}");
                    writer.WriteElementString("type", $"{car.engine.type}");
                    writer.WriteElementString("SerialNumber", $"{car.engine.serialNumber}");
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
                writer.Flush();
            }
        }
    }
}
