using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseScalarTests<TInput>
  : BaseAliasedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithKindBad_ReturnsFalse(TInput input, string kind)
    => ScalarChecks.WithKindBad(input, kind);

  internal abstract IBaseScalarChecks<TInput> ScalarChecks { get; }

  internal override IBaseAliasedChecks<TInput> AliasChecks => ScalarChecks;
}

internal abstract class BaseScalarChecks<TInput, TScalar>
  : BaseAliasedChecks<TInput, TScalar>, IBaseScalarChecks<TInput>
  where TScalar : AstScalar
{
  protected BaseScalarChecks(Parser<TScalar>.D parser)
    : base(parser) { }

  public void WithKindBad(TInput input, string kind)
    => False(
      KindString(input, kind), // $"{name}{{{kind}}}"
      skipIf: Enum.TryParse<ScalarKind>(kind, out var _));

  protected internal abstract string KindString(TInput input, string kind);
}

internal interface IBaseScalarChecks<TInput> : IBaseAliasedChecks<TInput>
{
  void WithKindBad(TInput input, string kind);
}
