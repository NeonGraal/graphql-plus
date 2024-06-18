﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjectDefinition<TObjField, TObjAlt, TObjBase>(
  Parser<TObjAlt>.DA alternates,
  Parser<TObjField>.D parseField,
  Parser<TObjBase>.D parseBase
) : Parser<ObjectDefinition<TObjField, TObjAlt, TObjBase>>.I
  where TObjField : IGqlpObjField<TObjBase>
  where TObjAlt : IGqlpObjAlternate<TObjBase>
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
{
  private readonly Parser<TObjAlt>.LA _alternates = alternates;
  private readonly Parser<TObjField>.L _parseField = parseField;
  private readonly Parser<TObjBase>.L _parseBase = parseBase;

  public IResult<ObjectDefinition<TObjField, TObjAlt, TObjBase>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);
    ObjectDefinition<TObjField, TObjAlt, TObjBase> result = new();
    if (tokens.Take(':')) {
      IResult<TObjBase> objBase = _parseBase.Parse(tokens, label);
      if (objBase.IsError()) {
        return objBase.AsResult(result);
      }

      objBase.WithResult(parent => result.Parent = parent);
    }

    List<TObjField> fields = [];
    IResult<TObjField> objectField = _parseField.Parse(tokens, label);
    if (objectField.IsError()) {
      return objectField.AsPartial(result);
    }

    while (objectField.Required(fields.Add)) {
      objectField = _parseField.Parse(tokens, label);
      if (objectField.IsError()) {
        return objectField.AsPartial(result, fields.Add, () =>
          result.Fields = [.. fields]);
      }
    }

    result.Fields = [.. fields];
    IResultArray<TObjAlt> objectAlternates = _alternates.Parse(tokens, label);
    return !objectAlternates.Optional(alternates => result.Alternates = [.. alternates])
      ? objectAlternates.AsPartial(result)
      : tokens.End(label, () => result);
  }
}
