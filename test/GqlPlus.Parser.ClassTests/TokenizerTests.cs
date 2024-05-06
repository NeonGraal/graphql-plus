﻿using System.Globalization;
using GqlPlus.Token;

namespace GqlPlus;

[TracePerTest]
public class TokenizerTests
{
  private static Tokenizer PrepareTokens(string input)
  {
    Tokenizer tokens = new(input + " ");

    tokens.Read().Should().BeTrue();

    return tokens;
  }

  [Fact]
  public void AtStart_WhenConstructed_IsTrue()
  {
    Tokenizer tokens = new("");

    tokens.AtStart.Should().BeTrue();
  }

  [Fact]
  public void AtEnd_AfterReadFalse_IsTrue()
  {
    Tokenizer tokens = new("");

    bool result = tokens.Read();

    using AssertionScope scope = new();

    result.Should().BeFalse();

    tokens.AtEnd.Should().BeTrue();
  }

  [Theory]
  [InlineData(" ")]
  [InlineData("\t")]
  [InlineData("\n")]
  [InlineData("\r")]
  [InlineData("\r\n")]
  [InlineData("# ")]
  [InlineData("# \n")]
  [InlineData("# \r")]
  [InlineData("# \r\n")]
  public void AtEnd_AfterWhitespace_AfterReadFalse_IsTrue(string input)
  {
    Tokenizer tokens = new(input);

    bool result = tokens.Read();

    using AssertionScope scope = new();

    result.Should().BeFalse();

    tokens.AtEnd.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Identifier_AfterRead_ReturnsIdentifier(string expected)
  {
    Tokenizer tokens = PrepareTokens(expected);

    TrueAndExpected(tokens.Identifier, expected);
  }

  [Theory]
  [RepeatInlineData(Repeats, "# \n")]
  [RepeatInlineData(Repeats, "# \r")]
  [RepeatInlineData(Repeats, "# \r\n")]
  public void Identifier_AfterComment_ReturnsIdentifier(string comment, string expected)
  {
    Tokenizer tokens = PrepareTokens(comment + expected);

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
    string input = string.Join("_",
        expected.ToString(CultureInfo.InvariantCulture)
        .Select(c => c.ToString()))
      .Replace("_._", ".", StringComparison.Ordinal)
      .Replace("-_", "-", StringComparison.Ordinal);
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
    char expected = one.First();

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
    char expected = many.First();

    TrueAndExpected(
      (out char result) => tokens.TakeAny(out result, many.ToCharArray()),
      expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Prefix_WithoutName_AfterRead_ReturnsNull(
    [RegularExpression(PunctuationPattern)] string prefix)
  {
    Tokenizer tokens = PrepareTokens(prefix + "?");
    char expected = prefix.First();

    using AssertionScope scope = new();

    tokens.Prefix(expected, out _, out _).Should().BeFalse();
    tokens.Take(expected).Should().BeTrue();
    tokens.Take('?').Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Prefix_WithName_AfterRead_ReturnsCharThenName(
    [RegularExpression(PunctuationPattern)] string prefix, string identifier)
  {
    Tokenizer tokens = PrepareTokens(prefix + identifier);
    char expected = prefix.First();

    TrueAndExpected(
      (out string? result) => tokens.Prefix(expected, out result, out TokenAt _),
      identifier);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_AtStart_ReturnsAtStart(string message)
  {
    Tokenizer tokens = new("");

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.Start, "<END>", message, 0, 0);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforePunctuationAtEnd_ReturnsAtPunctuation(
    [RegularExpression(PunctuationPattern)] string prefix, string message)
  {
    Tokenizer tokens = PrepareTokens(prefix);
    string expected = $"{prefix} <END>";

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.Punctuation, expected, message);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforePunctuation_ReturnsAtPunctuation(
    [RegularExpression(PunctuationPattern)] string prefix, string contents, string message)
  {
    Tokenizer tokens = PrepareTokens(prefix + contents);
    string expected = Tokenizer.ErrorContext(prefix + contents);

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.Punctuation, expected, message);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforeIdentifier_ReturnsAtIdentifier(string value, string message)
  {
    Tokenizer tokens = PrepareTokens(value);

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.Identifer, value, message);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforeNumber_ReturnsAtNumber(decimal number, string message)
  {
    string expected = number.ToString(CultureInfo.InvariantCulture);
    Tokenizer tokens = PrepareTokens(expected);

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.Number, expected, message);
  }

  [Theory, RepeatData(Repeats)]
  public void Error_BeforeString_ReturnsAtString(string contents, string message)
  {
    Tokenizer tokens = PrepareTokens(contents.Quote());
    string expected = Tokenizer.ErrorContext(contents.Quote());

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.String, expected, message);
  }

  [Theory]
  [RepeatInlineData(Repeats, " ")]
  [RepeatInlineData(Repeats, "\t")]
  public void Error_AfterWhitespace_ReturnsAtIdentifier(string space, string value, string message)
  {
    Tokenizer tokens = PrepareTokens(space + value);

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.Identifer, value, message, col: 2);
  }

  [Theory]
  [RepeatInlineData(Repeats, "\r")]
  [RepeatInlineData(Repeats, "\n")]
  [RepeatInlineData(Repeats, "\r\n")]
  public void Error_AfterLine_ReturnsAtIdentifier(string line, string value, string message)
  {
    Tokenizer tokens = PrepareTokens(line + value);

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.Identifer, value, message, 2);
  }

  [Theory]
  [RepeatInlineData(Repeats, "# \r")]
  [RepeatInlineData(Repeats, "# \n")]
  [RepeatInlineData(Repeats, "# \r\n")]
  public void Error_AfterComment_ReturnsAtIdentifier(string comment, string value, string message)
  {
    Tokenizer tokens = PrepareTokens(comment + value);

    TokenMessage result = tokens.Error(message);

    CheckParseError(result, TokenKind.Identifer, value, message, 2);
  }

  private static void CheckParseError(TokenMessage result, TokenKind kind, string expected, string message, int line = 1, int col = 1)
  {
    using AssertionScope scope = new();

    result.Kind.Should().Be(kind);
    result.Line.Should().Be(line);
    result.Column.Should().Be(col);
    result.After.Should().Be(expected);
    result.Message.Should().Be(message);
  }

  private delegate bool Call<T>(out T result);

  private static void TrueAndExpected<T>(Call<T> call, T expected)
  {
    bool success = call(out T? result);

    using AssertionScope scope = new();

    success.Should().BeTrue();
    result.Should().Be(expected);
  }

  private static void FalseAndExpected<T>(Call<T> call, T expected)
  {
    bool success = call(out T? result);

    using AssertionScope scope = new();

    success.Should().BeFalse();
    result.Should().Be(expected);
  }

  private static void FalseAndExpected<T>(Call<T> call, T expected, Tokenizer tokens)
  {
    bool success = call(out T? result);

    using AssertionScope scope = new();

    success.Should().BeFalse();
    result.Should().Be(expected);
    tokens.AtEnd.Should().BeTrue();
  }
}
