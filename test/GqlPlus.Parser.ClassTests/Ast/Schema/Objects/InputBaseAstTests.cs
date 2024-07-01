using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputBaseAstTests
  : AstObjectBaseTests<IGqlpInputBase>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpInputBase, InputBaseAst, IGqlpInputArgument, InputArgumentAst> _checks
    = new(name => new InputBaseAst(AstNulls.At, name), arguments => arguments.InputArguments());

  internal override IAstObjBaseChecks<IGqlpInputBase> ObjBaseChecks => _checks;
}
