﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputAlternateAst(
  ITokenAt At,
  string Output,
  string Description
) : AstObjAlternate<IGqlpOutputArg>(At, Output, Description)
  , IGqlpOutputAlternate
{
  public override string Label => "Output";
  internal override string Abbr => "OA";

  IGqlpDualBase IGqlpToDual<IGqlpDualBase>.ToDual => ToDual();

  public DualAlternateAst ToDual()
    => new(At, Output, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => a.ToDual)],
      Modifiers = [.. Modifiers],
    };
}
