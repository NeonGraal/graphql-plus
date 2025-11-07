using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualFieldAstTests
  : AstObjectFieldTests
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<DualFieldAst> _checks = new(CreateDual, CloneDual);

  private static DualFieldAst CloneDual(DualFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static DualFieldAst CreateDual(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IAstObjectFieldChecks FieldChecks => _checks;
}
