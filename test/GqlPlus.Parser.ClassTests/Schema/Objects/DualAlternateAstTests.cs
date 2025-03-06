﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class DualAlternateAstTests
  : AstObjectAlternateTests<IGqlpDualBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !DA {input.Type} )";

  private readonly AstObjectAlternateChecks<DualAlternateAst, IGqlpDualBase, DualBaseAst, IGqlpDualArg, DualArgAst> _checks
    = new((dual, objBase) => new(AstNulls.At, objBase),
      dual => new DualBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.DualArgs());

  internal override IAstObjectAlternateChecks<IGqlpDualBase> AlternateChecks => _checks;
}
