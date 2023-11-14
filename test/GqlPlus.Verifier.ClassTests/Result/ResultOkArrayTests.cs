namespace GqlPlus.Verifier.Result;

public class ResultOkArrayTests : BaseResultTests
{
  private const string Ok = "Ok";
  private readonly IResultArray<string> _okArray = new[] { Ok }.OkArray();

  [Fact]
  public void AsPartial_ReturnsResultOk()
  {
    var withValue = false;
    var action = false;

    var result = _okArray.AsPartial(Sample, v => withValue = true, () => action = true);

    result.Should().BeOfType<ResultOk<string>>();
    using var scope = new AssertionScope();
    result.Optional().Should().Be(Sample);
    withValue.Should().BeTrue();
    action.Should().BeTrue();
  }

  [Fact]
  public void AsPartialArray_ReturnsResultOk()
  {
    var result = _okArray.AsPartialArray(_sample);

    result.Should().BeOfType<ResultArrayOk<string>>();
    using var scope = new AssertionScope();
    result.Optional().Should().BeEquivalentTo(new[] { Ok });
  }

  [Fact]
  public void AsResultObject_ReturnsResultOkObject()
  {
    var result = _okArray.AsResult<object>();

    result.Should().BeOfType<ResultOk<object>>()
      .Subject.Required().Should().BeEquivalentTo(new object[] { "Ok" });
  }

  [Fact]
  public void AsResultString_ReturnsResultEmptyString()
  {
    var result = _okArray.AsResult<string>();

    result.Should().BeOfType<ResultEmpty<string>>();
  }

  [Fact]
  public void AsResultArrayObject_ReturnsResultArrayOkObject()
  {
    var result = _okArray.AsResultArray<object>();

    result.Should().BeOfType<ResultArrayOk<object>>()
      .Subject.Required().Should().BeEquivalentTo(new object[] { "Ok" });
  }

  [Fact]
  public void AsResultArrayInt_ReturnsResultArrayEmptyInt()
  {
    var result = _okArray.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayEmpty<int>>();
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayOk()
  {
    var result = _okArray.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayOk<string>>();
    result.Optional().Should().BeEquivalentTo(new object[] { Ok });
  }

  [Fact]
  public void Map_ReturnsOtherwise()
  {
    var result = _okArray.Map(a => Ok.Ok(), () => Sample.Ok());

    result.Should().BeOfType<ResultOk<string>>()
      .Subject.Required().Should().Be(Ok);
  }
}
