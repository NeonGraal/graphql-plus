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

  public static IGqlpFieldKey FieldKey(this string value)
    => new FieldKeyAst(AstNulls.At, "", value);

  public static IGqlpConstant[] ConstantList(this string value)
    => [
      new ConstantAst(value.FieldKey()),
      new ConstantAst(value.FieldKey())
    ];

  public static IGqlpFields<IGqlpConstant> ConstantObject(this string value, string key)
  {
    IGqlpFieldKey keyAst = key.FieldKey();
    IGqlpFieldKey valueAst = value.FieldKey();

    return key == value
      ? new AstFields<IGqlpConstant>() { [keyAst] = new ConstantAst(valueAst) }
      : new AstFields<IGqlpConstant>() { [keyAst] = new ConstantAst(valueAst), [valueAst] = new ConstantAst(keyAst) };
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

  public static ITokenizer Tokens(string input)
  {
    Tokenizer tokens = new(input);
    tokens.Read();
    return tokens;
  }

  public static IGqlpModifier[] TestMods()
    => [ModifierAst.List(AstNulls.At), ModifierAst.Optional(AstNulls.At)];

  public static IGqlpModifier[] TestCollections()
    => [ModifierAst.List(AstNulls.At), ModifierAst.Dict(AstNulls.At, "String", false)];

  public static TCheck SkipIf<TCheck>(this TCheck check, bool skipIf, [CallerArgumentExpression(nameof(skipIf))] string? skipExpression = null)
  {
    Assert.SkipWhen(skipIf, skipExpression ?? "");

    return check;
  }

  public static TCheck SkipNull<TCheck>(this TCheck check, [NotNull] object? obj, [CallerArgumentExpression(nameof(obj))] string? objExpression = null)
  {
    Assert.SkipWhen(obj is null, objExpression + " is null");

    return check;
  }

  public static TCheck SkipUnless<TCheck>(this TCheck check, [NotNull] string[]? array, [CallerArgumentExpression(nameof(array))] string? arrayExpression = null)
  {
    Assert.SkipWhen(array is null, arrayExpression + " is null");
    Assert.SkipWhen(array.Length < 2, arrayExpression + ".Length < 2");

    return check;
  }
}
