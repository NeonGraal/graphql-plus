namespace GqlPlus.Verifier.Ast.Schema.Objects;

public class InputReferenceAstTests : AstReferenceTests<InputReferenceAst>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstReferenceChecks<InputReferenceAst> _checks
    = new(name => new InputReferenceAst(AstNulls.At, name), arguments => arguments.InputReferences());

  internal override IAstReferenceChecks<InputReferenceAst> ReferenceChecks => _checks;
}
