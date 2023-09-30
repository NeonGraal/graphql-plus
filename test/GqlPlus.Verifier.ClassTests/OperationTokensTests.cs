﻿using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class OperationTokensTests
{
  private OperationTokens PrepareTokens(string input)
  {
    var tokens = new OperationTokens(input + " ");

    tokens.Read().Should().BeTrue();

    return tokens;
  }

  [Fact]
  public void AtStart_WhenConstructed_IsTrue()
  {
    var tokens = new OperationTokens("");

    tokens.AtStart.Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void AtIdentifier_AfterReadTrue_IsTrue(
    [RegularExpression(IdentifierPattern)] string identifier)
  {
    OperationTokens tokens = PrepareTokens(identifier);

    tokens.AtIdentifier.Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void AtNumber_AfterReadTrue_IsTrue(
    [Range(-99999, 99999)] int number)
  {
    OperationTokens tokens = PrepareTokens(number.ToString());

    tokens.AtNumber.Should().BeTrue();
  }

  [Fact]
  public void At_WithChar_AfterReadTrue_IsTrue()
  {
    OperationTokens tokens = PrepareTokens("[");

    tokens.At('[').Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void At_WithString_AfterReadTrue_IsTrue(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    OperationTokens tokens = PrepareTokens(many);

    tokens.At(many).Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void At_WithShort_AfterReadTrue_IsFalse(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    OperationTokens tokens = PrepareTokens(many[..4]);

    tokens.At(many).Should().BeFalse();
  }

  [Fact]
  public void AtEnd_AfterReadFalse_IsTrue()
  {
    var tokens = new OperationTokens("");

    tokens.Read().Should().BeFalse();

    tokens.AtEnd.Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void TakeIdentifier_AfterRead_ReturnsIdentifier(
    [RegularExpression(IdentifierPattern)] string expected)
  {
    OperationTokens tokens = PrepareTokens(expected);

    tokens.TakeIdentifier(out var result).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatData(10)]
  public void TakeNumber_AfterReadTrue_IsTrue(
    [Range(-99999, 99999)] int expected)
  {
    OperationTokens tokens = PrepareTokens(expected.ToString());

    tokens.TakeNumber(out var result).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatData(10)]
  public void Take_WithSingle_AfterRead_ReturnsTrue(
    [RegularExpression(PunctuationPattern)] string single)
  {
    OperationTokens tokens = PrepareTokens(single);
    var expected = single.First();

    tokens.Take(expected).Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void TakeAny_WithMany_AfterRead_ReturnsChar(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    OperationTokens tokens = PrepareTokens(many);
    var expected = many.First();

    tokens.TakeAny(out var result, many.ToCharArray()).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatData(10)]
  public void Take_WithString_AfterRead_ReturnsString(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    OperationTokens tokens = PrepareTokens(many);

    tokens.Take(many).Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void Take_WithShort_AfterRead_ReturnsString(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    OperationTokens tokens = PrepareTokens(many[..4]);

    tokens.Take(many).Should().BeFalse();
  }

  [Theory, RepeatData(10)]
  public void Prefix_WithoutName_AfterRead_ReturnsNull(
    [RegularExpression(PunctuationPattern)] string prefix)
  {
    OperationTokens tokens = PrepareTokens(prefix + "?");
    var expected = prefix.First();

    tokens.Prefix(expected, out _).Should().BeFalse();
    tokens.Take(expected).Should().BeTrue();
    tokens.Take('?').Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void Prefix_WithName_AfterRead_ReturnsCharThenName(
    [RegularExpression(PunctuationPattern)] string prefix,
    [RegularExpression(IdentifierPattern)] string identifier)
  {
    OperationTokens tokens = PrepareTokens(prefix + identifier);
    var expected = prefix.First();

    tokens.Prefix(expected, out var result).Should().BeTrue();
    result.Should().Be(identifier);
  }
}
