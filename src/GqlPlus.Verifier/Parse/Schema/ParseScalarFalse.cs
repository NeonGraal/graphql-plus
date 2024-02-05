using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarFalse(
  Parser<ScalarFalseAst>.DA items
) : ParseScalarItem<ScalarFalseAst>(items)
{
  public override ScalarKind Kind => ScalarKind.Boolean;

  protected override IResult<ScalarDefinition> ParseMembers(Tokenizer tokens, string label, ScalarDefinition result)
    => tokens.End(label, () => result);


  public override IResult<ScalarFalseAst> Parse<TContext>(TContext tokens, string label)
    => 0.Empty<ScalarFalseAst>();

  protected override void ApplyItems(ScalarDefinition result, ScalarFalseAst[] items)
  { }
}
