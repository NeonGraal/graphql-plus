using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputArgumentAstTests
  : AstObjectArgumentTests<IGqlpInputArgument>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjArgumentChecks<IGqlpInputArgument, InputArgumentAst> _checks
    = new(name => new InputArgumentAst(AstNulls.At, name));

  internal override IAstObjArgumentChecks<IGqlpInputArgument> ObjArgumentChecks => _checks;
}
