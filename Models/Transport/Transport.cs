using Models;

public abstract class Transport : ITransport
{
  public Transport(string name, int speed, RaceType raceType)
  {
    Name = name;
    Speed = speed;
    Mileage = 0;
    MovingTime = 0;
    RaceType = raceType;
  }

  public string Name { get; set; }
  public int Speed { set; get; }
  public int Mileage { set; get; }
  public int MovingTime { set; get; }
  public RaceType RaceType { get; private set; }

  public abstract void move();
}
