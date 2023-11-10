﻿namespace GqlPlus.Verifier.Result;

public class ResultOkTests : BaseResultTests
{
  private const string Ok = "Ok";
  private readonly string[] _okArray = { Ok };

  [Fact]
  public void Array_AsResultArray_ReturnsResultArrayOk()
  {
    var input = _okArray.Ok();

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayOk<string>>();
    result.Optional().Should().BeEquivalentTo(new object[] { Ok });
  }

  [Fact]
  public void AsResultArray_ReturnsResultArrayOk()
  {
    var input = Ok.Ok();

    var result = input.AsResultArray(_sample);

    result.Should().BeOfType<ResultArrayEmpty<string>>();
  }

  [Fact]
  public void Select_WithLength_ReturnsResultOk()
  {
    var input = Ok.Ok();

    var result = input.Select(s => s.Length);

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(2);
  }

  [Fact]
  public void Select_WithNull_ReturnsResultEmpty()
  {
    var input = Ok.Ok();

    var result = input.Select(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultEmpty<Tokenizer>>();
  }

  [Fact]
  public void SelectWithLength_ReturnsResultOk()
  {
    var input = Ok.Ok();

    var result = input.SelectOk(s => s.Length);

    result.Should().BeOfType<ResultOk<int>>()
      .Subject.Optional().Should().Be(2);
  }

  [Fact]
  public void SelectWithNull_ReturnsResultEmpty()
  {
    var input = Ok.Ok();

    var result = input.SelectOk(s => (Tokenizer?)null);

    result.Should().BeOfType<ResultEmpty<Tokenizer>>();
  }
}
