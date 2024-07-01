using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualBaseAstTests
  : AstObjectBaseTests<IGqlpDualBase>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpDualBase, DualBaseAst, IGqlpDualArgument, DualArgumentAst> _checks
    = new(name => new DualBaseAst(AstNulls.At, name), arguments => arguments.DualArguments());

  internal override IAstObjBaseChecks<IGqlpDualBase> ObjBaseChecks => _checks;
}
