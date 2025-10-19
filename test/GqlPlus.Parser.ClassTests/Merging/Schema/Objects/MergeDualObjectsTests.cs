using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeDualObjectsTests
  : TestObjectMerger<IGqlpDualObject, IGqlpDualField>
{
  private readonly MergeDualObjects _merger;

  public MergeDualObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParams, Alternates);

  internal override AstObjectsMerger<IGqlpDualObject, IGqlpDualField> MergerObject => _merger;

  protected override IGqlpDualObject MakeObject(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpObjBase? parent = default,
    string[]? typeParams = null,
    FieldInput[]? fields = null,
    AlternateInput[]? alternates = null)
    => new DualDeclAst(AstNulls.At, name, description) {
      Aliases = aliases ?? [],
      Parent = parent,
      TypeParams = typeParams?.TypeParams() ?? [],
      ObjFields = fields?.DualFields() ?? [],
      Alternates = alternates?.Alternates() ?? []
    };
  protected override IGqlpObjBase MakeBase(string type)
    => new ObjBaseAst(AstNulls.At, type, "");
}
