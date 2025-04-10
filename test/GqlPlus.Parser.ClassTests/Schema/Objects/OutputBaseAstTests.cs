﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class OutputBaseAstTests
  : AstObjectBaseTests<IGqlpOutputBase>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst> _checks
    = new(name => new OutputBaseAst(AstNulls.At, name), arguments => arguments.OutputArgs());

  internal override IAstObjBaseChecks<IGqlpOutputBase> ObjBaseChecks => _checks;
}
