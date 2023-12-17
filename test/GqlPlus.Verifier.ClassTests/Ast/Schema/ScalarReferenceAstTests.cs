namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarReferenceAstTests : AstBaseTests
{
  protected override string InputString(string input)
    => $"( !ST {input} )";

  private readonly AstBaseChecks<ScalarReferenceAst> _checks
    = new(name => new ScalarReferenceAst(AstNulls.At, name));

  internal override IAstBaseChecks NamedChecks => _checks;
}
