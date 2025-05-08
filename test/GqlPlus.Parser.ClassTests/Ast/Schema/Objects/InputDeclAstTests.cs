using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputDeclAstTests
  : AstObjectTests
{
  private readonly InputDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class InputDeclAstChecks
  : AstObjectChecks<InputDeclAst, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
{
  public InputDeclAstChecks()
    : base(dual => new InputDeclAst(AstNulls.At, dual),
      parent => new InputBaseAst(AstNulls.At, parent))
  { }

  protected override IGqlpInputAlternate[] CreateAlternates(IEnumerable<AlternateInput> alternates)
    => alternates.InputAlternates();
  protected override IGqlpInputField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.InputFields();
  protected override string FieldString(FieldInput input)
    => $"!IF {input.Name} : {input.Type}";
}
