﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputAlternateAstTests
  : AstObjectAlternateTests<IGqlpInputBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !IA {input.Type} )";

  private readonly AstObjectAlternateChecks<InputAlternateAst, IGqlpInputBase, InputBaseAst, IGqlpInputArg, InputArgAst> _checks
    = new(dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.InputArgs());

  internal override IAstObjectAlternateChecks<IGqlpInputBase> AlternateChecks => _checks;
}
