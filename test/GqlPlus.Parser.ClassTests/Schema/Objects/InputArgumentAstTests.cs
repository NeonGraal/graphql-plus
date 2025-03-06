using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class InputArgAstTests
  : AstObjectArgTests<IGqlpInputArg>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjArgChecks<IGqlpInputArg, InputArgAst> _checks
    = new(name => new InputArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpInputArg> ObjArgChecks => _checks;
}
