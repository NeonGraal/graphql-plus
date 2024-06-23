using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjectDefinition<TObjBase, TObjField, TObjAlt>(
  Parser<TObjAlt>.DA alternates,
  Parser<TObjField>.D parseField,
  Parser<TObjBase>.D parseBase
) : Parser<ObjectDefinition<TObjBase, TObjField, TObjAlt>>.I
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{
  private readonly Parser<TObjAlt>.LA _alternates = alternates;
  private readonly Parser<TObjField>.L _parseField = parseField;
  private readonly Parser<TObjBase>.L _parseBase = parseBase;

  public IResult<ObjectDefinition<TObjBase, TObjField, TObjAlt>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);
    ObjectDefinition<TObjBase, TObjField, TObjAlt> result = new();
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
