using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema;

public abstract class BaseAliasedTests<TInput, TParsed>(
  IBaseAliasedChecks<TInput, TParsed> aliasChecks
) : BaseNamedTests<TInput, TParsed>(aliasChecks)
  where TParsed : IGqlpAliased
{
  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(TInput input, string[] aliases)
    => aliasChecks.WithAliases(input, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithAliasesBad_ReturnsFalse(TInput input, string[] aliases)
    => aliasChecks.WithAliasesBad(input, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithAliasesNone_ReturnsFalse(TInput input)
    => aliasChecks.WithAliasesNone(input);
}

internal abstract class BaseAliasedChecks<TInput, TAliasedAst, TAliased>(
  Parser<TAliased>.D parser
) : BaseNamedChecks<TInput, TAliasedAst, TAliased>(parser)
  , IBaseAliasedChecks<TInput, TAliased>
  where TAliasedAst : AstAliased, TAliased
  where TAliased : IGqlpAliased
{
  public void WithAliases(TInput input, string[] aliases)
  => TrueExpected(AliasesString(input, "[" + aliases.Joined() + "]"),
      NamedFactory(input) with { Aliases = aliases });

  public void WithAliasesBad(TInput input, string[] aliases)
    => FalseExpected(AliasesString(input, "[" + aliases.Joined()));

  public void WithAliasesNone(TInput input)
    => FalseExpected(AliasesString(input, "[]"));

  protected internal abstract string AliasesString(TInput input, string aliases);

  protected internal override string NameString(TInput input)
    => AliasesString(input, "");
}

public interface IBaseAliasedChecks<TInput, TParsed>
  : IBaseNamedChecks<TInput, TParsed>
  where TParsed : IGqlpAliased
{
  void WithAliases(TInput input, string[] aliases);
  void WithAliasesBad(TInput input, string[] aliases);
  void WithAliasesNone(TInput input);
}
