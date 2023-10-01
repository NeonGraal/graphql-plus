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
}
