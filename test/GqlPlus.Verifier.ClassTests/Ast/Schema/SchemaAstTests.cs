namespace GqlPlus.Verifier.Ast.Schema;

public class SchemaAstTests : AstAbbreviatedTests
{
  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks { get; }
    = new AstAbbreviatedChecks<SchemaAst>(name => new SchemaAst(AstNulls.At, name));

  protected override string AbbreviatedString(string input)
    => $"( !G {input} Failure )";
}
