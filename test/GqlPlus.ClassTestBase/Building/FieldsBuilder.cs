using GqlPlus.Ast;

namespace GqlPlus.Building;

public sealed class FieldsBuilder<T>
  : IMockBuilder
{
  internal Dictionary<IAstFieldKey, T> _fields = [];

  public IAstFields<T> AsFields
  {
    get {
      IAstFields<T> fields = Substitute.For<IAstFields<T>>();
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
