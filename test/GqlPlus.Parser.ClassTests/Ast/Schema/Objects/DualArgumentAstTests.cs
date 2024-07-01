using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualArgumentAstTests
  : AstObjectArgumentTests<IGqlpDualArgument>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjArgumentChecks<IGqlpDualArgument, DualArgumentAst> _checks
    = new(name => new DualArgumentAst(AstNulls.At, name));

  internal override IAstObjArgumentChecks<IGqlpDualArgument> ObjArgumentChecks => _checks;
}
