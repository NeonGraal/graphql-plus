using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parser.Schema.Globals;

public sealed class ParseOperationTests(ComponentFixture<SchemaParserTestServices> fixture)
  : BaseAliasedTests<OperationInput, IAstSchemaOperation>(fixture.GetService<IBaseAliasedChecks<OperationInput, IAstSchemaOperation>>())
  , IClassFixture<ComponentFixture<SchemaParserTestServices>>;

internal sealed class ParseOperationChecks(
  IParserRepository parsers
) : BaseAliasedChecks<OperationInput, OperationDeclAst, IAstSchemaOperation>(parsers)
{
  protected internal override OperationDeclAst NamedFactory(OperationInput input)
    => new(AstNulls.At, input.Name, b => b.Category = input.Category) {
      Domain = new TypeRefAst(AstNulls.At, "Boolean")
    };

  protected internal override string AliasesString(OperationInput input, string aliases)
    => input.Name + aliases + "{" + input.Category + ":Boolean }";
}
