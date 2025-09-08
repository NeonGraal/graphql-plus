using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeDualFieldsTests(
  ITestOutputHelper outputHelper
) : TestObjectFieldMerger<IGqlpDualField, IGqlpDualBase>
{
  private readonly MergeDualFields _merger = new(outputHelper.ToLoggerFactory());

  internal override AstObjectFieldsMerger<IGqlpDualField> MergerField => _merger;

  protected override IGqlpDualField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new DualFieldAst(AstNulls.At, name, fieldDescription, new DualBaseAst(AstNulls.At, type, typeDescription)) {
      Aliases = aliases ?? [],
    };
  protected override IGqlpDualField MakeFieldEnum(string name, string enumType, string enumLabel, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new DualFieldAst(AstNulls.At, name, fieldDescription, new DualBaseAst(AstNulls.At, enumType, typeDescription)) {
      Aliases = aliases ?? [],
      EnumLabel = enumLabel,
    };
  protected override IGqlpDualField MakeFieldModifiers(string name)
    => new DualFieldAst(AstNulls.At, name, new DualBaseAst(AstNulls.At, name)) {
      Modifiers = TestMods(),
    };
}
