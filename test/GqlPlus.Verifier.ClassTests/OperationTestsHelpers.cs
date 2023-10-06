using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.ClassTests;

internal static class OperationTestsHelpers
{
  internal const int Repeats = 20;

  internal const string IdentifierPattern = @"[A-Za-z][A-Za-z0-9_]*";
  internal const string PunctuationPattern = @"[!#-&(-+.:<-@[-^`{-~]";

  public static DirectiveAst[] Directives(this string directive)
    => new DirectiveAst[] { new(directive) };

  public static AstSelection[] Fields(this string field)
    => new FieldAst[] { new(field) };

  public static ConstantAst[] ConstantList(this string label)
    => new ConstantAst[] { new FieldKeyAst("", label), new FieldKeyAst("", label) };

  public static ConstantAst.ObjectAst ConstantObject(this string label, string key)
  {
    var keyAst = new FieldKeyAst("", key);
    var labelAst = new FieldKeyAst("", label);
    return new ConstantAst.ObjectAst { [keyAst] = labelAst, [labelAst] = keyAst };
  }

  public static ArgumentAst[] ArgumentList(this string label)
    => new ArgumentAst[] { new(label), new FieldKeyAst("", label) };

  public static ArgumentAst.ObjectAst ArgumentObject(this string label, string key)
  {
    var keyAst = new FieldKeyAst("", key);
    var labelAst = new FieldKeyAst("", label);
    return new ArgumentAst.ObjectAst { [keyAst] = new(label), [labelAst] = keyAst };
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

  public static Tokenizer Tokens(string input)
  {
    var tokens = new Tokenizer(input);
    tokens.Read();
    return tokens;
  }

  public static ModifierAst[] TestMods()
    => new[] { ModifierAst.List, ModifierAst.Optional };

  public static void TestString<T>(this T input, string expected)
    => $"{input}".Should().Be(expected);
}
