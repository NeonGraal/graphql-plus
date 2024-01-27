using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseAliasedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(TInput input)
    => AliasChecks.WithMinimum(input);

  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => AliasChecks.WithNameBad(id);

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
}

internal abstract class BaseAliasedChecks<TInput, TAliased>
  : OneChecksParser<TAliased>, IBaseAliasedChecks<TInput>
  where TAliased : AstAliased
{
  protected BaseAliasedChecks(Parser<TAliased>.D parser)
    : base(parser) { }

  public void WithMinimum(TInput input)
  => TrueExpected(AliasesString(input, ""), AliasedFactory(input));

  public void WithNameBad(decimal id)
  => False($"{id}{{}}");

  public void WithAliases(TInput input, string[] aliases)
  => TrueExpected(AliasesString(input, "[" + aliases.Joined() + "]"),
      AliasedFactory(input) with { Aliases = aliases });

  public void WithAliasesBad(TInput input, string[] aliases)
    => False(AliasesString(input, "[" + aliases.Joined()));

  public void WithAliasesNone(TInput input)
    => False(AliasesString(input, "[]"));

  protected internal abstract string AliasesString(TInput input, string aliases);
  protected internal abstract TAliased AliasedFactory(TInput input);
}

internal interface IBaseAliasedChecks<TInput>
{
  void WithMinimum(TInput input);
  void WithNameBad(decimal id);
  void WithAliases(TInput input, string[] aliases);
  void WithAliasesBad(TInput input, string[] aliases);
  void WithAliasesNone(TInput input);
}
