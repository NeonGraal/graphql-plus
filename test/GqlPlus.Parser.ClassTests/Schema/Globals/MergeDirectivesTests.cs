using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging;
using GqlPlus.Merging.Globals;
using Xunit.Abstractions;

namespace GqlPlus.Schema.Globals;

public class MergeDirectivesTests
  : TestAliased<IGqlpSchemaDirective>
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

  [SkippableTheory, RepeatData]
  public void CanMerge_TwoAstsParamsCantMerge_ReturnsErrors(string name, string[] parameters)
    => this
      .SkipUnless(parameters)
      .CanMergeReturnsError(_parameters)
      .CanMerge_Errors(
        new DirectiveDeclAst(AstNulls.At, name) with { Params = parameters.Params() },
        new DirectiveDeclAst(AstNulls.At, name));

  [Theory, RepeatData]
  public void Merge_TwoAstsWithLocation_ReturnsExpected(string name, DirectiveLocation locations1, DirectiveLocation locations2)
    => Merge_Expected([
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations1 },
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations2 }],
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations1 | locations2 });

  [Theory, RepeatData]
  public void Merge_TwoAstsWithParams_CallsParamsMerge(string name, string[] parameters)
  {
    Merge_Expected([
      new DirectiveDeclAst(AstNulls.At, name) with { Params = parameters.Params() },
      new DirectiveDeclAst(AstNulls.At, name) with { Params = parameters.Params() }],
      new DirectiveDeclAst(AstNulls.At, name) with { Params = parameters.Concat(parameters).Params() })
    .MergeCalled(_parameters);
  }

  private readonly MergeDirectives _merger;
  private readonly IMerge<IGqlpInputParam> _parameters;

  public MergeDirectivesTests(ITestOutputHelper outputHelper)
  {
    _parameters = Merger<IGqlpInputParam>();

    _merger = new(outputHelper.ToLoggerFactory(), _parameters);
  }

  internal override GroupsMerger<IGqlpSchemaDirective> MergerGroups => _merger;

  protected override IGqlpSchemaDirective MakeAliased(string name, string[]? aliases = null, string description = "")
    => new DirectiveDeclAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
