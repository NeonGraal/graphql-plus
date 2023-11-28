﻿namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OutputAst(ParseAt At, string Name, string Description)
  : AstObject<OutputFieldAst, OutputReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "O";

  public OutputAst(ParseAt at, string name)
    : this(at, name, "") { }
}
