namespace GqlPlus.Building.Schema.Objects;

public interface IObjEnumBuilder
  : IMockBuilder
{
  string Name { get; }
  void SetEnumValue(IGqlpEnumValue enumValue);
}

public static class ObjEnumBuilderHelper
{
  public static T WithObjEnum<T>(this T builder, IGqlpEnumValue enumValue)
    where T : IObjEnumBuilder
    => builder.FluentAction(b => b.SetEnumValue(enumValue));
  public static T WithObjEnum<T>(this T builder, string enumLabel)
    where T : IObjEnumBuilder
    => builder.FluentAction(b => b.SetEnumValue(builder.EnumValue(b.Name, enumLabel)));
}
