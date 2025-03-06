using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class TypeParamAstTests : AstAbbreviatedTests
{
  protected override string AbbreviatedString(string input)
    => $"( ${input} )";

  private readonly AstAbbreviatedChecks<TypeParamAst> _checks
    = new(name => new TypeParamAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
