using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualFieldAstTests
  : AstObjectFieldTests<DualFieldAst, IGqlpDualBase>
{
  protected override string AliasesString(FieldInput input, string aliases)
    => $"( !DF {input.Name}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<DualFieldAst, IGqlpDualBase, DualBaseAst> _checks = new(
      (dual, objBase) => new(AstNulls.At, dual.Name, objBase),
      dual => new DualBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.DualBases());

  internal override IAstObjectFieldChecks<DualFieldAst, IGqlpDualBase> FieldChecks => _checks;
}
