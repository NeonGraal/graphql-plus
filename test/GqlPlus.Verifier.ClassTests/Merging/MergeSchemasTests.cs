using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeSchemasTests
  : TestAbbreviated<SchemaAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDeclarations_ReturnsTrue(string category, string directive, string option)
    => CanMerge_True([
      new SchemaAst(AstNulls.At) with { Declarations = CategoryDeclarations(category) },
      new SchemaAst(AstNulls.At) with { Declarations = OtherDeclarations(directive, option) }]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsDifferentDeclarations_ReturnsExpected(string category, string directive, string option)
  {
    var categoryDecls = CategoryDeclarations(category);
    var otherDecls = OtherDeclarations(directive, option);

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

  private static AstDeclaration[] OtherDeclarations(string directive, string option)
    => [new DirectiveDeclAst(AstNulls.At, directive), new OptionDeclAst(AstNulls.At, option)];
}
