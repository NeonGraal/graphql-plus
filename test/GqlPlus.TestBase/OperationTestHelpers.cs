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

  public static ArgumentAst[] Arguments(this string[] values)
    => [.. values.Select(l => new ArgumentAst(l.FieldKey()))];

  public static ArgumentAst[] ArgumentList(this string value)
    => [new(AstNulls.At, value), new(value.FieldKey())];

  public static AstFields<ArgumentAst> ArgumentObject(this string value, string key)
  {
    IGqlpFieldKey keyAst = key.FieldKey();
    IGqlpFieldKey valueAst = value.FieldKey();

    return key == value
      ? new() { [keyAst] = new(AstNulls.At, value) }
      : new() { [keyAst] = new(AstNulls.At, value), [valueAst] = new(keyAst) };
  }
}
