using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeOutputFieldsTests
  : TestObjectFieldMerger<IGqlpOutputField>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsParamsCantMerge_ReturnsErrors(string name, string type, string parameter)
    => this
      .CanMergeReturnsError(_parameters)
      .CanMerge_Errors(
        MakeFieldParam(name, type, parameter),
        MakeField(name, type));

  [Theory, RepeatData]
  public void Merge_TwoAstsWithParams_CallsParamsMerge(string name, string type, string parameter)
    => Merge_Expected(
        [MakeFieldParam(name, type, parameter),
          MakeFieldParam(name, type, parameter)],
        MakeFieldParam(name, type, parameter))
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
    => new OutputFieldAst(AstNulls.At, name, fieldDescription, new ObjBaseAst(AstNulls.At, type, typeDescription)) {
      Aliases = aliases ?? [],
    };
  private static OutputFieldAst MakeFieldParam(string name, string type, string parameter)
    => new(AstNulls.At, name, new ObjBaseAst(AstNulls.At, type, "")) {
      Parameter = parameter.Parameter(),
    };
  protected override IGqlpOutputField MakeFieldModifiers(string name)
    => new OutputFieldAst(AstNulls.At, name, new ObjBaseAst(AstNulls.At, name, "")) {
      Modifiers = TestMods(),
    };
  protected override IGqlpOutputField MakeFieldEnum(string name, string enumType, string enumLabel, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new OutputFieldAst(AstNulls.At, name, fieldDescription, new ObjBaseAst(AstNulls.At, enumType, typeDescription)) {
      Aliases = aliases ?? [],
      EnumValue = new EnumValueAst(AstNulls.At, enumType, enumLabel),
    };
}
