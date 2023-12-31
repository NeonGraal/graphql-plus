﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class InputFactories
  : IObjectFactories<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  public InputFieldAst Field(TokenAt at, string name, InputReferenceAst typeReference, string description)
    => new(at, name, description, typeReference);

  public InputDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public InputReferenceAst Reference(TokenAt at, string name, string description)
    => new(at, name, description);
}
