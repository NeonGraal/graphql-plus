namespace GqlPlus.Verifier.Ast.Schema;

internal static class SchemaHelper
{
  internal static ScalarRegexAst[] ScalarRegexes(this string regex, params string[] regexes)
    => [.. regexes.Select(r => new ScalarRegexAst(AstNulls.At, r, false)).Prepend(new(AstNulls.At, regex, true))];

  internal static ScalarReferenceAst[] ScalarReferences(this string reference, params string[] references)
    => [.. references.Select(r => new ScalarReferenceAst(AstNulls.At, r)).Prepend(new(AstNulls.At, reference))];

  internal static Map<ConstantAst> OptionSettings(this IEnumerable<string> settings)
    => settings.ToMap(k => k, v => (ConstantAst)new FieldKeyAst(AstNulls.At, v));
}
