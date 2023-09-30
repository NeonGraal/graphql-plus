using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class TokenizerTests
{
  private Tokenizer PrepareTokens(string input)
  {
    var tokens = new Tokenizer(input + " ");

    tokens.Read().Should().BeTrue();

    return tokens;
  }

  [Fact]
  public void AtStart_WhenConstructed_IsTrue()
  {
    var tokens = new Tokenizer("");

    tokens.AtStart.Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void AtIdentifier_AfterReadTrue_IsTrue(
    [RegularExpression(IdentifierPattern)] string identifier)
  {
    Tokenizer tokens = PrepareTokens(identifier);

    tokens.AtIdentifier.Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void AtNumber_AfterReadTrue_IsTrue(
    [Range(-99999, 99999)] int number)
  {
    Tokenizer tokens = PrepareTokens(number.ToString());

    tokens.AtNumber.Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void AtString_AfterReadTrue_IsTrue(
    [RegularExpression(IdentifierPattern)] string contents)
  {
    Tokenizer tokens = PrepareTokens('"' + contents + '"');

    tokens.AtString.Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void AtRegex_AfterReadTrue_IsTrue(
    [RegularExpression(IdentifierPattern)] string regex)
  {
    Tokenizer tokens = PrepareTokens($"/{regex}/");

    tokens.AtRegex.Should().BeTrue();
  }

  [Fact]
  public void At_WithChar_AfterReadTrue_IsTrue()
  {
    Tokenizer tokens = PrepareTokens("[");

    tokens.At('[').Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void At_WithString_AfterReadTrue_IsTrue(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    Tokenizer tokens = PrepareTokens(many);

    tokens.At(many).Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void At_WithShort_AfterReadTrue_IsFalse(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    Tokenizer tokens = PrepareTokens(many[..4]);

    tokens.At(many).Should().BeFalse();
  }

  [Fact]
  public void AtEnd_AfterReadFalse_IsTrue()
  {
    var tokens = new Tokenizer("");

    tokens.Read().Should().BeFalse();

    tokens.AtEnd.Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void Identifier_AfterRead_ReturnsIdentifier(
    [RegularExpression(IdentifierPattern)] string expected)
  {
    Tokenizer tokens = PrepareTokens(expected);

    tokens.Identifier(out var result).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatData(10)]
  public void Number_AfterReadTrue_IsTrue(
    [Range(-99999, 99999)] int expected)
  {
    Tokenizer tokens = PrepareTokens(expected.ToString());

    tokens.Number(out var result).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatData(10)]
  public void String_Double_AfterReadTrue_IsTrue(
    [RegularExpression(IdentifierPattern)] string contents)
  {
    Tokenizer tokens = PrepareTokens('"' + contents + '"');

    tokens.String(out var result).Should().BeTrue();
    result.Should().Be(contents);
  }

  [Theory, RepeatData(10)]
  public void String_DoubleWithNoEnd_AfterReadTrue_IsFalse(
    [RegularExpression(IdentifierPattern)] string contents)
  {
    Tokenizer tokens = PrepareTokens('"' + contents);

    tokens.String(out var result).Should().BeFalse();
    result.Should().Be(contents + " ");
  }

  [Theory, RepeatData(10)]
  public void String_DoubleWithSingleEnd_AfterReadTrue_IsFalse(
    [RegularExpression(IdentifierPattern)] string contents)
  {
    Tokenizer tokens = PrepareTokens('"' + contents + "'");

    tokens.String(out var result).Should().BeFalse();
    result.Should().Be(contents + "' ");
  }

  [Theory, RepeatData(10)]
  public void String_Single_AfterReadTrue_IsTrue(
    [RegularExpression(IdentifierPattern)] string contents)
  {
    Tokenizer tokens = PrepareTokens($"'{contents}'");

    tokens.String(out var result).Should().BeTrue();
    result.Should().Be(contents);
  }

  [Theory, RepeatData(10)]
  public void String_SingleWithNoEnd_AfterReadTrue_IsFalse(
    [RegularExpression(IdentifierPattern)] string contents)
  {
    Tokenizer tokens = PrepareTokens("'" + contents);

    tokens.String(out var result).Should().BeFalse();
    result.Should().Be(contents + " ");
  }

  [Theory, RepeatData(10)]
  public void String_SingleWithDoubleEnd_AfterReadTrue_IsFalse(
    [RegularExpression(IdentifierPattern)] string contents)
  {
    Tokenizer tokens = PrepareTokens("'" + contents + '"');

    tokens.String(out var result).Should().BeFalse();
    result.Should().Be(contents + '"' + ' ');
  }

  [Theory, RepeatData(10)]
  public void Regex_AfterReadTrue_IsTrue(
    [RegularExpression(IdentifierPattern)] string regex)
  {
    Tokenizer tokens = PrepareTokens($"/{regex}/");

    tokens.Regex(out var result).Should().BeTrue();
    result.Should().Be(regex);
  }

  [Theory, RepeatData(10)]
  public void Regex_WithNoEnd_AfterReadTrue_IsFalse(
    [RegularExpression(IdentifierPattern)] string regex)
  {
    Tokenizer tokens = PrepareTokens('/' + regex);

    tokens.Regex(out var result).Should().BeFalse();
    result.Should().Be(regex + " ");
  }

  [Theory, RepeatData(10)]
  public void Take_WithSingle_AfterRead_ReturnsTrue(
    [RegularExpression(PunctuationPattern)] string single)
  {
    Tokenizer tokens = PrepareTokens(single);
    var expected = single.First();

    tokens.Take(expected).Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void Take_WithString_AfterRead_ReturnsString(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    Tokenizer tokens = PrepareTokens(many);

    tokens.Take(many).Should().BeTrue();
  }

  [Theory, RepeatData(10)]
  public void Take_WithShort_AfterRead_ReturnsString(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    Tokenizer tokens = PrepareTokens(many[..4]);

    tokens.Take(many).Should().BeFalse();
  }

  [Theory, RepeatData(10)]
  public void TakeAny_WithMany_AfterRead_ReturnsChar(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    Tokenizer tokens = PrepareTokens(many);
    var expected = many.First();

    tokens.TakeAny(out var result, many.ToCharArray()).Should().BeTrue();
    result.Should().Be(expected);
  }

  [Theory, RepeatData(10)]
  public void Prefix_WithoutName_AfterRead_ReturnsNull(
    [RegularExpression(PunctuationPattern)] string prefix)
  {
    Tokenizer tokens = PrepareTokens(prefix + "?");
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
    Tokenizer tokens = PrepareTokens(prefix + identifier);
    var expected = prefix.First();

    tokens.Prefix(expected, out var result).Should().BeTrue();
    result.Should().Be(identifier);
  }
}
