public class FlyingTransport : Transport
{

  public FlyingTransport(string name, int speed, Func<int, int, int> speedUpFormula)
    : base(name, speed, Models.RaceType.AIR)
  {
    this.SpeedUpFormula = speedUpFormula;
  }

  public Func<int, int, int> SpeedUpFormula { get; }

  public override void move()
  {
    this.Mileage += Speed;
    Speed = SpeedUpFormula(Speed, MovingTime);
    this.MovingTime++;
  }

  public override string ToString()
  {
    return $"💨 Имя: {Name}, Скорость: {Speed}, Всего: {Mileage}";
  }
}
