using GqlPlus.Ast;

namespace GqlPlus.Building;

public class FieldKeyBuilder
  : ErrorBuilder
{
  internal string? _text;
  internal IAstEnumValue? _enumValue;

  public FieldKeyBuilder()
    => Add<IAstFieldKey>();

  protected new T Build<T>()
    where T : class, IAstFieldKey
  {
    T result = base.Build<T>();
    result.Text.Returns(_text);
    result.EnumValue.Returns(_enumValue);
    return result;
  }

  public IAstFieldKey AsFieldKey
    => Build<IAstFieldKey>();
}

public static class FieldKeyBuilderHelper
{
  public static T WithText<T>(this T builder, string text)
    where T : FieldKeyBuilder
    => builder.FluentAction(b => b._text = text);

  public static T WithEnumValue<T>(this T builder, IAstEnumValue enumValue)
    where T : FieldKeyBuilder
    => builder.FluentAction(b => b._enumValue = enumValue);
  public static T WithEnumValue<T>(this T builder, string enumType, string enumLabel)
    where T : FieldKeyBuilder
    => builder.WithEnumValue(builder.EnumValue(enumType, enumLabel));
}
