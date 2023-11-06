using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class BaseAliasedChecks<I, A>
  : OneChecks<SchemaParser, A>, IBaseAliasedChecks<I>
  where A : AstAliased
{
  protected BaseAliasedChecks(One one,
    [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(tokens => new SchemaParser(tokens), one, oneExpression) { }

  protected BaseAliasedChecks(OneResult oneResult,
    [CallerArgumentExpression(nameof(oneResult))] string oneExpression = "")
    : base(tokens => new SchemaParser(tokens), oneResult, oneExpression) { }

  public void WithMinimum(I input)
  => TrueExpected(AliasesString(input, ""), AliasedFactory(input));

  public void WithAliases(I input, string[] aliases)
  => TrueExpected(AliasesString(input, "[" + aliases.Joined() + "]"),
      AliasedFactory(input) with { Aliases = aliases });

  public void WithAliasesBad(I input, string[] aliases)
    => False(AliasesString(input, "[" + aliases.Joined()));

  public void WithAliasesNone(I input)
    => False(AliasesString(input, "[]"));

  protected internal abstract string AliasesString(I input, string aliases);
  protected internal abstract A AliasedFactory(I input);
}
