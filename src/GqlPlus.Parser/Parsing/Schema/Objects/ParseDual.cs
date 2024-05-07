﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDual(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<DualFieldAst, DualBaseAst>>.D definition
) : ObjectParser<DualDeclAst, DualFieldAst, DualBaseAst>(name, param, aliases, option, definition)
{
  protected override DualDeclAst MakeResult(AstPartial<IGqlpTypeParameter, NullOption> partial, ObjectDefinition<DualFieldAst, DualBaseAst> value)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
      Parent = value.Parent,
      Fields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override DualDeclAst ToResult(AstPartial<IGqlpTypeParameter, NullOption> partial)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
    };
}

internal class ParseDualDefinition(
  Parser<DualFieldAst>.D field,
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<DualBaseAst>.D objBase
) : ParseObjectDefinition<DualFieldAst, DualBaseAst>(field, collections, objBase)
{
  protected override string Label => "Dual";
}
