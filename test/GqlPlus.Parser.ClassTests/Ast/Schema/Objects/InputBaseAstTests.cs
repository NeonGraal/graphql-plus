using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputBaseAstTests
  : AstObjBaseTests<IGqlpInputBase, InputBaseAst>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpInputBase, InputBaseAst> _checks
    = new(name => new InputBaseAst(AstNulls.At, name), arguments => arguments.InputBases());

  internal override IAstObjBaseChecks<IGqlpInputBase, InputBaseAst> ObjBaseChecks => _checks;
}
