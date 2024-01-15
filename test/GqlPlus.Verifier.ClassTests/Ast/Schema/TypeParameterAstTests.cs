namespace GqlPlus.Verifier.Ast.Schema;

public class TypeParameterAstTests : AstAbbreviatedTests
{
  protected override string AbbreviatedString(string input)
    => $"( ${input} )";

  private readonly AstAbbreviatedChecks<TypeParameterAst> _checks
    = new(name => new TypeParameterAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
