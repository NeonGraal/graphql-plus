namespace GqlPlus;

public static class CommonTestHelpers
{
  public static IAstFieldKey FieldKey(this string value)
    => new FieldKeyAst(AstNulls.At, "", value);

  public static IAstConstant[] ConstantList(this string value)
    => [
      new ConstantAst(value.FieldKey()),
      new ConstantAst(value.FieldKey())
    ];

  public static IAstFields<IAstConstant> ConstantObject(this string value, string key)
  {
    IAstFieldKey keyAst = key.FieldKey();
    IAstFieldKey valueAst = value.FieldKey();

    return key == value
      ? new FieldsAst<IAstConstant>(keyAst, new ConstantAst(valueAst))
      : new FieldsAst<IAstConstant>() { [keyAst] = new ConstantAst(valueAst), [valueAst] = new ConstantAst(keyAst) };
  }

  public static IAstModifier[] TestMods()
    => [ModifierAst.List(AstNulls.At), ModifierAst.Optional(AstNulls.At)];

  public static IAstModifier[] TestCollections()
    => [ModifierAst.List(AstNulls.At), ModifierAst.Dict(AstNulls.At, "String", false)];
}
