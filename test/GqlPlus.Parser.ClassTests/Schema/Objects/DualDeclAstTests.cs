using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class DualDeclAstTests
  : AstObjectTests
{
  private readonly DualDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class DualDeclAstChecks
  : AstObjectChecks<DualDeclAst, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{
  public DualDeclAstChecks()
    : base(dual => new DualDeclAst(AstNulls.At, dual),
      parent => new DualBaseAst(AstNulls.At, parent))
  { }

  protected override string AlternateString(AlternateInput input)
    => $"!DA {input.Type} [] ?";

  protected override IGqlpDualAlternate[] CreateAlternates(IEnumerable<AlternateInput> alternates)
    => alternates.DualAlternates();
  protected override IGqlpDualField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.DualFields();
  protected override string FieldString(FieldInput input)
    => $"!DF {input.Name} : {input.Type}";
}
