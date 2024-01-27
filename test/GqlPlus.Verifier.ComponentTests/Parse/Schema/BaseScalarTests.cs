using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseScalarTests<TInput>
  : BaseAliasedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithKindBad_ReturnsFalse(TInput input, string kind)
    => ScalarChecks.WithKindBad(input, kind);

  [Theory, RepeatData(Repeats)]
  public void WithExtends_ReturnsCorrectAst(TInput input, string extends)
    => ScalarChecks.WithExtends(input, extends);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsBad_ReturnsFalse(TInput input)
    => ScalarChecks.WithExtendsBad(input);

  internal abstract IBaseScalarChecks<TInput> ScalarChecks { get; }

  internal override IBaseAliasedChecks<TInput> AliasChecks => ScalarChecks;
}

internal abstract class BaseScalarChecks<TInput, TScalar>
  : BaseAliasedChecks<TInput, TScalar>, IBaseScalarChecks<TInput>
  where TScalar : AstScalar
{
  private readonly ScalarKind _kind;

  protected BaseScalarChecks(Parser<TScalar>.D parser, ScalarKind kind)
    : base(parser) => _kind = kind;

  public void WithKindBad(TInput input, string kind)
    => False(
      KindString(input, kind, ""),
      skipIf: Enum.TryParse<ScalarKind>(kind, out var _));

  public void WithExtends(TInput input, string extends)
    => TrueExpected(KindString(input, _kind.ToString(), ":" + extends),
      AliasedFactory(input) with { Extends = extends });

  public void WithExtendsBad(TInput input)
    => False(
      KindString(input, _kind.ToString(), ":"));

  protected internal abstract string KindString(TInput input, string kind, string extends);
}

internal interface IBaseScalarChecks<TInput> : IBaseAliasedChecks<TInput>
{
  void WithKindBad(TInput input, string kind);
  void WithExtends(TInput input, string extends);
  void WithExtendsBad(TInput input);
}
