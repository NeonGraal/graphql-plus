using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeInputObjectsTests
  : TestObjects<InputDeclAst, InputFieldAst, IGqlpInputBase>
{
  private readonly MergeInputObjects _merger;

  public MergeInputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<InputDeclAst, InputFieldAst, IGqlpInputBase> MergerObject => _merger;

  protected override InputDeclAst MakeObject(string name, string[]? aliases = null, string description = "", IGqlpInputBase? parent = default)
    => new(AstNulls.At, name, description) { Aliases = aliases ?? [], Parent = parent, };
  protected override InputFieldAst[] MakeFields(FieldInput[] fields)
    => fields.InputFields();
  protected override InputBaseAst MakeBase(string type)
    => new(AstNulls.At, type);
}
