using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Ast.Schema;

public partial class SchemaAstTests
{
  [CheckTests(Inherited = true)]
  internal IAstAbbreviatedChecks<string> AbbreviatedChecks { get; }
    = new SchemaAstChecks();

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; } = new CloneChecks<string, SchemaAst>(
    SchemaAstChecks.CreateSchema,
    (original, input) => original with { Declarations = [new OptionDeclAst(AstNulls.At, input)] });
}

internal sealed class SchemaAstChecks()
  : AstAbbreviatedChecks<SchemaAst>(CreateSchema)
{
  protected override string AbbreviatedString(string input)
    => $"( !Sc Failure {{ !Op {input} }} )";

  internal static SchemaAst CreateSchema(string input)
    => new(AstNulls.At) { Declarations = [new OptionDeclAst(AstNulls.At, input)] };
}
