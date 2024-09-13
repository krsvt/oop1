using Models;

public class Race
{
  public Race(int dist, RaceType raceType)
  {
    this.Dist = dist;
    this.All = new List<Transport>();
    this.RaceType = raceType;
  }

  public void RegisterTransport(Transport transport)
  {
    if (this.RaceType == RaceType.ALL || transport.RaceType == this.RaceType) {
      this.All.Add(transport);
    } else {
      throw new Exception($"Нужно выбрать транспорт который {this.RaceType.ToString()}");
    }
  }


  public void UnregisterTransport(Transport transport)
  {
    this.All.Remove(transport);
  }

  public int Dist { get; private set; }
  public List<Transport> All { get; private set; }
  public RaceType RaceType { get; }

  public Transport? GetWinner()
  {
    return All.Where(t => t.Mileage >= Dist).FirstOrDefault();
  }

  public bool IsRegistered(Transport transport){
    return this.All.Contains(transport);
  }
}
