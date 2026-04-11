using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parser.Schema.Globals;

public sealed class ParseOperationTests(
  IBaseAliasedChecks<OperationInput, IAstSchemaOperation> checks
) : BaseAliasedTests<OperationInput, IAstSchemaOperation>(checks)
{ }

internal sealed class ParseOperationChecks(
  IParserRepository parsers
) : BaseAliasedChecks<OperationInput, OperationDeclAst, IAstSchemaOperation>(parsers)
{
  protected internal override OperationDeclAst NamedFactory(OperationInput input)
    => new(AstNulls.At, input.Name, input.Category);

  protected internal override string AliasesString(OperationInput input, string aliases)
    => input.Name + aliases + "{" + input.Category + ":Boolean }";
}
