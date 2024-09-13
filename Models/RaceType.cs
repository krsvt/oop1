namespace Models;

using System.ComponentModel;

public enum RaceType
{
  [Description("Воздушный")]
  AIR,

  [Description("Наземный")]
  GROUND,

  [Description("Все")]
  ALL
}
