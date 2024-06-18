using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema;

public abstract class BaseAliasedTests<TInput>
  : BaseNamedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(TInput input, string[] aliases)
    => AliasChecks.WithAliases(input, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithAliasesBad_ReturnsFalse(TInput input, string[] aliases)
    => AliasChecks.WithAliasesBad(input, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithAliasesNone_ReturnsFalse(TInput input)
    => AliasChecks.WithAliasesNone(input);

  internal abstract IBaseAliasedChecks<TInput> AliasChecks { get; }

  internal override IBaseNamedChecks<TInput> NameChecks => AliasChecks;
}

internal abstract class BaseAliasedChecks<TInput, TAliased>(
  Parser<TAliased>.D parser
) : BaseAliasedChecks<TInput, TAliased, TAliased>(parser), IBaseAliasedChecks<TInput>
  where TAliased : AstAliased, IGqlpAliased
{ }

internal abstract class BaseAliasedChecks<TInput, TAliased, TSrc>(
  Parser<TSrc>.D parser
) : BaseNamedChecks<TInput, TAliased, TSrc>(parser), IBaseAliasedChecks<TInput>
  where TAliased : AstAliased, TSrc
  where TSrc : IGqlpAliased
{
  public void WithAliases(TInput input, string[] aliases)
  => TrueExpected(AliasesString(input, "[" + aliases.Joined() + "]"),
      NamedFactory(input) with { Aliases = aliases });

  public void WithAliasesBad(TInput input, string[] aliases)
    => False(AliasesString(input, "[" + aliases.Joined()));

  public void WithAliasesNone(TInput input)
    => False(AliasesString(input, "[]"));

  protected internal abstract string AliasesString(TInput input, string aliases);

  protected internal override string NameString(TInput input)
    => AliasesString(input, "");
}

internal interface IBaseAliasedChecks<TInput>
  : IBaseNamedChecks<TInput>
{
  void WithAliases(TInput input, string[] aliases);
  void WithAliasesBad(TInput input, string[] aliases);
  void WithAliasesNone(TInput input);
}
