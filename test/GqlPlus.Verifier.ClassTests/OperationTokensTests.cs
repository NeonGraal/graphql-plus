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
  public void AtNumber_AfterReadTrue_IsTrue([Range(-99999, 99999)] int number)
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

  [Fact]
  public void At_WithString_AfterReadTrue_IsTrue()
  {
    var tokens = new OperationTokens("<>");

    tokens.Read().Should().BeTrue();

    tokens.At("<>").Should().BeTrue();
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
    [RegularExpression(IdentifierPattern)] string identifier)
  {
    var tokens = new OperationTokens(identifier);

    tokens.Read().Should().BeTrue();

    tokens.TakeIdentifier().Should().Be(identifier);
  }

  [Theory, RepeatAutoData(10)]
  public void TakeNumber_AfterReadTrue_IsTrue([Range(-99999, 99999)] int number)
  {
    var tokens = new OperationTokens(number.ToString());

    tokens.Read().Should().BeTrue();

    tokens.TakeNumber().Should().Be(number);
  }

  [Theory, RepeatAutoData(10)]
  public void Take_WithSingle_AfterRead_ReturnsChar(
    [RegularExpression(PunctuationPattern)] string single)
  {
    var tokens = new OperationTokens(single);
    var expected = single.First();

    tokens.Read().Should().BeTrue();

    tokens.Take(expected).Should().Be(expected);
  }

  [Theory, RepeatAutoData(10)]
  public void Take_WithMany_AfterRead_ReturnsChar(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    var tokens = new OperationTokens(many);
    var expected = many.First();

    tokens.Read().Should().BeTrue();

    tokens.Take(many.ToCharArray()).Should().Be(expected);
  }
}
