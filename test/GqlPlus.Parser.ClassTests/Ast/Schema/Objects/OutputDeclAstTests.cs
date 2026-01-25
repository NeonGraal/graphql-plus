using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputDeclAstTests
  : AstObjectBaseTests
{
  private readonly OutputDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class OutputDeclAstChecks
  : AstObjectChecks<IGqlpOutputField>
{
  public OutputDeclAstChecks()
    : base(TypeKind.Output, parent => new ObjBaseAst(AstNulls.At, parent, string.Empty))
  { }

  protected override IGqlpOutputField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.OutputFields();
  protected override string FieldString(FieldInput input)
    => $"!OF {input.Name} : {input.Type}";
}
