﻿namespace GqlPlus.Verifier.ClassTests;

internal static class TestHelpers
{
  internal const int Repeats = 5;
  internal const int CiRepeats = 25;

  internal const string IdentifierPattern = @"[A-Za-z][A-Za-z0-9_]*";
  internal const string PunctuationPattern = @"[!#-&(-*.:<-@[-^`{-~]";

  public static ConstantAst[] ConstantList(this string label)
    => new ConstantAst[] {
      new FieldKeyAst(AstNulls.At, "", label),
      new FieldKeyAst(AstNulls.At, "", label)
    };

  public static ConstantAst.ObjectAst ConstantObject(this string label, string key)
  {
    var keyAst = new FieldKeyAst(AstNulls.At, "", key);
    var labelAst = new FieldKeyAst(AstNulls.At, "", label);

    return key == label
      ? new ConstantAst.ObjectAst { [keyAst] = labelAst }
      : new ConstantAst.ObjectAst { [keyAst] = labelAst, [labelAst] = keyAst };
  }

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
