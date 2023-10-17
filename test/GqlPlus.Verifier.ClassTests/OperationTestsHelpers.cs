using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.ClassTests;

internal static class OperationTestsHelpers
{
  internal const int Repeats = 20;

  internal const string IdentifierPattern = @"[A-Za-z][A-Za-z0-9_]*";
  internal const string PunctuationPattern = @"[!#-&(-*.:<-@[-^`{-~]";

  public static DirectiveAst[] Directives(this string directive)
    => new DirectiveAst[] { new(AstNulls.At, directive) };

  public static AstSelection[] Fields(this string field)
    => new FieldAst[] { new(AstNulls.At, field) };

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

  public static ArgumentAst[] ArgumentList(this string label)
    => new ArgumentAst[] { new(AstNulls.At, label), new FieldKeyAst(AstNulls.At, "", label) };

  public static ArgumentAst.ObjectAst ArgumentObject(this string label, string key)
  {
    var keyAst = new FieldKeyAst(AstNulls.At, "", key);
    var labelAst = new FieldKeyAst(AstNulls.At, "", label);

    return key == label
      ? new ArgumentAst.ObjectAst { [keyAst] = new(AstNulls.At, label) }
      : new ArgumentAst.ObjectAst { [keyAst] = new(AstNulls.At, label), [labelAst] = keyAst };
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

  public static void TestString<T>(this T input, string expected)
    => $"{input}".Should().Be(expected);

  public static void TestString<T>(this T input, string expected, bool skpiIf)
  {
    if (skpiIf) {
      return;
    }

    $"{input}".Should().Be(expected);
  }
}
