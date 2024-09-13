namespace gonka;
using Utils;
using Models;

public class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Введите дистанцию гонки:");

        var step = 1000;
        var min = 1;
        var max = 10;

        Enumerable
            .Range(min, max)
            .Select(x => $"{x}) {x * step} м")
            .ToList()
            .ForEach(Console.WriteLine);

        var dist = Parsing.ParseInt(min, max) * 1000;
        Console.WriteLine($"Выбранная дистанция: {dist}");
        Console.WriteLine("Вид гонки:");
        var raceTypes = Enum.GetValues(typeof(RaceType)).Cast<RaceType>().ToArray();

        for (var i = 0; i < raceTypes.Length; i++)
        {
            Console.WriteLine($"{i + 1}) {EnumExtensions.GetDescription(raceTypes[i])}");
        }

        int raceTypeNum = Parsing.ParseInt(1, raceTypes.Length) - 1;
        RaceType raceType = raceTypes[raceTypeNum];
        Console.WriteLine($"Выбранный вид: {EnumExtensions.GetDescription(raceType)}");

        var stupa = new FlyingTransport("Ступа бабы яги", 50, (speed, t) => speed);
        var metla = new FlyingTransport("Метла", 40, (speed, t) => speed);
        var sapogi = new GroundedTransport("Сапоги скороходы", 100, 10, (numberOfStop) => numberOfStop);
        var kareta = new GroundedTransport("Карета-тыква", 110, 20, (numberOfStop) => numberOfStop * 2);
        var kover = new FlyingTransport("Ковер-самолет", 100, (speed, t) => 2 * t);
        var izba = new GroundedTransport("Избушка на курьих ножках", 100, 10, (numberOfStop) => numberOfStop * 3);
        var cent = new GroundedTransport("Кентавр", 100, 10, (numberOfStop) => numberOfStop * 3);
        var korabl = new FlyingTransport("Летучий корабль", 100, (speed, t) => 2 * t);

        List<Transport> transportList = [stupa, metla, sapogi, kareta, kover, izba, cent, korabl];

        var race = new Race(dist, raceType);
        // now choose transport
        //
        Console.WriteLine("Выбор транспорта:");

        var notExit = true;
        while (notExit)
        {
            for (var i = 0; i < transportList.Count; i++)
            {
                var t = transportList[i];
                var reg = race.IsRegistered(t);
                var ok = reg ? "✅" : "❌";
                string result = $"{i + 1}) {t.ToString()} {ok}";
                Console.WriteLine(result);
            }
            Console.WriteLine($"{transportList.Count + 1}) готово");

            int chosenTransportIndex = Parsing.ParseInt(1, transportList.Count + 1) - 1;
            if (transportList.Count  == chosenTransportIndex) // ready
            {
                if (race.All.Count >= 2)
                {
                    notExit = false;
                }
                else
                {
                    Console.WriteLine("Минимум 2 транспорта. Выберите еще.");
                }
            }
            else
            {
                if (race.IsRegistered(transportList[chosenTransportIndex]))
                {
                    race.UnregisterTransport(transportList[chosenTransportIndex]);
                }
                else
                {
                    try
                    {
                        race.RegisterTransport(transportList[chosenTransportIndex]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        Console.WriteLine("Выбранный транспорт: ");

        for (var i = 0; i < race.All.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {race.All[i].ToString()})");
        }

        Console.WriteLine("Стартуем ");
        // transport is chosen
        Transport? winner = null;

        Bar bar = new Bar(race.All, race.Dist);
        Console.Clear();
        while (winner == null)
        {
            Thread.Sleep(1000);
            foreach (var t in race.All)
            {
                t.move();
                // Console.WriteLine(t.ToString());
                bar.ShowAll();

            }
            winner = race.GetWinner();
        }
        Console.WriteLine($"\nПобедитель - {winner.Name}");

    }
}
