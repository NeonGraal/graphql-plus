using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Ast.Schema;

internal static class SchemaHelper
{
  internal static OptionSettingAst[] OptionSettings(this IEnumerable<string> settings)
    => [.. settings.Select(s => new OptionSettingAst(AstNulls.At, s, new FieldKeyAst(AstNulls.At, s)))];

  internal static UnionMemberAst[] UnionMembers(this string[] members)
    => [.. members.Select(m => new UnionMemberAst(AstNulls.At, m))];
}
