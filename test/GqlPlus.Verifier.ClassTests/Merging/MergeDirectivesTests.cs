using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeDirectivesTests
  : TestDescriptions<DirectiveDeclAst>
{
  private readonly MergeDirectives _merger;
  private readonly IMerge<ParameterAst> _parameters;

  public MergeDirectivesTests()
  {
    _parameters = Substitute.For<IMerge<ParameterAst>>();
    _parameters.CanMerge([]).ReturnsForAnyArgs(true);

    _merger = new(_parameters);
  }

  protected override DescribedsMerger<DirectiveDeclAst> MergerDescribed => _merger;

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameOption_ReturnsTrue(string name)
    => CanMerge_True([
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentOption_ReturnsFalse(string name)
    => CanMerge_False([
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsParametersCantMerge_ReturnsFalse(string name, string[] parameters)
  {
    _parameters.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      new DirectiveDeclAst(AstNulls.At, name) with { Parameters = parameters.Parameters() },
      new DirectiveDeclAst(AstNulls.At, name) with { Parameters = parameters.Parameters() }]);
  }

  protected override DirectiveDeclAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}
