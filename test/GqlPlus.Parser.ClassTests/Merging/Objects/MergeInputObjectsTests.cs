using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeInputObjectsTests
  : TestObjects<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase>
{
  private readonly MergeInputObjects _merger;

  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate> MergerObject => _merger;

  protected override InputDeclAst MakeObject(string name, string[]? aliases = null, string description = "", IGqlpObjBase? parent = default)
    => new(AstNulls.At, name, description) { Aliases = aliases ?? [], Parent = parent, };
  protected override InputFieldAst[] MakeFields(FieldInput[] fields)
    => fields.InputFields();
  protected override InputAlternateAst[] MakeAlternates(AlternateInput[] alternates)
    => alternates.InputAlternates();
  protected override InputBaseAst MakeBase(string type)
    => new(AstNulls.At, type);
}
