using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjectDefinition<TObjField>(
  Parser<IGqlpObjAlt>.DA alternates,
  Parser<TObjField>.D parseField,
  Parser<IGqlpObjBase>.D parseBase
) : Parser<ObjectDefinition<TObjField>>.I
  where TObjField : IGqlpObjField
{
  private readonly Parser<IGqlpObjAlt>.LA _alternates = alternates;
  private readonly Parser<TObjField>.L _parseField = parseField;
  private readonly Parser<IGqlpObjBase>.L _parseBase = parseBase;

  public IResult<ObjectDefinition<TObjField>> Parse(ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();
    ObjectDefinition<TObjField> result = new();
    if (tokens.Take(':')) {
      IResult<IGqlpObjBase> objBase = _parseBase.Parse(tokens, label);
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
    IResultArray<IGqlpObjAlt> objectAlternates = _alternates.Parse(tokens, label);
    return !objectAlternates.Optional(alternates => result.Alternates = [.. alternates])
      ? objectAlternates.AsPartial(result)
      : tokens.End(label, () => result);
  }
}
