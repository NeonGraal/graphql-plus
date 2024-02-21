namespace GqlPlus.Verifier.Ast.Schema;

internal static class SchemaHelper
{
  internal static ScalarTrueFalseAst[] ScalarTrueFalses(this bool[] members)
    => [.. members.Select(r => new ScalarTrueFalseAst(AstNulls.At, false, r))];

  internal static ScalarMemberAst[] ScalarMembers(this string[] members)
    => [.. members.Select(r => new ScalarMemberAst(AstNulls.At, false, r))];

  internal static ScalarRegexAst[] ScalarRegexes(this string[] regexes)
    => [.. regexes.Select(r => new ScalarRegexAst(AstNulls.At, false, r))];

  internal static ScalarReferenceAst[] ScalarReferences(this string reference, params string[] references)
    => [.. references.Select(r => new ScalarReferenceAst(AstNulls.At, r)).Prepend(new(AstNulls.At, reference))];

  internal static OptionSettingAst[] OptionSettings(this IEnumerable<string> settings)
    => [.. settings.Select(s => new OptionSettingAst(AstNulls.At, s, new FieldKeyAst(AstNulls.At, s)))];
}
