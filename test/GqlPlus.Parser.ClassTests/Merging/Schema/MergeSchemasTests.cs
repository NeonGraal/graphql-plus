using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Schema;

public class MergeSchemasTests
  : TestAbbreviatedMerger<IGqlpSchema>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentDeclarations_ReturnsGood(string category, string option)
    => CanMerge_Good([
      new SchemaAst(AstNulls.At) with { Declarations = CategoryDeclarations(category) },
      new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option) }]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentOptionNames_ReturnsErrors(string option1, string option2)
    => this
      .SkipIf(option1 == option2)
      .CanMergeReturnsError(_options)
      .CanMerge_Errors([
        new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option1) },
        new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option2) }]);

  [Theory, RepeatData]
  public void Merge_TwoAstsDifferentDeclarations_ReturnsExpected(string category, string option)
  {
    AstDeclaration[] categoryDecls = CategoryDeclarations(category);
    AstDeclaration[] otherDecls = OptionDeclarations(option);

    Merge_Expected(
      [new SchemaAst(AstNulls.At) with { Declarations = categoryDecls },
        new SchemaAst(AstNulls.At) with { Declarations = otherDecls }],
      new SchemaAst(AstNulls.At) with { Declarations = [.. categoryDecls, .. otherDecls] })
    .MergeCalled(_categories)
    .MergeCalled(_directives)
    .MergeCalled(_options)
    .MergeCalled(_astTypes);
  }

  private readonly MergeSchemas _merger;
  private readonly IMerge<IGqlpSchemaCategory> _categories;
  private readonly IMerge<IGqlpSchemaDirective> _directives;
  private readonly IMerge<IGqlpSchemaOption> _options;
  private readonly IMerge<IGqlpType> _astTypes;

  public MergeSchemasTests()
  {
    _categories = Merger<IGqlpSchemaCategory>();
    _directives = Merger<IGqlpSchemaDirective>();
    _options = Merger<IGqlpSchemaOption>();
    _astTypes = Merger<IGqlpType>();

    _merger = new(_categories, _directives, _options, _astTypes);
  }

  protected override IMerge<IGqlpSchema> MergerBase => _merger;

  protected override IGqlpSchema MakeAst(string input)
    => new SchemaAst(AstNulls.At);

  private static AstDeclaration[] CategoryDeclarations(string category)
    => [new CategoryDeclAst(AstNulls.At, new(AstNulls.At, category)), new OutputDeclAst(AstNulls.At, category)];

  private static AstDeclaration[] OptionDeclarations(string option)
    => [new OptionDeclAst(AstNulls.At, option)];
}
