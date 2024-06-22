using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeDualObjectsTests
  : TestObjects<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase>
{
  private readonly MergeDualObjects _merger;

  public MergeDualObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate> MergerObject => _merger;

  protected override DualDeclAst MakeObject(string name, string[]? aliases = null, string description = "", IGqlpObjBase? parent = default)
    => new(AstNulls.At, name, description) { Aliases = aliases ?? [], Parent = parent };
  protected override DualFieldAst[] MakeFields(FieldInput[] fields)
    => fields.DualFields();
  protected override DualAlternateAst[] MakeAlternates(AlternateInput[] alternates)
    => alternates.DualAlternates();
  protected override DualBaseAst MakeBase(string type)
    => new(AstNulls.At, type);
}
