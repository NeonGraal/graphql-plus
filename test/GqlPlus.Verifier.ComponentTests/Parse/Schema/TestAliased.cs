using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class TestAliased<TInput>
  : TestNamed<TInput>
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

  internal abstract ICheckAliased<TInput> AliasChecks { get; }

  internal override ICheckNamed<TInput> NameChecks => AliasChecks;
}

internal abstract class CheckAliased<TInput, TAliased>(
  Parser<TAliased>.D parser
) : CheckNamed<TInput, TAliased>(parser), ICheckAliased<TInput>
  where TAliased : AstAliased
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

internal interface ICheckAliased<TInput>
  : ICheckNamed<TInput>
{
  void WithAliases(TInput input, string[] aliases);
  void WithAliasesBad(TInput input, string[] aliases);
  void WithAliasesNone(TInput input);
}
