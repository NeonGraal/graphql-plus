namespace GqlPlus.Verifier.Result;

public class ResultTests
{
  private readonly string[] _sample = { "Sample" };

  [Fact]
  public void OkArray_AsResultArray_ReturnsResultArrayOk()
  {
    var input = new[] { "Ok" }.Ok();

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayOk<string>>();
    result.Optional().Should().BeEquivalentTo(new object[] { "Ok" });
  }

  [Fact]
  public void Ok_AsResultArray_ReturnsResultArrayOk()
  {
    var input = "Ok".Ok();

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void Ok_Select_WithLength_ReturnsResultOk()
  {
    var input = "Ok".Ok();

    var result = input.Select(s => s.Length);

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(2);
  }

  [Fact]
  public void Ok_SelectOk_WithLength_ReturnsResultOk()
  {
    var input = "Ok".Ok();

    var result = input.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(2);
  }

  [Fact]
  public void Empty_AsResultArray_ReturnsResultArrayEmpty()
  {
    var input = "Empty".Empty();

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void Empty_Select_WithOnEmpty_ReturnsResultOk()
  {
    var input = "Empty".Empty();

    var result = input.Select(s => s.Length, () => 3.Ok());

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(3);
  }

  [Fact]
  public void Empty_SelectOk_WithOnEmpty_ReturnsResultOk()
  {
    var input = "Empty".Empty();

    var result = input.SelectOk(s => s.Length, () => 3.Ok());

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(3);
  }

  [Fact]
  public void Error_AsResultArray_ReturnsResultArrayError()
  {
    var input = new[] { "Error" }.Error("Error".ParseMessage());

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be("Error");
  }

  [Fact]
  public void PartialArray_AsResultArray_ReturnsResultArrayPartial()
  {
    var input = new[] { "Partial" }.Partial("Partial".ParseMessage());

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayPartial<string>>()
      .Subject.Message.Message.Should().Be("Partial");
    result.Optional().Should().BeEquivalentTo(new object[] { "Partial" });
  }

  [Fact]
  public void Partial_AsResultArray_ReturnsResultArrayPartial()
  {
    var input = "Partial".Partial("Partial".ParseMessage());

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayError<string>>()
      .Subject.Message.Message.Should().Be("Partial");
  }

  [Fact]
  public void Partial_Select_WithLength_ReturnsResultPartial()
  {
    var input = "Partial".Partial("Partial".ParseMessage());

    var result = input.Select(s => s.Length);

    result.Should().BeOfType<ResultPartial<int>>()
      .Subject.Message.Message.Should().Be("Partial");
    result.Optional().Should().Be(7);
  }

  [Fact]
  public void Partial_SelectOk_WithLength_ReturnsResultError()
  {
    var input = "Partial".Partial("Partial".ParseMessage());

    var result = input.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultError<int>>()
      .Subject.Message.Message.Should().Be("Partial");
  }
}
