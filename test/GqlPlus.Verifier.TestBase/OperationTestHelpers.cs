using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier;

public static class OperationTestHelpers
{
  public static DirectiveAst[] Directives(this string[] directives)
    => directives.Select(d => new DirectiveAst(AstNulls.At, d)).ToArray();

  public static IAstSelection[] Fields(this string[] fields)
    => fields.Select(f => new FieldAst(AstNulls.At, f)).ToArray();

  public static ArgumentAst[] Arguments(this string[] values)
    => values.Select(l => new ArgumentAst(l.FieldKey())).ToArray();

  public static ArgumentAst[] ArgumentList(this string value)
    => new ArgumentAst[] { new(AstNulls.At, value), value.FieldKey() };

  public static AstObject<ArgumentAst> ArgumentObject(this string value, string key)
  {
    var keyAst = key.FieldKey();
    var valueAst = value.FieldKey();

    return key == value
      ? new() { [keyAst] = new(AstNulls.At, value) }
      : new() { [keyAst] = new(AstNulls.At, value), [valueAst] = keyAst };
  }
}
