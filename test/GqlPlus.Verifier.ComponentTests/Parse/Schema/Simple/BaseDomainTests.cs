using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

public abstract class BaseDomainTests<TInput>
  : BaseAliasedTests<TInput>
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

  internal abstract IBaseDomainChecks<TInput> DomainChecks { get; }

  internal override IBaseAliasedChecks<TInput> AliasChecks => DomainChecks;
}

internal abstract class BaseDomainChecks<TInput, TDomain>
  : BaseAliasedChecks<TInput, TDomain>, IBaseDomainChecks<TInput>
  where TDomain : AstDomain
{
  private readonly DomainKind _kind;

  protected BaseDomainChecks(Parser<TDomain>.D parser, DomainKind kind)
    : base(parser) => _kind = kind;

  public void WithKindBad(TInput input, string kind)
    => False(
      KindString(input, kind, ""),
      skipIf: Enum.TryParse<DomainKind>(kind, out var _));

  public void WithParent(TInput input, string parent)
    => TrueExpected(KindString(input, _kind.ToString(), ":" + parent + " "),
      NamedFactory(input) with { Parent = parent });

  public void WithParentBad(TInput input)
    => False(
      KindString(input, _kind.ToString(), ":!"));

  protected internal abstract string KindString(TInput input, string kind, string parent);
}

internal interface IBaseDomainChecks<TInput> : IBaseAliasedChecks<TInput>
{
  void WithKindBad(TInput input, string kind);
  void WithParent(TInput input, string parent);
  void WithParentBad(TInput input);
}
