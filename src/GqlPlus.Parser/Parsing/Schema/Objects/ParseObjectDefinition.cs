using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseObjectDefinition<TObjField>(
  IParserRepository parsers
) : IParser<ObjectDefinition<TObjField>>
  where TObjField : IAstObjField
{
  private readonly ParserArray<IAstAlternate> _alternates = parsers.ArrayFor<IAstAlternate>();
  private readonly ParserOne<TObjField> _parseField = parsers.ParserFor<TObjField>();
  private readonly ParserOne<IAstObjBase> _parseBase = parsers.ParserFor<IAstObjBase>();

  public IResult<ObjectDefinition<TObjField>> Parse([NotNull] ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();
    ObjectDefinition<TObjField> result = new();
    if (tokens.Take(':')) {
      IResult<IAstObjBase> objBase = _parseBase.Parse(tokens, label);
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
    IResultArray<IAstAlternate> objectAlternates = _alternates.Parse(tokens, label);
    return !objectAlternates.Optional(alternates => result.Alternates = [.. alternates])
      ? objectAlternates.AsPartial(result)
      : tokens.End(label, () => result);
  }

  internal static ParseObjectDefinition<TObjField> Factory(IParserRepository p) => new(p);
}
