using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseScalarTests<TInput>
  : BaseAliasedTests<TInput>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void WithKindBad_ReturnsFalse(TInput input, string kind)
    => ScalarChecks.WithKindBad(input, kind);

  [Theory, RepeatData(Repeats)]
  public void WithParent_ReturnsCorrectAst(TInput input, string parent)
    => ScalarChecks.WithParent(input, parent);

  [Theory, RepeatData(Repeats)]
  public void WithParentBad_ReturnsFalse(TInput input)
    => ScalarChecks.WithParentBad(input);

  internal abstract IBaseScalarChecks<TInput> ScalarChecks { get; }

  internal override IBaseAliasedChecks<TInput> AliasChecks => ScalarChecks;
}

internal abstract class BaseScalarChecks<TInput, TScalar>
  : BaseAliasedChecks<TInput, TScalar>, IBaseScalarChecks<TInput>
  where TScalar : AstScalar
{
  private readonly ScalarDomain _kind;

  protected BaseScalarChecks(Parser<TScalar>.D parser, ScalarDomain kind)
    : base(parser) => _kind = kind;

  public void WithKindBad(TInput input, string kind)
    => False(
      KindString(input, kind, ""),
      skipIf: Enum.TryParse<ScalarDomain>(kind, out var _));

  public void WithParent(TInput input, string parent)
    => TrueExpected(KindString(input, _kind.ToString(), ":" + parent + " "),
      AliasedFactory(input) with { Parent = parent });

  public void WithParentBad(TInput input)
    => False(
      KindString(input, _kind.ToString(), ":!"));

  protected internal abstract string KindString(TInput input, string kind, string parent);
}

internal interface IBaseScalarChecks<TInput> : IBaseAliasedChecks<TInput>
{
  void WithKindBad(TInput input, string kind);
  void WithParent(TInput input, string parent);
  void WithParentBad(TInput input);
}
