using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public abstract class TestAbbreviated<TAst>
  : TestAbbreviated<TAst, string>
  where TAst : AstAbbreviated
{ }

[TracePerTest]

public abstract class TestAbbreviated<TAst, TInput>
  where TAst : AstAbbreviated
{
  [Fact]
  public void CanMerge_NoAsts_ReturnsFalse()
   => CanMerge_False([]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneAst_ReturnsTrue(TInput input)
    => CanMerge_True([MakeAst(input)]);

  [Fact]
  public void Merge_NullAsts_ReturnsEmpty()
  {
    var result = MergerBase.Merge(null!);

    result.Should().BeEmpty();
  }

  [Fact]
  public void Merge_NoAsts_ReturnsEmpty()
  {
    var result = MergerBase.Merge([]);

    result.Should().BeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_OneAst_ReturnsAst(TInput input)
  {
    var ast = MakeAst(input);

    Merge_Expected([ast], ast);
  }

  protected abstract IMerge<TAst> MergerBase { get; }

  protected abstract TAst MakeAst(TInput input);

  protected static ITokenMessages EmptyMessages => new TokenMessages();
  protected static ITokenMessages ErrorMessages => new TokenMessages(new TokenMessage(AstNulls.At, "Error!"));

  protected void CanMerge_False(TAst[] asts)
  {
    var result = MergerBase.CanMerge(asts);

    result.Should().NotBeEmpty();
  }

  protected void CanMerge_False(TAst[] asts, bool skipIf)
  {
    Skip.If(skipIf);

    CanMerge_False(asts);
  }

  protected void CanMerge_True(TAst[] asts)
  {
    var result = MergerBase.CanMerge(asts);

    result.Should().BeEmpty();
  }

  protected void CanMerge_True(TAst[] asts, bool skipIf)
  {
    Skip.If(skipIf);

    CanMerge_True(asts);
  }

  protected void Merge_Expected(TAst[] asts, bool skipIf, params TAst[] expected)
  {
    Skip.If(skipIf);

    Merge_Expected(asts, expected);
  }

  protected void Merge_Expected(TAst[] asts, params TAst[] expected)
  {

    var result = MergerBase.Merge(asts);

    using var scope = new AssertionScope();

    result.Should().BeAssignableTo<IEnumerable<TAst>>();
    result.Should().BeEquivalentTo(expected);
  }

  protected IMerge<TResult> Merger<TResult>()
    where TResult : AstBase
  {
    var result = Substitute.For<IMerge<TResult>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<TResult>>());
    return result;
  }
}
