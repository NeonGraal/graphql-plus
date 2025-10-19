namespace GqlPlus.Building;

public class ConstantBuilder
  : ErrorBuilder
{
  internal IGqlpFieldKey? _value;
  internal IGqlpConstant[] _values = [];
  internal IGqlpFields<IGqlpConstant> _fields;

  public ConstantBuilder()
  {
    Add<IGqlpConstant>();
    _fields = new FieldsBuilder<IGqlpConstant>().AsFields;
  }

  protected new T Build<T>()
    where T : class, IGqlpConstant
  {
    T result = base.Build<T>();
    result.Value.Returns(_value);
    result.Values.Returns(_values);
    result.Fields.Returns(_fields);
    return result;
  }

  public IGqlpConstant AsConstant
    => Build<IGqlpConstant>();
}

public static class ConstantBuilderHelper
{
  public static T WithText<T>(this T builder, string text)
    where T : ConstantBuilder
    => builder.WithValue(builder.FieldKey(text));

  public static T WithValue<T>(this T builder, IGqlpFieldKey value)
    where T : ConstantBuilder
    => builder.FluentAction(b => b._value = value);

  public static T WithValues<T>(this T builder, IEnumerable<IGqlpConstant> values)
    where T : ConstantBuilder
    => builder.FluentAction(b => b._values = [.. values]);
  public static T WithValues<T>(this T builder, IEnumerable<string> values)
    where T : ConstantBuilder
    => builder.WithValues(values.Select(builder.Constant));

  public static T WithFields<T>(this T builder, IGqlpFields<IGqlpConstant> fields)
    where T : ConstantBuilder
    => builder.FluentAction(b => b._fields = fields);
  public static T WithField<T>(this T builder, string key, IGqlpConstant value)
    where T : ConstantBuilder
    => builder.WithFields(builder.Fields(key, value));
  public static T WithField<T>(this T builder, string key, string value)
    where T : ConstantBuilder
    => builder.WithField(key, builder.Constant(value));
}
