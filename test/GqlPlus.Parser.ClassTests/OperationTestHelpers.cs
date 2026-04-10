using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus;

public static class OperationTestHelpers
{
  public static IAstDirective[] Directives(this string[] directives)
    => [.. directives.Select(d => new DirectiveAst(AstNulls.At, d))];

  public static IGqlpSelection[] Fields(this string[] fields)
    => [.. fields.Select(f => new FieldAst(AstNulls.At, f))];

  public static IGqlpArg[] ArgList(this string value)
    => [new ArgAst(AstNulls.At, value), new ArgAst(value.FieldKey())];

  public static IAstFields<IGqlpArg> ArgObject(this string value, string key)
  {
    IAstFieldKey keyAst = key.FieldKey();
    IAstFieldKey valueAst = value.FieldKey();

    return key == value
      ? new FieldsAst<IGqlpArg>(keyAst, new ArgAst(AstNulls.At, value))
      : new FieldsAst<IGqlpArg>() { [keyAst] = new ArgAst(AstNulls.At, value), [valueAst] = new ArgAst(keyAst) };
  }
}
