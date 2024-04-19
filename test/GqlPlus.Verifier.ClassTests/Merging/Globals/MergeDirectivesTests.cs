using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Globals;

public class MergeDirectivesTests
  : TestAliased<DirectiveDeclAst>
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
  private readonly IMerge<ParameterAst> _parameters;

  public MergeDirectivesTests(ITestOutputHelper outputHelper)
  {
    _parameters = Merger<ParameterAst>();

    _merger = new(outputHelper.ToLoggerFactory(), _parameters);
  }

  internal override GroupsMerger<DirectiveDeclAst> MergerGroups => _merger;

  protected override DirectiveDeclAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description) { Aliases = aliases };
}
