using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;
using Xunit.Abstractions;

namespace GqlPlus.Schema.Objects;

public class MergeInputObjectsTests
  : TestObjects<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
{
  private readonly MergeInputObjects _merger;

  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParams, Alternates);

  internal override AstObjectsMerger<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate> MergerObject => _merger;

  protected override IGqlpInputObject MakeObject(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpObjBase? parent = default,
    string[]? typeParams = null,
    FieldInput[]? fields = null,
    AlternateInput[]? alternates = null)
    => new InputDeclAst(AstNulls.At, name, description) {
      Aliases = aliases ?? [],
      Parent = parent,
      TypeParams = typeParams?.TypeParams() ?? [],
      ObjFields = fields?.InputFields() ?? [],
      ObjAlternates = alternates?.InputAlternates() ?? [],
    };
  protected override IGqlpInputBase MakeBase(string type)
    => new InputBaseAst(AstNulls.At, type);
}
