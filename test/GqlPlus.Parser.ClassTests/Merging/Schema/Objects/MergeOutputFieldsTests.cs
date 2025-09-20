using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeOutputFieldsTests
  : TestObjectFieldMerger<IGqlpOutputField>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsParamsCantMerge_ReturnsErrors(string name, string type, string[] parameters)
    => this
      .SkipUnless(parameters)
      .CanMergeReturnsError(_parameters)
      .CanMerge_Errors(
        MakeFieldParams(name, type, parameters),
        MakeField(name, type));

  [Theory, RepeatData]
  public void Merge_TwoAstsWithParams_CallsParamsMerge(string name, string type, string[] parameters)
    => Merge_Expected(
        [MakeFieldParams(name, type, parameters),
          MakeFieldParams(name, type, parameters)],
        MakeFieldParams(name, type, parameters.Concat(parameters)))
      .MergeCalled(_parameters);

  private readonly MergeOutputFields _merger;
  private readonly IMerge<IGqlpInputParam> _parameters;

  public MergeOutputFieldsTests(ITestOutputHelper outputHelper)
  {
    _parameters = Merger<IGqlpInputParam>();
    _merger = new(outputHelper.ToLoggerFactory(), _parameters);
  }

  internal override AstObjectFieldsMerger<IGqlpOutputField> MergerField => _merger;

  protected override IGqlpOutputField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new OutputFieldAst(AstNulls.At, name, fieldDescription, new OutputBaseAst(AstNulls.At, type, typeDescription)) {
      Aliases = aliases ?? [],
    };
  private static OutputFieldAst MakeFieldParams(string name, string type, IEnumerable<string> parameters)
    => new(AstNulls.At, name, new OutputBaseAst(AstNulls.At, type)) {
      Params = parameters.ThrowIfNull().Params(),
    };
  protected override IGqlpOutputField MakeFieldModifiers(string name)
    => new OutputFieldAst(AstNulls.At, name, new OutputBaseAst(AstNulls.At, name)) {
      Modifiers = TestMods(),
    };
  protected override IGqlpOutputField MakeFieldEnum(string name, string enumType, string enumLabel, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new OutputFieldAst(AstNulls.At, name, fieldDescription, new OutputBaseAst(AstNulls.At, enumType, typeDescription)) {
      Aliases = aliases ?? [],
      EnumLabel = enumLabel,
    };
}
