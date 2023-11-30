namespace GqlPlus.Verifier.Result;

public class ResultEmptyArrayTests : BaseResultTests
{
  private const string Empty = "Empty";
  private readonly IResultArray<string> _emptyArray = new[] { "Empty" }.EmptyArray();

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    var withValue = false;
    var action = false;

    var result = _emptyArray.AsPartial(Sample, v => withValue = true, () => action = true);

    result.Should().BeOfType<ResultOk<string>>();
    using var scope = new AssertionScope();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeFalse();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    var withValue = false;

    var result = _emptyArray.AsPartialArray(_sample, v => withValue = true);

    result.Should().BeOfType<ResultArrayOk<string>>();
    using var scope = new AssertionScope();
    result.Optional().Should().Equal(Sample);
    withValue.Should().BeFalse();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayEmpty()
  {
    var result = _emptyArray.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayEmptyInt()
  {
    var result = _emptyArray.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayEmpty<int>>();
  }

  [Fact]
  public void AsResultInt_ReturnsResultEmptyInt()
  {
    var result = _emptyArray.AsResult<int>();

    result.Should().BeOfType<ResultEmpty<int>>();
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    var result = _emptyArray.Map(a => Empty.Ok(), () => Sample.Ok());

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Required().Should().Be(Sample);
  }

  [Fact]
  public void Optional_ReturnsEmpty()
  {
    var result = _emptyArray.Optional();

    result.Should().BeEmpty();
  }
}
