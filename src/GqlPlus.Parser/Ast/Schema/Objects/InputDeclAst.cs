﻿using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class InputDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<InputFieldAst, InputBaseAst>(At, Name, Description)
{
  internal override string Abbr => "In";
  public override string Label => "Input";

  public InputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
