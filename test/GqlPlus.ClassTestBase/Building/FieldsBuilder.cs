namespace GqlPlus.Building;

public sealed class FieldsBuilder<T>
  : IMockBuilder
{
  internal Dictionary<IGqlpFieldKey, T> _fields = [];

  public IGqlpFields<T> AsFields
  {
    get {
      IGqlpFields<T> fields = Substitute.For<IGqlpFields<T>>();
      fields.Count.Returns(_fields.Count);
      fields.GetEnumerator().Returns(_fields.GetEnumerator());
      return fields;
    }
  }
}

public static class FieldsBuilderHelper
{
  public static FieldsBuilder<T> WithField<T>(this FieldsBuilder<T> builder, string key, T value)
    => builder.FluentAction(b => b._fields[builder.FieldKey(key)] = value);
}
