using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging.Globals;

namespace GqlPlus.Merging.Schema.Globals;

public class MergeDirectivesTests
  : TestAliasedMerger<IAstSchemaDirective>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameOption_ReturnsGood(string name)
    => CanMerge_Good([
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable }]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentOption_ReturnsErrors(string name)
    => CanMerge_Errors([
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsParamsCantMerge_ReturnsErrors(string name, string parameter)
    => this
      .CanMergeReturnsError(_parameters)
      .CanMerge_Errors(
        new DirectiveDeclAst(AstNulls.At, name) with { Parameter = parameter.Parameter() },
        new DirectiveDeclAst(AstNulls.At, name));

  [Theory, RepeatData]
  public void Merge_TwoAstsWithLocation_ReturnsExpected(string name, DirectiveLocation locations1, DirectiveLocation locations2)
    => Merge_Expected([
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations1 },
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations2 }],
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations1 | locations2 });

  [Theory, RepeatData]
  public void Merge_TwoAstsWithParams_CallsParamsMerge(string name, string parameter)
  {
    Merge_Expected([
      new DirectiveDeclAst(AstNulls.At, name) with { Parameter = parameter.Parameter() },
      new DirectiveDeclAst(AstNulls.At, name) with { Parameter = parameter.Parameter() }],
      new DirectiveDeclAst(AstNulls.At, name) with { Parameter = parameter.Parameter() })
    .MergeCalled(_parameters);
  }

  private readonly MergeDirectives _merger;
  private readonly IMerge<IGqlpInputParam> _parameters;

  public MergeDirectivesTests(ITestOutputHelper outputHelper)
  {
    _parameters = Merger<IGqlpInputParam>();

    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpInputParam>().Returns(_parameters);
    _merger = new(mergers);
  }

  internal override GroupsMerger<IAstSchemaDirective> MergerGroups => _merger;

  protected override IAstSchemaDirective MakeAliased(string name, string[]? aliases = null, string description = "")
    => new DirectiveDeclAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
