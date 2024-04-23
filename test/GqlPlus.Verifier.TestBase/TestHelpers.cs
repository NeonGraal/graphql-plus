using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Token;
using Xunit;

namespace GqlPlus.Verifier;

public static class TestHelpers
{
  public const int Repeats = 5;
  public const int CiRepeats = 25;

  public const string IdentifierPattern = @"[A-Za-z][A-Za-z0-9_]*";
  public const string PunctuationPattern = @"[!$-&(-*.:<-@[-^`{-~]";

  public static FieldKeyAst FieldKey(this string value)
    => new(AstNulls.At, "", value);

  public static ConstantAst[] ConstantList(this string value)
    => new ConstantAst[] {
      value.FieldKey(),
      value.FieldKey()
    };

  public static AstFields<ConstantAst> ConstantObject(this string value, string key)
  {
    var keyAst = key.FieldKey();
    var valueAst = value.FieldKey();

    return key == value
      ? new() { [keyAst] = valueAst }
      : new() { [keyAst] = valueAst, [valueAst] = keyAst };
  }

  public static TokenMessage ParseMessage(this string message)
    => new(AstNulls.At, message);

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

  public static Tokenizer Tokens(string input)
  {
    var tokens = new Tokenizer(input);
    tokens.Read();
    return tokens;
  }

  public static ModifierAst[] TestMods()
    => new[] { ModifierAst.List(AstNulls.At), ModifierAst.Optional(AstNulls.At) };

  public static ModifierAst[] TestCollections()
    => new[] { ModifierAst.List(AstNulls.At), new(AstNulls.At, "String", false) };

  public static TCheck SkipIf<TCheck>(this TCheck check, bool skipIf, [CallerArgumentExpression(nameof(skipIf))] string? skipExpression = null)
  {
    Skip.If(skipIf, skipExpression);

    return check;
  }

  public static TCheck SkipNull<TCheck>(this TCheck check, [NotNull] object? obj, [CallerArgumentExpression(nameof(obj))] string? objExpression = null)
  {
    Skip.If(obj is null, objExpression + " is null");

    return check;
  }

  public static TCheck SkipUnless<TCheck>(this TCheck check, [NotNull] string[]? array, [CallerArgumentExpression(nameof(array))] string? arrayExpression = null)
  {
    Skip.If(array is null, arrayExpression + " is null");
    Skip.If(array.Length < 2, arrayExpression + ".Length < 2");

    return check;
  }
}
