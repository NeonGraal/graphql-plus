﻿using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Ast.Schema.Types;

public class DomainTrueFalseAstTests
  : AstAbbreviatedTests<bool>
{
  private readonly AstAbbreviatedChecks<bool, DomainTrueFalseAst> _checks
    = new(input => new DomainTrueFalseAst(AstNulls.At, false, input));

  internal override IAstAbbreviatedChecks<bool> AbbreviatedChecks => _checks;
}
