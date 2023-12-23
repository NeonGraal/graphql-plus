using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class BaseAliasedParserChecks<I, A>
  : OneChecksParser<A>, IBaseAliasedChecks<I>
  where A : AstAliased
{
  protected BaseAliasedParserChecks(Parser<A>.D parser)
    : base(parser) { }

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
