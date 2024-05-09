using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Globals;

public class MergeDirectivesTests
  : TestAliased<IGqlpSchemaDirective>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameOption_ReturnsGood(string name)
    => CanMerge_Good([
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentOption_ReturnsErrors(string name)
    => CanMerge_Errors([
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name)]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsParametersCantMerge_ReturnsErrors(string name, string[] parameters)
    => this
      .SkipUnless(parameters)
      .CanMergeReturnsError(_parameters)
      .CanMerge_Errors(
        new DirectiveDeclAst(AstNulls.At, name) with { Parameters = parameters.Parameters() },
        new DirectiveDeclAst(AstNulls.At, name));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsWithLocation_ReturnsExpected(string name, DirectiveLocation locations1, DirectiveLocation locations2)
    => Merge_Expected([
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations1 },
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations2 }],
      new DirectiveDeclAst(AstNulls.At, name) with { Locations = locations1 | locations2 });

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsWithParameters_CallsParametersMerge(string name, string[] parameters)
  {
    Merge_Expected([
      new DirectiveDeclAst(AstNulls.At, name) with { Parameters = parameters.Parameters() },
      new DirectiveDeclAst(AstNulls.At, name) with { Parameters = parameters.Parameters() }],
      new DirectiveDeclAst(AstNulls.At, name) with { Parameters = parameters.Concat(parameters).Parameters() })
    .MergeCalled(_parameters);
  }

  private readonly MergeDirectives _merger;
  private readonly IMerge<InputParameterAst> _parameters;

  public MergeDirectivesTests(ITestOutputHelper outputHelper)
  {
    _parameters = Merger<InputParameterAst>();

    _merger = new(outputHelper.ToLoggerFactory(), _parameters);
  }

  internal override GroupsMerger<IGqlpSchemaDirective> MergerGroups => _merger;

  protected override IGqlpSchemaDirective MakeAliased(string name, string[]? aliases = null, string description = "")
    => new DirectiveDeclAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
