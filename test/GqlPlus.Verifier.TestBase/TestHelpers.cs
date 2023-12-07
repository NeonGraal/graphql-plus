using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier;

public static class TestHelpers
{
  public const int Repeats = 5;
  public const int CiRepeats = 25;

  public const string IdentifierPattern = @"[A-Za-z][A-Za-z0-9_]*";
  public const string PunctuationPattern = @"[!#-&(-*.:<-@[-^`{-~]";

  public static FieldKeyAst FieldKey(this string label)
    => new(AstNulls.At, "", label);

  public static ConstantAst[] ConstantList(this string label)
    => new ConstantAst[] {
      label.FieldKey(),
      label.FieldKey()
    };

  public static AstObject<ConstantAst> ConstantObject(this string label, string key)
  {
    var keyAst = key.FieldKey();
    var labelAst = label.FieldKey();

    return key == label
      ? new() { [keyAst] = labelAst }
      : new() { [keyAst] = labelAst, [labelAst] = keyAst };
  }

  public static TokenMessage ParseMessage(this string message)
    => new(AstNulls.At, message);

  public static string Quote(this string contents)
  {
    contents = contents.Replace(@"\", @"\\");
    return contents.Contains('"')
      ? contents.Contains("'")
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
}
