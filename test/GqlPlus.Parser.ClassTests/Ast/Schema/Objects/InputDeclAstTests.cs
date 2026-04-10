using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputDeclAstTests
  : AstObjectBaseTests
{
  private readonly InputDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class InputDeclAstChecks
  : AstObjectChecks<IAstInputField>
{
  public InputDeclAstChecks()
    : base(TypeKind.Input, parent => new ObjBaseAst(AstNulls.At, parent, string.Empty))
  { }

  protected override IAstInputField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.InputFields();
  protected override string FieldString(FieldInput input)
    => $"!IF {input.Name} : {input.Type}";
}
