namespace GqlPlus.Verifier.Ast.Schema;

public class TypeParameterAstTests : BaseNamedAstTests
{
  protected override string InputString(string input)
    => $"( ${input} )";

  private readonly BaseNamedAstChecks<TypeParameterAst> _checks
    = new(name => new TypeParameterAst(AstNulls.At, name));

  internal override IBaseNamedAstChecks NamedChecks => _checks;
}
