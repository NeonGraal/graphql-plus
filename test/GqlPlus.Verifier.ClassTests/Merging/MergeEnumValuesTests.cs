using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeEnumValuesTests
  : TestAliased<EnumValueAst>
{
  private readonly MergeEnumValues _merger = new();

  protected override GroupsMerger<EnumValueAst> MergerGroups => _merger;

  protected override EnumValueAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description) { Aliases = aliases };
}
