using System.ComponentModel.DataAnnotations;

namespace GqlPlus.Verifier.ClassTests;

public class OperationTokensTests
{
  [Fact]
  public void AtStart_WhenConstructed_IsTrue()
  {
    var tokens = new OperationTokens("");

    _ = tokens.AtStart.Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void AtIdentifier_AfterReadTrue_IsTrue(
    [RegularExpression("[A-Za-z][A-Za-z0-9_]*")] string identifier)
  {
    var tokens = new OperationTokens(identifier);

    _ = tokens.Read().Should().BeTrue();

    _ = tokens.AtIdentifier.Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void AtNumber_AfterReadTrue_IsTrue([Range(-99999, 99999)] int number)
  {
    var tokens = new OperationTokens(number.ToString());

    _ = tokens.Read().Should().BeTrue();

    _ = tokens.AtNumber.Should().BeTrue();
  }

  [Fact]
  public void At_WithChar_AfterReadTrue_IsTrue()
  {
    var tokens = new OperationTokens("[");

    _ = tokens.Read().Should().BeTrue();

    _ = tokens.At('[').Should().BeTrue();
  }

  [Fact]
  public void At_WithString_AfterReadTrue_IsTrue()
  {
    var tokens = new OperationTokens("<>");

    _ = tokens.Read().Should().BeTrue();

    _ = tokens.At("<>").Should().BeTrue();
  }

  [Fact]
  public void AtEnd_AfterReadFalse_IsTrue()
  {
    var tokens = new OperationTokens("");

    _ = tokens.Read().Should().BeFalse();

    _ = tokens.AtEnd.Should().BeTrue();
  }

  [Theory, RepeatAutoData(10)]
  public void TakeIdentifier_AfterRead_ReturnsIdentifier(
    [RegularExpression("[A-Za-z][A-Za-z0-9_]*")] string identifier)
  {
    var tokens = new OperationTokens(identifier);

    _ = tokens.Read().Should().BeTrue();

    _ = tokens.TakeIdentifier().Should().Be(identifier);
  }

  [Theory, RepeatAutoData(10)]
  public void TakeNumber_AfterReadTrue_IsTrue([Range(-99999, 99999)] int number)
  {
    var tokens = new OperationTokens(number.ToString());

    _ = tokens.Read().Should().BeTrue();

    _ = tokens.TakeNumber().Should().Be(number);
  }
}
