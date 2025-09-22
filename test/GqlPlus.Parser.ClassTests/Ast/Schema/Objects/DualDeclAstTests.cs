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
      parent => new ObjBaseAst(AstNulls.At, parent, ""))
  { }

  protected override IGqlpObjAlt[] CreateAlternates(IEnumerable<AlternateInput> alternates)
    => alternates.ObjAlternates();
  protected override IGqlpDualField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.DualFields();
  protected override string FieldString(FieldInput input)
    => $"!DF {input.Name} : {input.Type}";
}
