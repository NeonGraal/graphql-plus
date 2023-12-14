namespace GqlPlus.Verifier.Ast.Schema;

public class TypeParameterAstTests : AstBaseTests
{
  protected override string InputString(string input)
    => $"( ${input} )";

  private readonly AstBaseChecks<TypeParameterAst> _checks
    = new(name => new TypeParameterAst(AstNulls.At, name));

  internal override IAstBaseChecks NamedChecks => _checks;
}
