using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputDeclAstTests
  : AstObjectTests
{
  private readonly InputDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class InputDeclAstChecks
  : AstObjectChecks<InputDeclAst, IGqlpInputField>
{
  public InputDeclAstChecks()
    : base(dual => new InputDeclAst(AstNulls.At, dual),
      parent => new ObjBaseAst(AstNulls.At, parent, ""))
  { }

  protected override IGqlpObjAlt[] CreateAlternates(IEnumerable<AlternateInput> alternates)
    => alternates.ObjAlts();
  protected override IGqlpInputField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.InputFields();
  protected override string FieldString(FieldInput input)
    => $"!IF {input.Name} : {input.Type}";
}
