using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
  public static string GetDescription(this Enum value)
  {
    FieldInfo field = value.GetType().GetField(value.ToString());
    DescriptionAttribute attr =
        (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
    return attr == null ? value.ToString() : attr.Description;
  }
}
