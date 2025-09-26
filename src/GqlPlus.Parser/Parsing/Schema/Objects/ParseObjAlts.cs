﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseObjAlts(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<IGqlpObjBase>.D parseBase
) : Parser<IGqlpObjAlt>.IA
{
  private readonly ParserArray<IParserCollections, IGqlpModifier>.LA _collections = collections;
  private readonly Parser<IGqlpObjBase>.L _parseBase = parseBase;

  public IResultArray<IGqlpObjAlt> Parse(ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();

    List<IGqlpObjAlt> result = [];
    while (tokens.Take('|')) {
      TokenAt at = tokens.At;
      IResult<IGqlpObjBase> objBase = _parseBase.Parse(tokens, label);
      if (!objBase.IsOk()) {
        return objBase.IsError()
          ? result.PartialArray(objBase.Message())
          : result.PartialArray(tokens.Error(label, "base missing after '|'"));
      }

      IGqlpObjBase baseObject = objBase.Required();
      ObjAltAst alternate = new(at, baseObject.Name, baseObject.Description) {
        IsTypeParam = baseObject.IsTypeParam,
        Args = baseObject.Args.ArrayOf<IGqlpObjTypeArg>(),
      };
      result.Add(alternate);
      IResultArray<IGqlpModifier> collections = _collections.Value.Parse(tokens, label);
      if (!collections.Optional(value => alternate.Modifiers = value.ArrayOf<ModifierAst>())) {
        return collections.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }
}
