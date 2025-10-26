using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using GqlPlus.Abstractions;
using GqlPlus.Token;
using Xunit;

namespace GqlPlus;

public static class TestHelpers
{
  public const int Repeats = 5;
  public const int CiRepeats = 25;

  public const string IdentifierPattern = @"[A-Za-z][A-Za-z0-9_]*";
  public const string PunctuationPattern = @"[!$-&(-*.:<-@[-^`{-~]";

  public static string Quote(this string contents)
  {
    if (contents is null) {
      return "";
    }

    contents = contents.Replace(@"\", @"\\", StringComparison.Ordinal);
    return contents.Contains('"', StringComparison.Ordinal)
      ? contents.Contains('\'', StringComparison.Ordinal)
        ? "'" + contents.Replace("'", @"\'", StringComparison.Ordinal) + "'"
        : $"'{contents}'"
      : '"' + contents + '"';
  }

  public static string BlockQuote(this string contents)
  {
    if (contents is null) {
      return "";
    }

    const string TripleQuote = "\"\"\"";
    contents = contents.Replace(@"\", @"\\", StringComparison.Ordinal);
    if (contents.Last() == '"') {
      contents = contents[..^1] + "\\\"";
    }

    contents = contents.Replace(TripleQuote, '\\' + TripleQuote, StringComparison.Ordinal);
    return TripleQuote + contents + TripleQuote;
  }

  public static ITokenizer Tokens(string input)
  {
    Tokenizer tokens = new(input);
    tokens.Read();
    return tokens;
  }

  public static TCheck SkipIf<TCheck>(this TCheck check, bool skipIf, [CallerArgumentExpression(nameof(skipIf))] string? skipExpression = null)
  {
    Assert.SkipWhen(skipIf, skipExpression.IfWhiteSpace());

    return check;
  }

  public static TCheck SkipEqual<TCheck>(
    this TCheck check,
    string? input1,
    string? input2,
    [CallerArgumentExpression(nameof(input1))] string? input1Expression = null,
    [CallerArgumentExpression(nameof(input2))] string? input2Expression = null)
    => check.SkipIf(string.Equals(input1, input2, StringComparison.Ordinal), input1Expression + " != " + input2Expression);

  public static TCheck SkipEqual<TCheck>(
    this TCheck check,
    object? input1,
    object? input2,
    [CallerArgumentExpression(nameof(input1))] string? input1Expression = null,
    [CallerArgumentExpression(nameof(input2))] string? input2Expression = null)
    => check.SkipIf(input1 is null ? input2 is null :
      input1 is IEnumerable<object> enumerable1 && input2 is IEnumerable<object> enumerable2
      ? enumerable1.SequenceEqual(enumerable2)
      : input1.Equals(input2), input1Expression + " != " + input2Expression);

  public static TCheck SkipEqual3<TCheck>(
    this TCheck check,
    string? input1,
    string? input2,
    string? input3,
    [CallerArgumentExpression(nameof(input1))] string? input1Expression = null,
    [CallerArgumentExpression(nameof(input2))] string? input2Expression = null,
    [CallerArgumentExpression(nameof(input3))] string? input3Expression = null)
    => check
      .SkipIf(string.Equals(input1, input2, StringComparison.Ordinal), input1Expression + " != " + input2Expression)
      .SkipIf(string.Equals(input1, input3, StringComparison.Ordinal), input1Expression + " != " + input3Expression)
      .SkipIf(string.Equals(input2, input3, StringComparison.Ordinal), input2Expression + " != " + input3Expression);

  public static TCheck SkipNull<TCheck>(this TCheck check, [NotNull] object? obj, [CallerArgumentExpression(nameof(obj))] string? objExpression = null)
  {
    Assert.SkipWhen(obj is null, objExpression + " is null");

    return check;
  }

  public static TCheck SkipWhitespace<TCheck>(this TCheck check, [NotNull] string? str, [CallerArgumentExpression(nameof(str))] string? objExpression = null)
  {
    Assert.SkipWhen(string.IsNullOrWhiteSpace(str), objExpression + " is null, empty or only whitespace");

    return check;
  }

  public static TCheck SkipUnless<TCheck>(this TCheck check, [NotNull] string[]? array, [CallerArgumentExpression(nameof(array))] string? arrayExpression = null)
  {
    Assert.SkipWhen(array is null, arrayExpression + " is null");
    Assert.SkipWhen(array.Length < 2, arrayExpression + ".Length < 2");

    return check;
  }
}
