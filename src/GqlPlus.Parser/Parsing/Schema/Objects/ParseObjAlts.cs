﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseObjAlts(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<IGqlpObjBase>.D parseBase,
  Parser<IGqlpEnumValue>.D parseEnum
) : Parser<IGqlpObjAlt>.IA
{
  private readonly ParserArray<IParserCollections, IGqlpModifier>.LA _collections = collections;
  private readonly Parser<IGqlpObjBase>.L _parseBase = parseBase;
  private readonly Parser<IGqlpEnumValue>.L _parseEnum = parseEnum;

  public IResultArray<IGqlpObjAlt> Parse(ITokenizer tokens, string label)
  {
    tokens.ThrowIfNull();

    List<IGqlpObjAlt> result = [];
    while (tokens.TakeAny(out char selector, '|', '!')) {
      IResultArray<IGqlpObjAlt>? error = selector switch {
        '|' => ParseBase(tokens, label, result),
        '!' => ParseEnum(tokens, label, result),
        _ => result.PartialArray(tokens.Error(label, $"unexpected '{selector}' in Alts")),
      };
      if (error is not null) {
        return error;
      }
    }

    return result.OkArray();
  }

  private IResultArray<IGqlpObjAlt>? ParseBase(ITokenizer tokens, string label, List<IGqlpObjAlt> result)
  {
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

    return null;
  }

  private IResultArray<IGqlpObjAlt>? ParseEnum(ITokenizer tokens, string label, List<IGqlpObjAlt> result)
  {
    TokenAt at = tokens.At;
    IResult<IGqlpEnumValue> enumResult = _parseEnum.Parse(tokens, label);
    if (!enumResult.IsOk()) {
      return enumResult.IsError()
        ? result.PartialArray(enumResult.Message())
        : result.PartialArray(tokens.Error(label, "enum missing after '!'"));
    }

    IGqlpEnumValue enumValue = enumResult.Required();
    ObjAltAst alternate = new(at, enumValue.EnumType, "") {
      EnumValue = enumValue,
    };

    result.Add(alternate);
    return null;
  }
}
