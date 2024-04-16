namespace GqlPlus.Verifier.Ast.Schema.Objects;

public class DualReferenceAstTests
  : AstReferenceTests<DualReferenceAst>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstReferenceChecks<DualReferenceAst> _checks
    = new(name => new DualReferenceAst(AstNulls.At, name), arguments => arguments.DualReferences());

  internal override IAstReferenceChecks<DualReferenceAst> ReferenceChecks => _checks;
}
