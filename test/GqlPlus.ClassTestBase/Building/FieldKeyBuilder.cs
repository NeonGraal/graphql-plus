namespace GqlPlus.Building;

public class FieldKeyBuilder
  : ErrorBuilder
{
  internal string? _text;
  internal IGqlpEnumValue? _enumValue;

  public FieldKeyBuilder()
    => Add<IGqlpFieldKey>();

  protected new T Build<T>()
    where T : class, IGqlpFieldKey
  {
    T result = base.Build<T>();
    result.Text.Returns(_text);
    result.EnumValue.Returns(_enumValue);
    return result;
  }

  public IGqlpFieldKey AsFieldKey
    => Build<IGqlpFieldKey>();
}

public static class FieldKeyBuilderHelper
{
  public static T WithText<T>(this T builder, string text)
    where T : FieldKeyBuilder
    => builder.FluentAction(b => b._text = text);

  public static T WithEnumValue<T>(this T builder, IGqlpEnumValue enumValue)
    where T : FieldKeyBuilder
    => builder.FluentAction(b => b._enumValue = enumValue);
  public static T WithEnumValue<T>(this T builder, string enumType, string enumLabel)
    where T : FieldKeyBuilder
    => builder.WithEnumValue(builder.EnumValue(enumType, enumLabel));
}
