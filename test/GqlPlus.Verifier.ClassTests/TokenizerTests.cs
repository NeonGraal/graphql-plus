using System.Globalization;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier;

[TracePerTest]
public class TokenizerTests
{
  private static Tokenizer PrepareTokens(string input)
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

  [Fact]
  public void AtEnd_AfterReadFalse_IsTrue()
  {
    var tokens = new Tokenizer("");

    var result = tokens.Read();

    using var scope = new AssertionScope();

    result.Should().BeFalse();

    tokens.AtEnd.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Identifier_AfterRead_ReturnsIdentifier(string expected)
  {
    Tokenizer tokens = PrepareTokens(expected);

    TrueAndExpected(tokens.Identifier, expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Number_AfterReadTrue_IsTrue(decimal expected)
  {
    Tokenizer tokens = PrepareTokens(expected.ToString(CultureInfo.InvariantCulture));

    TrueAndExpected(tokens.Number, expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Number_WithDecimal_AfterReadTrue_IsTrue(decimal expected)
  {
    Tokenizer tokens = PrepareTokens(expected.ToString(CultureInfo.InvariantCulture));

    TrueAndExpected(tokens.Number, expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Number_WithSeparator_AfterReadTrue_IsTrue(decimal expected)
  {
    var input = string.Join("_",
        expected.ToString(CultureInfo.InvariantCulture)
        .Select(c => c.ToString()))
      .Replace("_._", ".")
      .Replace("-_", "-");
    Tokenizer tokens = PrepareTokens(input);

    TrueAndExpected(tokens.Number, expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Number_Identifier_AfterReadTrue_IsFalse(string identifier)
  {
    Tokenizer tokens = PrepareTokens(identifier);

    FalseAndExpected<decimal>(tokens.Number, default);
  }

  [Theory, RepeatData(Repeats)]
  public void String_Double_AfterReadTrue_IsTrue(string sample)
  {
    Tokenizer tokens = PrepareTokens('"' + sample + '"');

    TrueAndExpected(tokens.String, sample);
  }

  [Theory, RepeatData(Repeats)]
  public void String_DoubleWithNoEnd_AfterReadTrue_IsFalse(string sample)
  {
    Tokenizer tokens = PrepareTokens('"' + sample);

    FalseAndExpected(tokens.String, sample + " ", tokens);
  }

  [Theory, RepeatData(Repeats)]
  public void String_DoubleWithSingleEnd_AfterReadTrue_IsFalse(string sample)
  {
    Tokenizer tokens = PrepareTokens('"' + sample + "'");

    FalseAndExpected(tokens.String, sample + "' ", tokens);
  }

  [Theory, RepeatData(Repeats)]
  public void String_Single_AfterReadTrue_IsTrue(string sample)
  {
    Tokenizer tokens = PrepareTokens($"'{sample}'");

    TrueAndExpected(tokens.String, sample);
  }

  [Theory, RepeatData(Repeats)]
  public void String_SingleWithNoEnd_AfterReadTrue_IsFalse(string sample)
  {
    Tokenizer tokens = PrepareTokens("'" + sample);

    FalseAndExpected(tokens.String, sample + " ", tokens);
  }

  [Theory, RepeatData(Repeats)]
  public void String_SingleWithDoubleEnd_AfterReadTrue_IsFalse(string sample)
  {
    Tokenizer tokens = PrepareTokens("'" + sample + '"');

    FalseAndExpected(tokens.String, sample + '"' + ' ');
  }

  [Theory, RepeatData(Repeats)]
  public void String_Identifier_AfterReadTrue_IsFalse(string identifier)
  {
    Tokenizer tokens = PrepareTokens(identifier);

    FalseAndExpected(tokens.String, "");
  }

  [Theory, RepeatData(Repeats)]
  public void Regex_AfterReadTrue_IsTrue(string regex)
  {
    Tokenizer tokens = PrepareTokens($"/{regex}/");

    TrueAndExpected(tokens.Regex, regex);
  }

  [Theory, RepeatData(Repeats)]
  public void Regex_WithNoEnd_AfterReadTrue_IsFalse(string regex)
  {
    Tokenizer tokens = PrepareTokens('/' + regex);

    FalseAndExpected(tokens.Regex, regex + " ", tokens);
  }

  [Theory, RepeatData(Repeats)]
  public void Regex_WithNoStart_AfterReadTrue_IsFalse(string regex)
  {
    Tokenizer tokens = PrepareTokens(regex + '/');

    FalseAndExpected(tokens.Regex, "");
  }

  [Theory, RepeatData(Repeats)]
  public void Take_WithSingle_AfterRead_ReturnsTrue(
    [RegularExpression(PunctuationPattern)] string one)
  {
    Tokenizer tokens = PrepareTokens(one);
    var expected = one.First();

    tokens.Take(expected).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Take_WithString_AfterRead_ReturnsString(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    Tokenizer tokens = PrepareTokens(many);

    tokens.Take(many).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Take_WithShort_AfterRead_ReturnsString(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    Tokenizer tokens = PrepareTokens(many[..4]);

    tokens.Take(many).Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void TakeAny_WithMany_AfterRead_ReturnsChar(
    [RegularExpression(PunctuationPattern + "{5}")] string many)
  {
    Tokenizer tokens = PrepareTokens(many);
    var expected = many.First();

    TrueAndExpected(
      (out char result) => tokens.TakeAny(out result, many.ToCharArray()),
      expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Prefix_WithoutName_AfterRead_ReturnsNull(
    [RegularExpression(PunctuationPattern)] string prefix)
  {
    Tokenizer tokens = PrepareTokens(prefix + "?");
    var expected = prefix.First();

    using var scope = new AssertionScope();

    tokens.Prefix(expected, out _, out _).Should().BeFalse();
    tokens.Take(expected).Should().BeTrue();
    tokens.Take('?').Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Prefix_WithName_AfterRead_ReturnsCharThenName(
    [RegularExpression(PunctuationPattern)] string prefix, string identifier)
  {
    Tokenizer tokens = PrepareTokens(prefix + identifier);
    var expected = prefix.First();

    TrueAndExpected(
      (out string? result) => tokens.Prefix(expected, out result, out var _),
      identifier);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_AtStart_ReturnsAtStart(string message)
  {
    var tokens = new Tokenizer("");

    var result = tokens.Error(message);

    CheckParseError(result, TokenKind.Start, "<END>", message, 0);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforePunctuationAtEnd_ReturnsAtPunctuation(
    [RegularExpression(PunctuationPattern)] string prefix, string message)
  {
    var tokens = PrepareTokens(prefix);
    var expected = prefix.ToString() + " <END>";

    var result = tokens.Error(message);

    CheckParseError(result, TokenKind.Punctuation, expected, message);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforePunctuation_ReturnsAtPunctuation(
    [RegularExpression(PunctuationPattern)] string prefix, string contents, string message)
  {
    var tokens = PrepareTokens(prefix + contents);
    var expected = Tokenizer.ErrorContext(prefix + contents);

    var result = tokens.Error(message);

    CheckParseError(result, TokenKind.Punctuation, expected, message);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforeIdentifier_ReturnsAtIdentifier(string value, string message)
  {
    var tokens = PrepareTokens(value);

    var result = tokens.Error(message);

    CheckParseError(result, TokenKind.Identifer, value, message);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforeNumber_ReturnsAtNumber(decimal number, string message)
  {
    var expected = number.ToString(CultureInfo.InvariantCulture);
    var tokens = PrepareTokens(expected);

    var result = tokens.Error(message);

    CheckParseError(result, TokenKind.Number, expected, message);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforeString_ReturnsAtString(string contents, string message)
  {
    var tokens = PrepareTokens(contents.Quote());
    var expected = Tokenizer.ErrorContext(contents.Quote());

    var result = tokens.Error(message);

    CheckParseError(result, TokenKind.String, expected, message);
  }

  private static void CheckParseError(TokenMessage result, TokenKind kind, string expected, string message, int pos = 1)
  {
    using var scope = new AssertionScope();

    result.Kind.Should().Be(kind);
    result.Line.Should().Be(pos);
    result.Column.Should().Be(pos);
    result.Next.Should().Be(expected);
    result.Message.Should().Be(message);
  }

  private delegate bool Call<T>(out T result);

  private static void TrueAndExpected<T>(Call<T> call, T expected)
  {
    var success = call(out var result);

    using var scope = new AssertionScope();

    success.Should().BeTrue();
    result.Should().Be(expected);
  }

  private static void FalseAndExpected<T>(Call<T> call, T expected)
  {
    var success = call(out var result);

    using var scope = new AssertionScope();

    success.Should().BeFalse();
    result.Should().Be(expected);
  }

  private static void FalseAndExpected<T>(Call<T> call, T expected, Tokenizer tokens)
  {
    var success = call(out var result);

    using var scope = new AssertionScope();

    success.Should().BeFalse();
    result.Should().Be(expected);
    tokens.AtEnd.Should().BeTrue();
  }
}
