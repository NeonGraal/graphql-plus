using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeSchemasTests
  : TestAbbreviated<SchemaAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDeclarations_ReturnsGood(string category, string option)
    => CanMerge_Good([
      new SchemaAst(AstNulls.At) with { Declarations = CategoryDeclarations(category) },
      new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option) }]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentOptionNames_ReturnsErrors(string option1, string option2)
  {
    _options.CanMerge([]).ReturnsForAnyArgs(ErrorMessages);

    CanMerge_Errors([
        new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option1) },
        new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option2) }]
      , option1 == option2);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsDifferentDeclarations_ReturnsExpected(string category, string option)
  {
    var categoryDecls = CategoryDeclarations(category);
    var otherDecls = OptionDeclarations(option);

    Merge_Expected([
      new SchemaAst(AstNulls.At) with { Declarations = categoryDecls },
      new SchemaAst(AstNulls.At) with { Declarations = otherDecls }],
      new SchemaAst(AstNulls.At) with { Declarations = [.. categoryDecls, .. otherDecls] });

    _categories.ReceivedWithAnyArgs(1).Merge([]);
    _directives.ReceivedWithAnyArgs(1).Merge([]);
    _options.ReceivedWithAnyArgs(1).Merge([]);
    _astTypes.ReceivedWithAnyArgs(1).Merge([]);
  }

  private readonly MergeSchemas _merger;
  private readonly IMerge<CategoryDeclAst> _categories;
  private readonly IMerge<DirectiveDeclAst> _directives;
  private readonly IMerge<OptionDeclAst> _options;
  private readonly IMerge<AstType> _astTypes;

  public MergeSchemasTests()
  {
    _categories = Merger<CategoryDeclAst>();
    _directives = Merger<DirectiveDeclAst>();
    _options = Merger<OptionDeclAst>();
    _astTypes = Merger<AstType>();

    _merger = new(_categories, _directives, _options, _astTypes);
  }

  protected override IMerge<SchemaAst> MergerBase => _merger;

  protected override SchemaAst MakeAst(string input)
    => new(AstNulls.At);

  private static AstDeclaration[] CategoryDeclarations(string category)
    => [new CategoryDeclAst(AstNulls.At, category), new OutputDeclAst(AstNulls.At, category)];

  private static AstDeclaration[] OptionDeclarations(string option)
    => [new OptionDeclAst(AstNulls.At, option)];
}
