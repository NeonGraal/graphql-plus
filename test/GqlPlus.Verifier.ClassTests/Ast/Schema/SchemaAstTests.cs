namespace GqlPlus.Verifier.Ast.Schema;

public class SchemaAstTests : AstBaseTests
{
  internal override IAstBaseChecks<string> NamedChecks { get; }
    = new AstBaseChecks<SchemaAst>(name => new SchemaAst(AstNulls.At, name));

  protected override string InputString(string input)
    => $"( !G {input} Failure )";
}
