namespace Utils;

public class Parsing
{
  public static int ParseInt(int min, int max)
  {
    int ans = 1;
    bool valid = false;
    bool minmax = false;

    while (!valid && !minmax)
    {
      var input = Console.ReadLine();
      if (input != null)
      {
        if (int.TryParse((string)input, out ans))
        {
          if (ans < min)
          {
            Console.WriteLine($"Ошибка: число должно быть больше или равно {min}");
          }
          else if (ans > max)
          {
            Console.WriteLine($"Ошибка: число должно быть меньше или равно {max}");
          }
          else
          {
            valid = true;
          }
        }
        else
        {
          Console.WriteLine("Ошибка: введено не число. Попробуйте снова.");
        }
      }
    }
    return ans;
  }
}
