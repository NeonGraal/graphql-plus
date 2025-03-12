using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Simple;

public abstract class BaseDomainTests<TInput, TDomain>(
  IBaseDomainChecks<TInput, TDomain> domainChecks
) : BaseAliasedTests<TInput, TDomain>(domainChecks)
  where TDomain : IGqlpDomain
{
  [Theory, RepeatData(Repeats)]
  public void WithKindBad_ReturnsFalse(TInput input, string kind)
    => domainChecks.WithKindBad(input, kind);

  [Theory, RepeatData(Repeats)]
  public void WithParent_ReturnsCorrectAst(TInput input, string parent)
    => domainChecks.WithParent(input, parent);

  [Theory, RepeatData(Repeats)]
  public void WithParentBad_ReturnsFalse(TInput input)
    => domainChecks.WithParentBad(input);
}

internal abstract class BaseDomainChecks<TInput, TDomainAst, TDomain>(
  Parser<IGqlpDomain>.D parser,
  DomainKind kind
) : BaseAliasedChecks<TInput, TDomainAst, IGqlpDomain>(parser)
  , IBaseDomainChecks<TInput, TDomain>
  where TDomain : IGqlpDomain
  where TDomainAst : AstDomain, TDomain
{
  private readonly DomainKind _kind = kind;

  public void WithKindBad(TInput input, string kind)
    => this.
      SkipIf(Enum.TryParse(kind, out DomainKind _))
      .FalseExpected(KindString(input, kind, ""));

  public void WithParent(TInput input, string parent)
    => TrueExpected(KindString(input, _kind.ToString(), ":" + parent + " "),
      NamedFactory(input) with { Parent = parent });

  public void WithParentBad(TInput input)
    => FalseExpected(
      KindString(input, _kind.ToString(), ":!"));

  void IOneChecksParser<TDomain>.FalseExpected(string input, Action<TDomain?>? check)
    => FalseExpected(input, domain => {
      if (domain is TDomain value) {
        check?.Invoke(value);
      } else {
        check?.Invoke(default);
      }
    });

  void IOneChecksParser<TDomain>.OkResult(string input, TDomain expected)
    => OkResult(input, expected);

  void IOneChecksParser<TDomain>.TrueExpected(string input, TDomain expected)
    => TrueExpected(input, expected);

  protected internal abstract string KindString(TInput input, string kind, string parent);
}

public interface IBaseDomainChecks<TInput, TDomain>
  : IBaseAliasedChecks<TInput, TDomain>
  where TDomain : IGqlpDomain
{
  void WithKindBad(TInput input, string kind);
  void WithParent(TInput input, string parent);
  void WithParentBad(TInput input);
}
