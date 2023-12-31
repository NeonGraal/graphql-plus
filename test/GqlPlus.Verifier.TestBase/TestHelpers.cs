using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier;

public static class TestHelpers
{
  public const int Repeats = 5;
  public const int CiRepeats = 25;

  public const string IdentifierPattern = @"[A-Za-z][A-Za-z0-9_]*";
  public const string PunctuationPattern = @"[!#-&(-*.:<-@[-^`{-~]";

  public static FieldKeyAst FieldKey(this string value)
    => new(AstNulls.At, "", value);

  public static ConstantAst[] ConstantList(this string value)
    => new ConstantAst[] {
      value.FieldKey(),
      value.FieldKey()
    };

  public static AstObject<ConstantAst> ConstantObject(this string value, string key)
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
    contents = contents.Replace(@"\", @"\\");
    return contents.Contains('"')
      ? contents.Contains('\'')
        ? "'" + contents.Replace("'", @"\'") + "'"
        : $"'{contents}'"
      : '"' + contents + '"';
  }

  public static string BlockQuote(this string contents)
  {
    const string TripleQuote = "\"\"\"";
    contents = contents.Replace(@"\", @"\\");
    if (contents.Last() == '"') {
      contents = contents[..^1] + "\\\"";
    }

    contents = contents.Replace(TripleQuote, '\\' + TripleQuote);
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
}
