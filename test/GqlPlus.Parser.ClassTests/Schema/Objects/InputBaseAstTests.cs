﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class InputBaseAstTests
  : AstObjectBaseTests<IGqlpInputBase>
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpInputBase, InputBaseAst, IGqlpInputArg, InputArgAst> _checks
    = new(name => new InputBaseAst(AstNulls.At, name), arguments => arguments.InputArgs());

  internal override IAstObjBaseChecks<IGqlpInputBase> ObjBaseChecks => _checks;
}
