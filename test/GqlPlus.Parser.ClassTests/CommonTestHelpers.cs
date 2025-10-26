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
      ? new AstFields<IGqlpConstant>(keyAst, new ConstantAst(valueAst))
      : new AstFields<IGqlpConstant>() { [keyAst] = new ConstantAst(valueAst), [valueAst] = new ConstantAst(keyAst) };
  }

  public static TokenMessage ParseMessage(this string message)
    => new(AstNulls.At, message);

  public static IGqlpModifier[] TestMods()
    => [ModifierAst.List(AstNulls.At), ModifierAst.Optional(AstNulls.At)];
}
