using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeOutputObjectsTests
  : TestObjects<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputBase>
{
  private readonly MergeOutputObjects _merger;

  public MergeOutputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate> MergerObject => _merger;

  protected override IGqlpOutputObject MakeObject(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpObjBase? parent = default,
    string[]? typeParameters = null,
    FieldInput[]? fields = null,
    AlternateInput[]? alternates = null)
    => new OutputDeclAst(AstNulls.At, name, description) {
      Aliases = aliases ?? [],
      Parent = parent,
      TypeParameters = typeParameters?.TypeParameters() ?? [],
      ObjFields = fields?.OutputFields() ?? [],
      ObjAlternates = alternates?.OutputAlternates() ?? [],
    };

  protected override IGqlpOutputBase MakeBase(string type)
    => new OutputBaseAst(AstNulls.At, type);
}
