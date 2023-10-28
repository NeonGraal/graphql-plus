using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.ClassTests;

internal static class OperationTestHelpers
{
  public static DirectiveAst[] Directives(this string[] directives)
    => directives.Select(d => new DirectiveAst(AstNulls.At, d)).ToArray();

  public static IAstSelection[] Fields(this string[] fields)
    => fields.Select(f => new FieldAst(AstNulls.At, f)).ToArray();

  public static ArgumentAst[] Arguments(this string[] labels)
    => labels.Select(l => new ArgumentAst(new FieldKeyAst(AstNulls.At, "", l))).ToArray();

  public static ArgumentAst[] ArgumentList(this string label)
    => new ArgumentAst[] { new(AstNulls.At, label), new FieldKeyAst(AstNulls.At, "", label) };

  public static ArgumentAst.ObjectAst ArgumentObject(this string label, string key)
  {
    var keyAst = new FieldKeyAst(AstNulls.At, "", key);
    var labelAst = new FieldKeyAst(AstNulls.At, "", label);

    return key == label
      ? new ArgumentAst.ObjectAst { [keyAst] = new(AstNulls.At, label) }
      : new ArgumentAst.ObjectAst { [keyAst] = new(AstNulls.At, label), [labelAst] = keyAst };
  }
}
