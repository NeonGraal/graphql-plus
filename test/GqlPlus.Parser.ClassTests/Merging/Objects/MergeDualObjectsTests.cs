using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeDualObjectsTests
  : TestObjects<DualDeclAst, DualFieldAst, DualBaseAst>
{
  private readonly MergeDualObjects _merger;

  public MergeDualObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<DualDeclAst, DualFieldAst, DualBaseAst> MergerObject => _merger;

  protected override DualDeclAst MakeObject(string name, string[]? aliases = null, string description = "", DualBaseAst? parent = default)
    => new(AstNulls.At, name, description) { Aliases = aliases ?? [], Parent = parent };
  protected override DualFieldAst[] MakeFields(FieldInput[] fields)
    => fields.DualFields();
  protected override DualBaseAst MakeBase(string type)
    => new(AstNulls.At, type);
}
