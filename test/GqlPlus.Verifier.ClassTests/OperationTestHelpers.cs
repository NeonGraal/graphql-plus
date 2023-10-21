using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.ClassTests;

internal static class OperationTestHelpers
{
  public static DirectiveAst[] Directives(this string directive)
    => new DirectiveAst[] { new(AstNulls.At, directive) };

  public static IAstSelection[] Fields(this string field)
    => new FieldAst[] { new(AstNulls.At, field) };

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
