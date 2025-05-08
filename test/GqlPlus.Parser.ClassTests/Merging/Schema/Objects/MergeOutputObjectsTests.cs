using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeOutputObjectsTests
  : TestObjectAsts<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
{
  private readonly MergeOutputObjects _merger;

  public MergeOutputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParams, Alternates);

  internal override AstObjectsMerger<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate> MergerObject => _merger;

  protected override IGqlpOutputObject MakeObject(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpObjBase? parent = default,
    string[]? typeParams = null,
    FieldInput[]? fields = null,
    AlternateInput[]? alternates = null)
    => new OutputDeclAst(AstNulls.At, name, description) {
      Aliases = aliases ?? [],
      Parent = parent,
      TypeParams = typeParams?.TypeParams() ?? [],
      ObjFields = fields?.OutputFields() ?? [],
      ObjAlternates = alternates?.OutputAlternates() ?? [],
    };

  protected override IGqlpOutputBase MakeBase(string type)
    => new OutputBaseAst(AstNulls.At, type);
}
