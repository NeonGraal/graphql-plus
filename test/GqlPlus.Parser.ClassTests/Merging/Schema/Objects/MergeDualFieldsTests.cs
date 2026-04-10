using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeDualFieldsTests(ITestOutputHelper outputHelper)
    : TestObjectFieldMerger<IAstDualField>
{
  private readonly MergeDualFields _merger = new(MergeRepo(outputHelper.ToLoggerFactory()));

  internal override AstObjectFieldsMerger<IAstDualField> MergerField => _merger;

  protected override IAstDualField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new DualFieldAst(AstNulls.At, name, fieldDescription, new ObjBaseAst(AstNulls.At, type, typeDescription)) {
      Aliases = aliases ?? [],
    };
  protected override IAstDualField MakeFieldEnum(string name, string enumType, string enumLabel, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new DualFieldAst(AstNulls.At, name, fieldDescription, new ObjBaseAst(AstNulls.At, enumType, typeDescription)) {
      Aliases = aliases ?? [],
      EnumValue = new EnumValueAst(AstNulls.At, enumType, enumLabel),
    };
  protected override IAstDualField MakeFieldModifiers(string name)
    => new DualFieldAst(AstNulls.At, name, new ObjBaseAst(AstNulls.At, name, "")) {
      Modifiers = TestMods(),
    };
}
