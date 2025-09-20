using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualDeclAstTests
  : AstObjectTests
{
  private readonly DualDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class DualDeclAstChecks
  : AstObjectChecks<DualDeclAst, IGqlpDualField>
{
  public DualDeclAstChecks()
    : base(dual => new DualDeclAst(AstNulls.At, dual),
      parent => new DualBaseAst(AstNulls.At, parent))
  { }

  protected override IGqlpObjAlternate[] CreateAlternates(IEnumerable<AlternateInput> alternates)
    => alternates.DualAlternates();
  protected override IGqlpDualField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.DualFields();
  protected override string FieldString(FieldInput input)
    => $"!DF {input.Name} : {input.Type}";
}
