using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeDualObjectsTests
  : TestObjects<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{
  private readonly MergeDualObjects _merger;

  public MergeDualObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParams, Alternates);

  internal override AstObjectsMerger<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate> MergerObject => _merger;

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
      ObjAlternates = alternates?.DualAlternates() ?? []
    };
  protected override IGqlpDualBase MakeBase(string type)
    => new DualBaseAst(AstNulls.At, type);
}
