using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.ClassTests;

internal static class OperationTestsHelpers
{
  internal const int Repeats = 20;

  internal const string IdentifierPattern = @"[A-Za-z][A-Za-z0-9_]*";
  internal const string PunctuationPattern = @"[!#-&(-+.:<-@[-^`{-~]";

  public static DirectiveAst[] Directives(this string directive)
    => new DirectiveAst[] { new(directive) };

  public static SelectionAst[] Fields(this string field)
    => new FieldAst[] { new(field) };

  public static ConstantAst[] ConstantList(this string label)
    => new ConstantAst[] { new("", label), new("", label) };

  public static ConstantAst.ObjectAst ConstantObject(this string label, string key)
  {
    var keyAst = new FieldKeyAst("", key);
    var labelAst = new FieldKeyAst("", label);
    return new ConstantAst.ObjectAst { [keyAst] = labelAst, [labelAst] = keyAst };
  }
}
