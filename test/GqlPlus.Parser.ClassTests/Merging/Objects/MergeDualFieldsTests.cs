using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeDualFieldsTests(
  ITestOutputHelper outputHelper
) : TestObjectFields<IGqlpDualField, IGqlpDualBase>
{
  private readonly MergeDualFields _merger = new(outputHelper.ToLoggerFactory());

  internal override AstObjectFieldsMerger<IGqlpDualField> MergerField => _merger;

  protected override IGqlpDualField MakeAliased(string input, string[] aliases, string description = "")
    => new DualFieldAst(AstNulls.At, input, description, new DualBaseAst(AstNulls.At, input, description)) {
      Aliases = aliases
    };
  protected override IGqlpDualField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new DualFieldAst(AstNulls.At, name, fieldDescription, new DualBaseAst(AstNulls.At, type, typeDescription));
  protected override IGqlpDualField MakeFieldModifiers(string name)
    => new DualFieldAst(AstNulls.At, name, new DualBaseAst(AstNulls.At, name)) {
      Modifiers = TestMods()
    };
}
