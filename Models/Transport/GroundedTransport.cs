public class GroundedTransport : Transport
{
    // restFormula = stayNumber => 5
    // restFormula = stayNumber => stayNumber * 2
    // etc
    public GroundedTransport
        (string name, int speed, int moveTimeSecUntilNextStop, Func<int, int> restFormula)
        : base(name, speed, Models.RaceType.GROUND)
    {
        this.MoveTimeSecUntilNextStop = moveTimeSecUntilNextStop;
        this.RestFormula = restFormula;
        this.Resting = false;
        this.RestingTime = 0;
        this.StayNumber = 0;
    }

    public int MoveTimeSecUntilNextStop { get; }
    public Func<int, int> RestFormula { get; }
    public bool Resting { get; private set; }
    public int RestingTime { get; private set; }
    public int StayNumber { get; private set; }


    public override string ToString()
    {
        return $"🛞 Имя: {Name}, Начальная Скорость: {Speed}, Остановок: {StayNumber}, Всего: {Mileage}";
    }

    public override void move()
    {
        this.MovingTime++;
        if (this.Resting)
        {
            this.RestingTime--;
            if (this.RestingTime == 0)
            {
                this.Resting = false;
            }
        }
        else
        {
            this.Mileage += Speed;
            // time to stop
            if (MovingTime % MoveTimeSecUntilNextStop == 0)
            {
                this.StayNumber++;
                this.Resting = true;
                this.RestingTime = this.RestFormula(this.StayNumber);
            }
        }
    }
}
