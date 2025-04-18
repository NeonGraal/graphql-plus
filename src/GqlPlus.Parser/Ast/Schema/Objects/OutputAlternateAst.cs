﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputAlternateAst(
  TokenAt At,
  string Output,
  string Description
) : AstObjAlternate<IGqlpOutputArg>(At, Output, Description)
  , IEquatable<OutputAlternateAst>
  , IGqlpOutputAlternate
{
  public override string Label => "Output";
  internal override string Abbr => "OA";

  IGqlpDualAlternate IGqlpToDual<IGqlpDualAlternate>.ToDual => ToDual();

  public DualAlternateAst ToDual()
    => new(At, Output, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => a.ToDual)],
      Modifiers = [.. Modifiers],
    };
}
