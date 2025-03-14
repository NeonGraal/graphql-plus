﻿using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class EnumMemberAstTests
  : AstAliasedTests
{
  private readonly AstAliasedChecks<EnumMemberAst> _checks
    = new(name => new EnumMemberAst(AstNulls.At, name));

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
