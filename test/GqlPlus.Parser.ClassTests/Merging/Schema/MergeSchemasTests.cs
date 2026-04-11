using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Schema;

public class MergeSchemasTests
  : TestAbbreviatedMerger<IAstSchema>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentDeclarations_ReturnsGood(string category, string option)
    => CanMerge_Good([
      new SchemaAst(AstNulls.At) with { Declarations = CategoryDeclarations(category) },
      new SchemaAst(AstNulls.At) with { Declarations = OptionDeclarations(option) }]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentOptionNames_ReturnsErrors(string option1, string option2)
    => this
      .SkipEqual(option1, option2)
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
    .MergeCalled(_operations)
    .MergeCalled(_options)
    .MergeCalled(_astTypes);
  }

  private readonly MergeSchemas _merger;
  private readonly IMerge<IAstSchemaCategory> _categories;
  private readonly IMerge<IAstSchemaDirective> _directives;
  private readonly IMerge<IAstSchemaOperation> _operations;
  private readonly IMerge<IAstSchemaOption> _options;
  private readonly IMerge<IAstType> _astTypes;

  public MergeSchemasTests()
  {
    _categories = Merger<IAstSchemaCategory>();
    _directives = Merger<IAstSchemaDirective>();
    _operations = Merger<IAstSchemaOperation>();
    _options = Merger<IAstSchemaOption>();
    _astTypes = Merger<IAstType>();

    IMergerRepository mergers = Substitute.For<IMergerRepository>();
    mergers.MergerFor<IAstSchemaCategory>().Returns(_categories);
    mergers.MergerFor<IAstSchemaDirective>().Returns(_directives);
    mergers.MergerFor<IAstSchemaOperation>().Returns(_operations);
    mergers.MergerFor<IAstSchemaOption>().Returns(_options);
    mergers.MergerFor<IAstType>().Returns(_astTypes);
    _merger = new(mergers);
  }

  protected override IMerge<IAstSchema> MergerBase => _merger;

  protected override IAstSchema MakeAst(string input)
    => new SchemaAst(AstNulls.At);

  private static AstDeclaration[] CategoryDeclarations(string category)
    => [
      new CategoryDeclAst(AstNulls.At, new TypeRefAst(AstNulls.At, category)),
      new AstObject<IAstOutputField>(TypeKind.Output, AstNulls.At, category, ""),
      ];

  private static AstDeclaration[] OptionDeclarations(string option)
    => [new OptionDeclAst(AstNulls.At, option)];
}
