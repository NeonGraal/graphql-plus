using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarBooleanTests(
  Parser<AstScalar>.D parser
) : BaseScalarTests<string>
{
  internal override IBaseScalarChecks<string> ScalarChecks => _checks;

  private readonly ParseScalarBooleanChecks _checks = new(parser);
}

internal sealed class ParseScalarBooleanChecks(
  Parser<AstScalar>.D parser
) : BaseScalarChecks<string, AstScalar>(parser, ScalarKind.Boolean)
{
  protected internal override AstScalar<ScalarFalseAst> AliasedFactory(string input)
    => new(AstNulls.At, input, ScalarKind.Boolean, []);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{boolean}";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}
