﻿using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

internal class ParseInput(
  ISimpleName name,
  Parser<TypeParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<InputFieldAst, InputBaseAst>>.D definition
) : ObjectParser<InputDeclAst, InputFieldAst, InputBaseAst>(name, param, aliases, option, definition)
{
  protected override InputDeclAst MakeResult(AstPartial<TypeParameterAst, NullOption> partial, ObjectDefinition<InputFieldAst, InputBaseAst> value)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters,
      Parent = value.Parent,
      Fields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override InputDeclAst ToResult(AstPartial<TypeParameterAst, NullOption> partial)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters,
    };
}

internal class ParseInputDefinition(
  Parser<InputFieldAst>.D field,
  ParserArray<IParserCollections, ModifierAst>.DA collections,
  Parser<InputBaseAst>.D objBase
) : ParseObjectDefinition<InputFieldAst, InputBaseAst>(field, collections, objBase)
{
  protected override string Label => "Input";
}
