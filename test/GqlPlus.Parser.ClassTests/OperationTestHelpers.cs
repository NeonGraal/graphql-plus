using GqlPlus.Ast.Operation;

namespace GqlPlus;

public static class OperationTestHelpers
{
  public static IAstDirective[] Directives(this string[] directives)
    => [.. directives.Select(d => new DirectiveAst(AstNulls.At, d))];

  public static IAstSelection[] Fields(this string[] fields)
    => [.. fields.Select(f => new FieldAst(AstNulls.At, f))];

  public static IAstArg[] ArgList(this string value)
    => [new ArgAst(AstNulls.At, value), new ArgAst(value.FieldKey())];

  public static IAstFields<IAstArg> ArgObject(this string value, string key)
  {
    IAstFieldKey keyAst = key.FieldKey();
    IAstFieldKey valueAst = value.FieldKey();

    return key == value
      ? new FieldsAst<IAstArg>(keyAst, new ArgAst(AstNulls.At, value))
      : new FieldsAst<IAstArg>() { [keyAst] = new ArgAst(AstNulls.At, value), [valueAst] = new ArgAst(keyAst) };
  }
}
