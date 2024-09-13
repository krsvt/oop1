public class Bar
{
  public Bar(List<Transport> transports, int total)
  {
    this.transports = transports;
    this.total = total;
    this.PadRight = transports.Select(t => t.Name.Length).Max();
  }

  public List<Transport> transports { get; }
  public int total { get; }
  public int PadRight { get; private set; }

  int barWidth = 100;
  public void ShowAll()
  {
    for (int bar = 0; bar < transports.Count; bar++)
    {
      var cur = transports[bar];
      int percentage = (int)((double)cur.Mileage * 100 / (double)total);
      string barString = new string('=', Math.Min(percentage, barWidth)) +
        new string(' ', barWidth - Math.Min(percentage, barWidth));

      Console.SetCursorPosition(0, bar);
      Console.Write($"{cur.Name.PadRight(PadRight)} [{barString}] {cur.Mileage} м, {cur.Speed}/с");
    }
  }
}
