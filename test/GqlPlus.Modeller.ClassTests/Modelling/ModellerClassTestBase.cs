namespace GqlPlus.Modelling;

public class ModellerClassTestBase
  : SubstituteBase
{
  protected IMap<TypeKindModel> TypeKinds { get; } = For<IMap<TypeKindModel>>();

  internal static IGqlpFieldKey FKFor(string text)
  {
    IGqlpFieldKey fieldKey = For<IGqlpFieldKey>();
    fieldKey.Text.Returns(text);
    return fieldKey;
  }

  internal static IGqlpConstant CFor(string text)
  {
    IGqlpFieldKey fieldKey = FKFor(text);
    IGqlpConstant constant = For<IGqlpConstant>();
    constant.Value.Returns(fieldKey);
    return constant;
  }

  internal static IGqlpFields<T> FieldsFor<T>(string key, T value)
    where T : IGqlpAbbreviated
  {
    IGqlpFieldKey fieldKey = FKFor(key);
    Dictionary<IGqlpFieldKey, T> dict = new() { [fieldKey] = value };
    IGqlpFields<T> fields = For<IGqlpFields<T>>();
    fields.Count.Returns(1);
    fields.GetEnumerator().Returns(dict.GetEnumerator());
    return fields;
  }

  internal void TypeKindIs(string key, TypeKindModel typeKind)
  {
    TypeKinds.TryGetValue(key, out Arg.Any<TypeKindModel>())
        .Returns(x => {
          x[1] = typeKind;
          return true;
        });
  }
}
