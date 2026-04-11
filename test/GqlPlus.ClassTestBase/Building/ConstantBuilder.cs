using GqlPlus.Ast;

namespace GqlPlus.Building;

public class ConstantBuilder
  : ErrorBuilder
{
  internal IAstFieldKey? _value;
  internal IAstConstant[] _values = [];
  internal IAstFields<IAstConstant> _fields;

  public ConstantBuilder()
  {
    Add<IAstConstant>();
    _fields = new FieldsBuilder<IAstConstant>().AsFields;
  }

  protected new T Build<T>()
    where T : class, IAstConstant
  {
    T result = base.Build<T>();
    result.Value.Returns(_value);
    result.Values.Returns(_values);
    result.Fields.Returns(_fields);
    return result;
  }

  public IAstConstant AsConstant
    => Build<IAstConstant>();
}

public static class ConstantBuilderHelper
{
  public static T WithText<T>(this T builder, string text)
    where T : ConstantBuilder
    => builder.WithValue(builder.FieldKey(text));

  public static T WithValue<T>(this T builder, IAstFieldKey value)
    where T : ConstantBuilder
    => builder.FluentAction(b => b._value = value);

  public static T WithValues<T>(this T builder, IAstConstant[] values)
    where T : ConstantBuilder
    => builder.FluentAction(b => b._values = values);
  public static T WithValues<T>(this T builder, string[] values)
    where T : ConstantBuilder
    => builder.WithValues([.. values.Select(builder.Constant)]);

  public static T WithFields<T>(this T builder, IAstFields<IAstConstant> fields)
    where T : ConstantBuilder
    => builder.FluentAction(b => b._fields = fields);
  public static T WithField<T>(this T builder, string key, IAstConstant value)
    where T : ConstantBuilder
    => builder.WithFields(builder.Fields(key, value));
  public static T WithField<T>(this T builder, string key, string value)
    where T : ConstantBuilder
    => builder.WithField(key, builder.Constant(value));
}
