namespace GqlPlus;

public static class CommonTestHelpers
{
  public static IGqlpFieldKey FieldKey(this string value)
    => new FieldKeyAst(AstNulls.At, "", value);

  public static IGqlpConstant[] ConstantList(this string value)
    => [
      new ConstantAst(value.FieldKey()),
      new ConstantAst(value.FieldKey())
    ];

  public static IGqlpFields<IGqlpConstant> ConstantObject(this string value, string key)
  {
    IGqlpFieldKey keyAst = key.FieldKey();
    IGqlpFieldKey valueAst = value.FieldKey();

    return key == value
      ? new FieldsAst<IGqlpConstant>(keyAst, new ConstantAst(valueAst))
      : new FieldsAst<IGqlpConstant>() { [keyAst] = new ConstantAst(valueAst), [valueAst] = new ConstantAst(keyAst) };
  }

  public static IGqlpModifier[] TestMods()
    => [ModifierAst.List(AstNulls.At), ModifierAst.Optional(AstNulls.At)];

  public static IGqlpModifier[] TestCollections()
    => [ModifierAst.List(AstNulls.At), ModifierAst.Dict(AstNulls.At, "String", false)];
}
