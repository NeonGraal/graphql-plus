using GqlPlus.Abstractions.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseObject(
  IParserRepository parsers
) : Parser<IGqlpSelection>.IA
{
  private readonly Parser<IGqlpField>.L _field = parsers.ParserFor<IGqlpField>();
  private readonly Parser<IGqlpSelection>.L _selection = parsers.ParserFor<IGqlpSelection>();

  public IResultArray<IGqlpSelection> Parse(ITokenizer tokens, string label)

  {
    List<IGqlpSelection> fields = [];
    if (!tokens.Take('{')) {
      return fields.EmptyArray();
    }

    while (!tokens.Take('}')) {
      IResult<IGqlpSelection> selection = _selection.Parse(tokens, label);
      if (selection.IsError()) {
        return selection.AsResultArray(fields);
      } else if (selection.Required(fields.Add)) {
        continue;
      }

      IResult<IGqlpField> field = _field.Parse(tokens, label);
      if (field.IsError()) {
        return field.AsResultArray(fields);
      }

      field.WithResult(fields.Add);
    }

    return fields.Count == 0
      ? tokens.PartialArray(label, "at least one field or selection", () => fields)
      : fields.OkArray();
  }
}
