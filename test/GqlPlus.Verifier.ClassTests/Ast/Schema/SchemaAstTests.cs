using GqlPlus.Verifier.Ast.Schema.Globals;

namespace GqlPlus.Verifier.Ast.Schema;

public class SchemaAstTests
  : AstAbbreviatedTests
{
  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks { get; }
    = new AstAbbreviatedChecks<SchemaAst>(name => new SchemaAst(AstNulls.At) { Declarations = [new OptionDeclAst(AstNulls.At, name)] });

  protected override string AbbreviatedString(string input)
    => $"( !Sc Failure {{ !Op {input} }} )";
}
