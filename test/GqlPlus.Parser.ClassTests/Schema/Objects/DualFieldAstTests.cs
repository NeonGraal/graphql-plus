using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class DualFieldAstTests
  : AstObjectFieldTests<IGqlpDualBase>
{
  protected override string AliasesString(FieldInput input, string aliases)
    => $"( !DF {input.Name}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<DualFieldAst, IGqlpDualBase, DualBaseAst, IGqlpDualArg, DualArgAst> _checks = new(
      (dual, objBase) => new(AstNulls.At, dual.Name, objBase),
      dual => new DualBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.DualArgs());

  internal override IAstObjectFieldChecks<IGqlpDualBase> FieldChecks => _checks;
}
