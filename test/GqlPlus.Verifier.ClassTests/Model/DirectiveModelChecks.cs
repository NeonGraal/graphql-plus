﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class DirectiveModelChecks : ModelAliasedChecks<string, DirectiveDeclAst>
{
  protected override IRendering AstToModel(DirectiveDeclAst aliased)
    => aliased.ToModel();

  protected override DirectiveDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
