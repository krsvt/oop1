public abstract class Transport : ITransport
{
  public Transport(string name, int speed)
  {
    Name = name;
    Speed = speed;
    Mileage = 0;
    MovingTime = 0;
  }

  public string Name { get; set; }
  public int Speed { set; get; }
  public int Mileage { set; get; }
  public int MovingTime { set; get; }
  public abstract void move();
}
