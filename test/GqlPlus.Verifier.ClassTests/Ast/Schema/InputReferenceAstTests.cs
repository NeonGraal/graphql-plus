namespace GqlPlus.Verifier.Ast.Schema;

public class InputReferenceAstTests : BaseNamedAstTests
{
  private readonly BaseNamedAstChecks<InputReferenceAst> _checks
    = new(name => new InputReferenceAst(AstNulls.At, name));

  internal override IBaseNamedAstChecks NamedChecks => _checks;
}
