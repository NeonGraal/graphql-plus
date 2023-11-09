namespace GqlPlus.Verifier.Result;

public class ResultArrayTests
{
  [Fact]
  public void Ok_AsResultObject_ReturnsResultOkObject()
  {
    var input = new[] { "Ok" }.OkArray();

    var result = input.AsResult<object>();

    result.Should().BeOfType<ResultOk<object>>()
      .Subject.Required().Should().BeEquivalentTo(new object[] { "Ok" });
  }

  [Fact]
  public void Ok_AsResultString_ReturnsResultEmptyString()
  {
    var input = new[] { "Ok" }.OkArray();

    var result = input.AsResult<string>();

    result.Should().BeOfType<ResultEmpty<string>>();
  }

  [Fact]
  public void Ok_AsResultArrayObject_ReturnsResultArrayOkObject()
  {
    var input = new[] { "Ok" }.OkArray();

    var result = input.AsResultArray<object>();

    result.Should().BeOfType<ResultArrayOk<object>>()
      .Subject.Required().Should().BeEquivalentTo(new object[] { "Ok" });
  }

  [Fact]
  public void Ok_AsResultArrayInt_ReturnsResultArrayEmptyInt()
  {
    var input = new[] { "Ok" }.OkArray();

    var result = input.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayEmpty<int>>();
  }

  [Fact]
  public void Empty_AsResultInt_ReturnsResultEmptyInt()
  {
    var input = new[] { "Empty" }.EmptyArray();

    var result = input.AsResult<int>();

    result.Should().BeOfType<ResultEmpty<int>>();
  }

  [Fact]
  public void Empty_AsResultArrayInt_ReturnsResultArrayEmptyInt()
  {
    var input = new[] { "Empty" }.EmptyArray();

    var result = input.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayEmpty<int>>();
  }

  [Fact]
  public void Error_AsResultInt_ReturnsResultErrorInt()
  {
    var input = new[] { "Error" }.ErrorArray("Error".ParseMessage());

    var result = input.AsResult<int>();

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be("Error");
  }

  [Fact]
  public void Error_AsResultArrayInt_ReturnsResultArrayErrorInt()
  {
    var input = new[] { "Error" }.ErrorArray("Error".ParseMessage());

    var result = input.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayError<int>>()
      .Subject.Message.Message.Should().Be("Error");
  }

  [Fact]
  public void Partial_AsResultObject_ReturnsResultPartialObject()
  {
    var input = new[] { "Partial" }.PartialArray("Partial".ParseMessage());

    var result = input.AsResult<object>();

    result.Should().BeOfType<ResultPartial<object>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void Partial_AsResultArrayObject_ReturnsResultArrayPartialObject()
  {
    var input = new[] { "Partial" }.PartialArray("Partial".ParseMessage());

    var result = input.AsResultArray<object>();

    result.Should().BeOfType<ResultArrayPartial<object>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void Partial_AsResultInt_ReturnsResultErrorInt()
  {
    var input = new[] { "Partial" }.PartialArray("Partial".ParseMessage());

    var result = input.AsResult<int>();

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void Partial_AsResultArrayint_ReturnsResultArrayErrorInt()
  {
    var input = new[] { "Partial" }.PartialArray("Partial".ParseMessage());

    var result = input.AsResultArray<int>();

    result.Should().BeOfType<ResultArrayError<int>>()
      .Subject.Message.Message.Should().Be("Partial");
  }
}
