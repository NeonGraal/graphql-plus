namespace GqlPlus.Merging.Schema;

public abstract class TestAbbreviatedMerger<TAst>
  : TestAbbreviatedMerger<TAst, string>
  where TAst : IGqlpError
{ }

[TracePerTest]

public abstract class TestAbbreviatedMerger<TAst, TInput>
  where TAst : IGqlpError
{
  [Fact]
  public virtual void CanMerge_NoAsts_ReturnsErrors()
   => CanMerge_Errors([]);

  [Theory, RepeatData]
  public void CanMerge_OneAst_ReturnsGood(TInput input)
    => CanMerge_Good([MakeAst(input)]);

  [Fact]
  public void Merge_NullAsts_ReturnsEmpty()
  {
    IEnumerable<TAst> result = MergerBase.Merge(null!);

    result.ShouldBeEmpty();
  }

  [Fact]
  public void Merge_NoAsts_ReturnsEmpty()
  {
    IEnumerable<TAst> result = MergerBase.Merge([]);

    result.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Merge_OneAst_ReturnsAst(TInput input)
  {
    TAst ast = MakeAst(input);

    Merge_Expected([ast], ast);
  }

  protected abstract IMerge<TAst> MergerBase { get; }

  protected abstract TAst MakeAst(TInput input);

  protected void CanMerge_Errors(params TAst[] asts)
  {
    IMessages result = MergerBase.CanMerge(asts);

    result.ShouldNotBeEmpty();
  }

  protected void CanMerge_Good(params TAst[] asts)
  {
    IMessages result = MergerBase.CanMerge(asts);

    result.ShouldBeEmpty();
  }

  protected object Merge_Expected(TAst[] asts, params TAst[] expected)
  {
    IEnumerable<TAst> result = MergerBase.Merge(asts);

    result.ShouldBeAssignableTo<IEnumerable<TAst>>()
      .ShouldBe(expected, ignoreOrder: true);

    return this;
  }

  protected static IMessages EmptyMessages => Messages.New;

  protected IMerge<TResult> Merger<TResult>()
    where TResult : IGqlpError
  {
    IMerge<TResult> result = Substitute.For<IMerge<TResult>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<TResult>>());
    return result;
  }
}

public static class TestMergeHelper
{
  private static IMessages ErrorMessages => new Messages(new TokenMessage(AstNulls.At, "Error!"));

  public static TTests CanMergeReturnsError<TTests, TResult>(this TTests tests, IMerge<TResult> merger)
    where TResult : IGqlpError
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
