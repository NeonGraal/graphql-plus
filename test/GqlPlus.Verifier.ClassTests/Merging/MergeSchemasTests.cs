using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Ast.Schema.Objects;

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
    => this
      .SkipIf(option1 == option2)
      .CanMergeReturnsError(_options)
      .CanMerge_Errors([
        new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option1) },
        new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option2) }]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsDifferentDeclarations_ReturnsExpected(string category, string option)
  {
    var categoryDecls = CategoryDeclarations(category);
    var otherDecls = OptionDeclarations(option);

    Merge_Expected(
      [ new SchemaAst(AstNulls.At) with { Declarations = categoryDecls },
        new SchemaAst(AstNulls.At) with { Declarations = otherDecls }],
      new SchemaAst(AstNulls.At) with { Declarations = [.. categoryDecls, .. otherDecls] })
    .MergeCalled(_categories)
    .MergeCalled(_directives)
    .MergeCalled(_options)
    .MergeCalled(_astTypes);
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
