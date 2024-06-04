using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeOutputObjectsTests
  : TestObjects<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputBase>
{
  private readonly MergeOutputObjects _merger;

  public MergeOutputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputBase> MergerObject => _merger;

  protected override OutputDeclAst MakeObject(string name, string[]? aliases = null, string description = "", IGqlpOutputBase? parent = default)
    => new(AstNulls.At, name, description) { Aliases = aliases ?? [], Parent = parent, };
  protected override OutputFieldAst[] MakeFields(FieldInput[] fields)
    => fields.OutputFields();
  protected override OutputBaseAst MakeBase(string type)
    => new(AstNulls.At, type);
}
