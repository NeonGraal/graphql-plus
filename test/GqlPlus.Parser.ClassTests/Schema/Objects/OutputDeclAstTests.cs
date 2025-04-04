﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class OutputDeclAstTests
  : AstObjectTests
{
  private readonly OutputDeclAstChecks _checks = new();

  internal override IAstObjectChecks ObjectChecks => _checks;
}

internal sealed class OutputDeclAstChecks
  : AstObjectChecks<OutputDeclAst, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
{
  public OutputDeclAstChecks()
    : base(dual => new OutputDeclAst(AstNulls.At, dual),
      parent => new OutputBaseAst(AstNulls.At, parent))
  { }

  protected override IGqlpOutputAlternate[] CreateAlternates(IEnumerable<AlternateInput> alternates)
    => alternates.OutputAlternates();
  protected override IGqlpOutputField[] CreateFields(IEnumerable<FieldInput> fields)
    => fields.OutputFields();
  protected override string FieldString(FieldInput input)
    => $"!OF {input.Name} : {input.Type}";
}
