namespace GqlPlus.Verifier.Ast.Schema;

internal static class SchemaHelper
{
  internal static ScalarRegexAst[] ScalarRegexes(this string regex, params string[] regexes)
    => [.. regexes.Select(r => new ScalarRegexAst(AstNulls.At, false, r)).Prepend(new(AstNulls.At, true, regex))];

  internal static ScalarReferenceAst[] ScalarReferences(this string reference, params string[] references)
    => [.. references.Select(r => new ScalarReferenceAst(AstNulls.At, r)).Prepend(new(AstNulls.At, reference))];

  internal static OptionSettingAst[] OptionSettings(this IEnumerable<string> settings)
    => [.. settings.Select(s => new OptionSettingAst(AstNulls.At, s, new FieldKeyAst(AstNulls.At, s)))];
}
