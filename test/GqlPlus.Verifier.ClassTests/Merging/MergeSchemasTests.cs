using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeSchemasTests
  : TestGroups<SchemaAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentDeclarations_ReturnsTrue(string name, string category, string directive)
    => CanMerge_True([
      new SchemaAst(AstNulls.At, name) with { Declarations = [new CategoryDeclAst(AstNulls.At, category), new OutputDeclAst(AstNulls.At, category)] },
      new SchemaAst(AstNulls.At, name) with { Declarations = [new DirectiveDeclAst(AstNulls.At, directive)] }]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsDifferentDeclarations_ReturnsExpected(string name, string category, string directive)
  {
    var categoryDecl = new CategoryDeclAst(AstNulls.At, category);
    var outputDecl = new OutputDeclAst(AstNulls.At, category);
    var directiveDecl = new DirectiveDeclAst(AstNulls.At, directive);

    Merge_Expected([
      new SchemaAst(AstNulls.At, name) with { Declarations = [categoryDecl, outputDecl] },
      new SchemaAst(AstNulls.At, name) with { Declarations = [directiveDecl] }],
      new SchemaAst(AstNulls.At, name) with { Declarations = [categoryDecl, outputDecl, directiveDecl] });

    _categories.ReceivedWithAnyArgs(1).Merge([]);
    _directives.ReceivedWithAnyArgs(1).Merge([]);
    _astTypes.ReceivedWithAnyArgs(1).Merge([]);
  }

  private readonly MergeSchemas _merger;
  private readonly IMerge<CategoryDeclAst> _categories;
  private readonly IMerge<DirectiveDeclAst> _directives;
  private readonly IMerge<AstType> _astTypes;

  public MergeSchemasTests()
  {
    _categories = Merger<CategoryDeclAst>();
    _directives = Merger<DirectiveDeclAst>();
    _astTypes = Merger<AstType>();

    _merger = new(_categories, _directives, _astTypes);
  }

  protected override GroupsMerger<SchemaAst> MergerGroups => _merger;

  protected override SchemaAst MakeDistinct(string name)
    => new(AstNulls.At, name);
}
