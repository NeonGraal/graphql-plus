using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeInputObjectsTests
  : TestObjects<IGqlpInputObject, IGqlpInputField, IGqlpInputAlternate, IGqlpInputBase>
{
  private readonly MergeInputObjects _merger;

  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate> MergerObject => _merger;

  protected override IGqlpInputObject MakeObject(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpObjBase? parent = default,
    string[]? typeParameters = null,
    FieldInput[]? fields = null,
    AlternateInput[]? alternates = null)
    => new InputDeclAst(AstNulls.At, name, description) {
      Aliases = aliases ?? [],
      Parent = parent,
      TypeParameters = typeParameters?.TypeParameters() ?? [],
      ObjFields = fields?.InputFields() ?? [],
      ObjAlternates = alternates?.InputAlternates() ?? [],
    };
  protected override IGqlpInputBase MakeBase(string type)
    => new InputBaseAst(AstNulls.At, type);
}
