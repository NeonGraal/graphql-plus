using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeDirectivesTests
  : TestAliased<DirectiveDeclAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameOption_ReturnsTrue(string name)
    => CanMerge_True([
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentOption_ReturnsFalse(string name)
    => CanMerge_False([
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsParametersCantMerge_ReturnsFalse(string name, string[] parameters)
  {
    _parameters.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      new DirectiveDeclAst(AstNulls.At, name) with { Parameters = parameters.Parameters() },
      new DirectiveDeclAst(AstNulls.At, name)],
      parameters is null || parameters.Length < 2);
  }

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
      new DirectiveDeclAst(AstNulls.At, name) with { Parameters = parameters.Concat(parameters).Parameters() });

    _parameters.ReceivedWithAnyArgs(1).Merge([]);
  }

  private readonly MergeDirectives _merger;
  private readonly IMerge<ParameterAst> _parameters;

  public MergeDirectivesTests()
  {
    _parameters = Merger<ParameterAst>();

    _merger = new(_parameters);
  }

  internal override GroupsMerger<DirectiveDeclAst> MergerGroups => _merger;

  protected override DirectiveDeclAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description) { Aliases = aliases };
}
