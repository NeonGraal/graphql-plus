using GqlPlus.Ast;
using GqlPlus.Token;
using NSubstitute;

namespace GqlPlus.Merging;

public abstract class TestAbbreviated<TAst>
  : TestAbbreviated<TAst, string>
  where TAst : IGqlpError
{ }

[TracePerTest]

public abstract class TestAbbreviated<TAst, TInput>
  where TAst : IGqlpError
{
  [Fact]
  public void CanMerge_NoAsts_ReturnsErrors()
   => CanMerge_Errors([]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneAst_ReturnsGood(TInput input)
    => CanMerge_Good([MakeAst(input)]);

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

  protected void CanMerge_Errors(params TAst[] asts)
  {
    var result = MergerBase.CanMerge(asts);

    result.Should().NotBeEmpty();
  }

  protected void CanMerge_Good(params TAst[] asts)
  {
    var result = MergerBase.CanMerge(asts);

    result.Should().BeEmpty();
  }

  protected object Merge_Expected(TAst[] asts, params TAst[] expected)
  {
    var result = MergerBase.Merge(asts);

    using var scope = new AssertionScope();

    result.Should().BeAssignableTo<IEnumerable<TAst>>();
    result.Should().BeEquivalentTo(expected);

    return this;
  }

  protected static ITokenMessages EmptyMessages => new TokenMessages();

  protected IMerge<TResult> Merger<TResult>()
    where TResult : IGqlpError
  {
    var result = Substitute.For<IMerge<TResult>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<TResult>>());
    return result;
  }
}

public static class TestMergeHelper
{
  private static ITokenMessages ErrorMessages => new TokenMessages(new TokenMessage(AstNulls.At, "Error!"));

  public static TTests CanMergeReturnsError<TTests, TResult>(this TTests tests, IMerge<TResult> merger)
    where TResult : AstBase
  {
    merger?.CanMerge([]).ReturnsForAnyArgs(ErrorMessages);

    return tests;
  }

  public static TTests MergeCalled<TTests, TResult>(this TTests tests, IMerge<TResult> merger, int times = 1)
    where TResult : IGqlpError
  {
    merger?.ReceivedWithAnyArgs(times).Merge([]);

    return tests;
  }
}
