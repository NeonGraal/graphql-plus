﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public class DomainRegexAstTests
  : AstAbbreviatedTests
{
  protected override string AbbreviatedString(string input)
    => $"( !DX /{input}/ )";

  private readonly AstAbbreviatedChecks<IGqlpDomainRegex> _checks
    = new(regex => new DomainRegexAst(AstNulls.At, "", false, regex));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
