using GqlPlus.Merging;

namespace GqlPlus.Merging;

public class MergerOneTests
  : SubstituteBase
{
  [Fact]
  public void CanMerge_WhenCalled_DelegatesToValue()
  {
    IMerge<IAstError> inner = A.Of<IMerge<IAstError>>();
    IMessages expected = A.Of<IMessages>();
    inner.CanMerge(Arg.Any<IEnumerable<IAstError>>()).Returns(expected);

    MergerOne<IAstError> merger = new(() => inner);

    IMessages result = merger.CanMerge([A.Of<IAstError>()]);

    result.ShouldBeSameAs(expected);
  }

  [Fact]
  public void Merge_WhenCalled_DelegatesToValue()
  {
    IMerge<IAstError> inner = A.Of<IMerge<IAstError>>();
    IEnumerable<IAstError> expected = [A.Of<IAstError>()];
    inner.Merge(Arg.Any<IEnumerable<IAstError>>()).Returns(expected);

    MergerOne<IAstError> merger = new(() => inner);

    IEnumerable<IAstError> result = merger.Merge([A.Of<IAstError>()]);

    result.ShouldBeSameAs(expected);
  }

  [Fact]
  public void ImplicitConvert_FromDelegate_ReturnsMergerOne()
  {
    IMerge<IAstError> inner = A.Of<IMerge<IAstError>>();
    IMessages expected = A.Of<IMessages>();
    inner.CanMerge(Arg.Any<IEnumerable<IAstError>>()).Returns(expected);

    MergerOne<IAstError>.D factory = () => inner;
    MergerOne<IAstError> result = factory;

    result.CanMerge([]).ShouldBeSameAs(expected);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    MergerOne<IAstError>.D? factory = null;

    Action result = () => _ = (MergerOne<IAstError>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
