using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputDeclAstTests
  : AstObjectTests
{
  private readonly OutputDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class OutputDeclAstChecks
  : AstObjectChecks<OutputDeclAst, IGqlpOutputField>
{
  public OutputDeclAstChecks()
    : base(dual => new OutputDeclAst(AstNulls.At, dual),
      parent => new OutputBaseAst(AstNulls.At, parent))
  { }

  protected override IGqlpObjAlternate[] CreateAlternates(IEnumerable<AlternateInput> alternates)
    => alternates.OutputAlternates();
  protected override IGqlpOutputField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.OutputFields();
  protected override string FieldString(FieldInput input)
    => $"!OF {input.Name} : {input.Type}";
}
