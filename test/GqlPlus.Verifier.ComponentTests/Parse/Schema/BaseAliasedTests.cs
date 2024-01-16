using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseAliasedTests<I>
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(I input)
  => AliasChecks.WithMinimum(input);

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(I input, string[] aliases)
  => AliasChecks.WithAliases(input, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithAliasesBad_ReturnsFalse(I input, string[] aliases)
  => AliasChecks.WithAliasesBad(input, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithAliasesNone_ReturnsFalse(I input)
  => AliasChecks.WithAliasesNone(input);

  internal abstract IBaseAliasedChecks<I> AliasChecks { get; }
}

internal abstract class BaseAliasedChecks<I, A>
  : OneChecksParser<A>, IBaseAliasedChecks<I>
  where A : AstAliased
{
  protected BaseAliasedChecks(Parser<A>.D parser)
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

internal interface IBaseAliasedChecks<I>
{
  void WithMinimum(I input);
  void WithAliases(I input, string[] aliases);
  void WithAliasesBad(I input, string[] aliases);
  void WithAliasesNone(I input);
}
