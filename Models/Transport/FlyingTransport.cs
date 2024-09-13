public class FlyingTransport : Transport
{

  protected FlyingTransport(string name, int speed, Func<int, int, int> speedUpFormula) : base(name, speed)
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
}
