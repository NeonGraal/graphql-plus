using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualDeclAstTests
  : AstObjectBaseTests
{
  private readonly DualDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class DualDeclAstChecks
  : AstObjectChecks<IAstDualField>
{
  public DualDeclAstChecks()
    : base(TypeKind.Dual, parent => new ObjBaseAst(AstNulls.At, parent, string.Empty))
  { }

  protected override IAstDualField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.DualFields();
  protected override string FieldString(FieldInput input)
    => $"!DF {input.Name} : {input.Type}";
}
