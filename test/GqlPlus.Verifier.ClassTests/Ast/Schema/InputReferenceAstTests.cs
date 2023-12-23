namespace GqlPlus.Verifier.Ast.Schema;

public class InputReferenceAstTests : AstReferenceTests<InputReferenceAst>
{
  protected override string InputString(string input)
    => $"( {input} )";

  private readonly AstReferenceChecks<InputReferenceAst> _checks
    = new(name => new InputReferenceAst(AstNulls.At, name), arguments => arguments.InputReferences());

  internal override IAstReferenceChecks<InputReferenceAst> ReferenceChecks => _checks;
}
