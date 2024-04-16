using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema.Types;

public sealed class ParseScalarBooleanTests(
  Parser<AstScalar>.D parser
) : BaseScalarTests<string>
{
  internal override IBaseScalarChecks<string> ScalarChecks => _checks;

  private readonly ParseScalarBooleanChecks _checks = new(parser);
}

internal sealed class ParseScalarBooleanChecks(
  Parser<AstScalar>.D parser
) : BaseScalarChecks<string, AstScalar>(parser, ScalarDomain.Boolean)
{
  protected internal override AstScalar<ScalarTrueFalseAst> NamedFactory(string input)
    => new(AstNulls.At, input, ScalarDomain.Boolean, []);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{boolean}";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}
