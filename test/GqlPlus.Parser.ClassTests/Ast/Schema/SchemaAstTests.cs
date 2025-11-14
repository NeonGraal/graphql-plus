using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Ast.Schema;

public class SchemaAstTests
  : AstAbbreviatedBaseTests
{
  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks { get; }
    = new SchemaAstChecks();
}

internal sealed class SchemaAstChecks()
  : AstAbbreviatedChecks<SchemaAst>(CreateSchema, CloneSchema)
{
  protected override string AbbreviatedString(string input)
    => $"( !Sc Failure {{ !Op {input} }} )";

  private static SchemaAst CloneSchema(SchemaAst original, string input)
    => original with { Declarations = [new OptionDeclAst(AstNulls.At, input)] };
  private static SchemaAst CreateSchema(string input)
    => new(AstNulls.At) { Declarations = [new OptionDeclAst(AstNulls.At, input)] };
}
