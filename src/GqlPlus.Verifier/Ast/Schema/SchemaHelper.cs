namespace GqlPlus.Verifier.Ast.Schema;

internal static class SchemaHelper
{
  internal static OptionSettingAst[] OptionSettings(this IEnumerable<string> settings)
    => [.. settings.Select(s => new OptionSettingAst(AstNulls.At, s, new FieldKeyAst(AstNulls.At, s)))];
}
