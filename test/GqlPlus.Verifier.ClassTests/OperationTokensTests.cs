using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class OperationTokensTests
{
  [Fact]
  public void AtStart_WhenConstructed_IsTrue()
  {
    var tokens = new OperationTokens("");

    tokens.AtStart.Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void AtIdentifier_AfterReadTrue_IsTrue(
    [RegularExpression(IdentifierPattern)] string identifier)
  {
    var tokens = new OperationTokens(identifier);

    tokens.Read().Should().BeTrue();

    tokens.AtIdentifier.Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void AtNumber_AfterReadTrue_IsTrue(
    [Range(-99999, 99999)] int number)
  {
    var tokens = new OperationTokens(number.ToString());

    tokens.Read().Should().BeTrue();

    tokens.AtNumber.Should().BeTrue();
  }

  [Fact]
  public void At_WithChar_AfterReadTrue_IsTrue()
  {
    var tokens = new OperationTokens("[");

    tokens.Read().Should().BeTrue();

    tokens.At('[').Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void At_WithString_AfterReadTrue_IsTrue(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    var tokens = new OperationTokens(many);

    tokens.Read().Should().BeTrue();

    tokens.At(many).Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void At_WithShort_AfterReadTrue_IsFalse(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    var tokens = new OperationTokens(many[..4]);

    tokens.Read().Should().BeTrue();

    tokens.At(many).Should().BeFalse();
  }

  [Fact]
  public void AtEnd_AfterReadFalse_IsTrue()
  {
    var tokens = new OperationTokens("");

    tokens.Read().Should().BeFalse();

    tokens.AtEnd.Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void TakeIdentifier_AfterRead_ReturnsIdentifier(
    [RegularExpression(IdentifierPattern)] string expected)
  {
    var tokens = new OperationTokens(expected);

    tokens.Read().Should().BeTrue();

    tokens.TakeIdentifier(out var result).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatAutoData(10)]
  public void TakeNumber_AfterReadTrue_IsTrue(
    [Range(-99999, 99999)] int expected)
  {
    var tokens = new OperationTokens(expected.ToString());

    tokens.Read().Should().BeTrue();

    tokens.TakeNumber(out var result).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatAutoData(10)]
  public void Take_WithSingle_AfterRead_ReturnsTrue(
    [RegularExpression(PunctuationPattern)] string single)
  {
    var tokens = new OperationTokens(single);
    var expected = single.First();

    tokens.Read().Should().BeTrue();

    tokens.Take(expected).Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void TakeAny_WithMany_AfterRead_ReturnsChar(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    var tokens = new OperationTokens(many);
    var expected = many.First();

    tokens.Read().Should().BeTrue();

    tokens.TakeAny(out var result, many.ToCharArray()).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatAutoData(10)]
  public void Take_WithString_AfterRead_ReturnsString(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    var tokens = new OperationTokens(many);

    tokens.Read().Should().BeTrue();

    tokens.Take(many).Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void Take_WithShort_AfterRead_ReturnsString(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    var tokens = new OperationTokens(many[..4]);

    tokens.Read().Should().BeTrue();

    tokens.Take(many).Should().BeFalse();
  }

  [Theory, RepeatAutoData(10)]
  public void Prefix_WithoutName_AfterRead_ReturnsNull(
    [RegularExpression(PunctuationPattern)] string prefix)
  {
    var tokens = new OperationTokens(prefix + "?");
    var expected = prefix.First();

    tokens.Read().Should().BeTrue();

    tokens.Prefix(expected, out var name).Should().BeFalse();
    tokens.Take(expected).Should().BeTrue();
    tokens.Take('?').Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void Prefix_WithName_AfterRead_ReturnsCharThenName(
    [RegularExpression(PunctuationPattern)] string prefix,
    [RegularExpression(IdentifierPattern)] string identifier)
  {
    var tokens = new OperationTokens(prefix + identifier);
    var expected = prefix.First();

    tokens.Read().Should().BeTrue();

    tokens.Prefix(expected, out var result).Should().BeTrue();
    result.Should().Be(identifier);
  }
}
