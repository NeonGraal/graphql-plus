using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parse.Schema.Simple;

public abstract class TestDomain<TInput>
  : TestAliased<TInput>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void WithKindBad_ReturnsFalse(TInput input, string kind)
    => DomainChecks.WithKindBad(input, kind);

  [Theory, RepeatData(Repeats)]
  public void WithParent_ReturnsCorrectAst(TInput input, string parent)
    => DomainChecks.WithParent(input, parent);

  [Theory, RepeatData(Repeats)]
  public void WithParentBad_ReturnsFalse(TInput input)
    => DomainChecks.WithParentBad(input);

  internal abstract ICheckDomain<TInput> DomainChecks { get; }

  internal override ICheckAliased<TInput> AliasChecks => DomainChecks;
}

internal abstract class CheckDomain<TInput, TDomain>
  : CheckAliased<TInput, TDomain>, ICheckDomain<TInput>
  where TDomain : AstDomain
{
  private readonly DomainKind _kind;

  protected CheckDomain(Parser<TDomain>.D parser, DomainKind kind)
    : base(parser) => _kind = kind;

  public void WithKindBad(TInput input, string kind)
    => False(
      KindString(input, kind, ""),
      skipIf: Enum.TryParse<DomainKind>(kind, out DomainKind _));

  public void WithParent(TInput input, string parent)
    => TrueExpected(KindString(input, _kind.ToString(), ":" + parent + " "),
      NamedFactory(input) with { Parent = parent });

  public void WithParentBad(TInput input)
    => False(
      KindString(input, _kind.ToString(), ":!"));

  protected internal abstract string KindString(TInput input, string kind, string parent);
}

internal interface ICheckDomain<TInput> : ICheckAliased<TInput>
{
  void WithKindBad(TInput input, string kind);
  void WithParent(TInput input, string parent);
  void WithParentBad(TInput input);
}
