﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseInput : ObjectParser<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  public ParseInput(
    TypeName name,
    Parser<TypeParameterAst>.DA param,
    Parser<string>.DA aliases,
    Parser<NullAst>.D option,
    Parser<ObjectDefinition<InputFieldAst, InputReferenceAst>>.D definition
  ) : base(name, param, aliases, option, definition) { }

  protected override void ApplyDefinition(InputDeclAst result, ObjectDefinition<InputFieldAst, InputReferenceAst> value)
  {
    result.Extends = value.Extends;
    result.Fields = value.Fields;
    result.Alternates = value.Alternates;
  }

  protected override bool ApplyOption(InputDeclAst result, IResult<NullAst> option) => true;

  [return: NotNull]
  protected override InputDeclAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class ParseInputDefinition : ParseObjectDefinition<InputFieldAst, InputReferenceAst>
{
  public ParseInputDefinition(
    Parser<InputFieldAst>.D field,
    Parser<ModifierAst>.DA modifiers,
    Parser<InputReferenceAst>.D reference
  ) : base(field, modifiers, reference) { }

  protected override string Label => "Input";
}