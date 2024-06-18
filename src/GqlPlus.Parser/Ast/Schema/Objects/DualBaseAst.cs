﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjBase<IGqlpDualBase>(At, Name, Description)
  , IGqlpDualBase
{
  public DualBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "DR";
  public override string Label => "Dual";

  string IGqlpDualBase.Dual => Name;
}
