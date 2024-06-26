using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus;

public static class OperationTestHelpers
{
  public static IGqlpDirective[] Directives(this string[] directives)
    => [.. directives.Select(d => new DirectiveAst(AstNulls.At, d))];

  public static IGqlpSelection[] Fields(this string[] fields)
    => [.. fields.Select(f => new FieldAst(AstNulls.At, f))];

  public static IGqlpArgument[] Arguments(this string[] values)
    => [.. values.Select(l => new ArgumentAst(l.FieldKey()))];

  public static IGqlpArgument[] ArgumentList(this string value)
    => [new ArgumentAst(AstNulls.At, value), new ArgumentAst(value.FieldKey())];

  public static IGqlpFields<IGqlpArgument> ArgumentObject(this string value, string key)
  {
    IGqlpFieldKey keyAst = key.FieldKey();
    IGqlpFieldKey valueAst = value.FieldKey();

    return key == value
      ? new AstFields<IGqlpArgument>() { [keyAst] = new ArgumentAst(AstNulls.At, value) }
      : new AstFields<IGqlpArgument>() { [keyAst] = new ArgumentAst(AstNulls.At, value), [valueAst] = new ArgumentAst(keyAst) };
  }
}
