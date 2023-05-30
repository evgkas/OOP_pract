using OOP_pract;
using OOP_pract.Cars;
using OOP_pract.ExceptionHandler;
using OOP_pract.Parts;

public class Program
{
    private static void Main()
    {
        Engine carEngine = new(150, 1.4, "diesel", "000001eng");
        Transmission carTransmission = new("auto", 6, "BMW");
        Chassis carChasssis = new(4, "123456ch", 2000);
        Engine truckEngine = new(400, 4, "diesel", "000002eng");
        Transmission truckTransmission = new("auto", 8, "Mitsubishi");
        Chassis truckChassis = new(6, "111112ch", 10000);
        Engine busEngine = new(300, 3, "gas", "000003eng");
        Transmission busTransmission = new("manual", 10, "Reno");
        Chassis busChassis = new(6, "111113ch", 5000);
        Engine scooterEngine = new(50, 0.040, "gas", "000005eng");
        Transmission scooterTransmission = new("auto", 4, "KIA");
        Chassis scooterChassis = new(2, "111115ch", 150);

        var cars = new List<Car>
        {
            new Car("Audi", carEngine, carTransmission, carChasssis),
            new Truck("MAN", 1, truckEngine, truckTransmission, truckChassis),
            new Bus("Reno", 50, busEngine, busTransmission, busChassis),
            new Car("Skoda", new Engine(170, 1.8, "gas", "000004eng"), new Transmission("auto", 6, "Skoda"), new
            Chassis(4, "111114ch", 3000)),
            new Scooter("KIA", 0, scooterEngine, scooterTransmission, scooterChassis),
            new Truck("Mercedes", 0, new Engine(500, 4.5, "gas", "000006eng"), new Transmission("manual", 8, "Mercedes"),
            new Chassis(6, "111116ch", 10000)),
        };

        XmlCreator creator = new();
        creator.OrderByTransmissionType(cars, "carsOrderedByTransmission.xml");
        creator.BusAndTrucksEnginesInfo(cars, "busAndTrucksEngines.xml");
        creator.CarsEngineVolumeAbove(cars, 1.5, "orderedByVolumeCars.xml");

        //exception part below

        Car testCar2 = new("VW", carEngine, carTransmission, carChasssis);
        try
        {
            foreach (var car in cars)
            {
                if (car.engine.serialNumber == testCar2.engine.serialNumber)
                {
                    throw new AddException("Car can not be added to List: car with this EngineSerial already is " +
                        "in the List");
                }
            }

            cars.Add(testCar2);
        }
        catch (AddException) { }

        try
        {
            int idToFind = 111111;
            var carToUpdate = cars.FirstOrDefault(c => c.id == idToFind);

            if (carToUpdate != null)
            {
                carToUpdate.transmission.manufacture = "BMW";
                Console.WriteLine("Car updated");
            }
            else
            {
                throw new UpdateAutoException($"Cant find car with id = {idToFind}");
            }

            idToFind = 0;
            carToUpdate = cars.FirstOrDefault(c => c.id == idToFind);

            if (carToUpdate != null)
            {
                carToUpdate.transmission.manufacture = "BMW";
                Console.WriteLine("Car updated");
            }
            else
            {
                throw new UpdateAutoException($"Cant find car with id = {idToFind}");
            }
        }
        catch (UpdateAutoException) { }

        var idsToRemove = new List<int>
            {
                0,
                111112,
                123537547,
            };
        try
        {
            foreach (var idToRemove in idsToRemove)
            {
                var carToRemove = cars.FirstOrDefault(c => c.id == idToRemove);

                if (carToRemove != null)
                {
                    cars.Remove(carToRemove);
                    Console.WriteLine($"Car with id = {idToRemove} deleted");
                }
                else
                {
                    throw new RemoveAutoException($"Cars with id = {idToRemove} is not exist");
                }
            }
        }
        catch (RemoveAutoException) { }

        string parameter = "volume";
        string value = Convert.ToString(1.4);
        List<Car> findedCars = getAutoByParameter(parameter, value);
        parameter = "Undefined";
        findedCars = getAutoByParameter(parameter, value);

        List<Car> getAutoByParameter(string parameter, string value)
        {
            var result = new List<Car>();
            parameter = parameter.ToLower();

            try
            {
                foreach (var car in cars)
                {
                    switch (parameter)
                    {
                        case "id":
                            if (car.id == Convert.ToInt32(value))
                            {
                                result.Add(car);
                            }

                            break;
                        case "transmissiontype":
                            if (car.transmission.type.ToLower() == value.ToLower())
                            {
                                result.Add(car);
                            }

                            break;
                        case "gearsnumber":
                            if (car.transmission.gearsNumber == Convert.ToUInt32(value))
                            {
                                result.Add(car);
                            }

                            break;
                        case "manufacture":
                            if (car.transmission.manufacture.ToLower() == value.ToLower())
                            {
                                result.Add(car);
                            }

                            break;
                        case "wheelsnumber":
                            if (car.chassis.wheelsNumber == Convert.ToUInt32(value))
                            {
                                result.Add(car);
                            }

                            break;
                        case "chassisserial":
                            if (car.chassis.chassisSerial.ToLower() == value.ToLower())
                            {
                                result.Add(car);
                            }

                            break;
                        case "maxweight":
                            if (car.chassis.maxWeight == Convert.ToDouble(value))
                            {
                                result.Add(car);
                            }

                            break;
                        case "power":
                            if (car.engine.power == Convert.ToDouble(value))
                            {
                                result.Add(car);
                            }

                            break;
                        case "volume":
                            double volumeValue;
                            if ((double.TryParse(value, out volumeValue)) && (car.engine.volume == volumeValue)) //проверить
                            {
                                result.Add(car);
                            }

                            break;
                        case "enginetype":
                            if (car.engine.type.ToLower() == value.ToLower())
                            {
                                result.Add(car);
                            }

                            break;
                        case "engineserial":
                            if (car.engine.serialNumber.ToLower() == value.ToLower())
                            {
                                result.Add(car);
                            }

                            break;
                        case "maxtrailers":
                            if (car is Truck truck)
                            {
                                if (truck.maxTrailers == Convert.ToInt32(value))
                                {
                                    result.Add(car);
                                }
                            }

                            break;
                        case "maxpassengers":
                            if (car is Bus bus)
                            {
                                if (bus.maxPassengers == Convert.ToInt32(value))
                                {
                                    result.Add(car);
                                }
                            }

                            break;
                        case "luggagevolume":
                            if (car is Scooter scooter)
                            {
                                if (scooter.luggageVolume == Convert.ToInt32(value))
                                {
                                    result.Add(car);
                                }
                            }

                            break;
                        default:
                            throw new GetAutoByParameterException($"There is no {parameter} parameter");
                    }
                }

                if (result.Capacity == 0)
                {
                    Console.WriteLine($"These no auto with {parameter} = {value}");
                }

                foreach (var car in result)
                {
                    car.Print();    //print information about finded auto
                }

                return result;
            }
            catch (GetAutoByParameterException)
            {
                return result;
            }
        }
    }
}
