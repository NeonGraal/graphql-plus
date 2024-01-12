﻿using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

internal sealed class SimpleModelChecks
  : ModelBaseChecks<string, FieldKeyAst>
{
  protected override IRendering AstToModel(FieldKeyAst ast)
    => ast.ToModel();
  protected override FieldKeyAst NewBaseAst(string input)
    => new(AstNulls.At, input);
}
