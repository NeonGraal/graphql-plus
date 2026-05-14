using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseObject(
  IParserRepository parsers
) : IParserArray<IAstSelection>
{
  private readonly ParserOne<IAstField> _field = parsers.ParserFor<IAstField>();
  private readonly ParserOne<IAstSelection> _selection = parsers.ParserFor<IAstSelection>();

  public IResultArray<IAstSelection> Parse([NotNull] ITokenizer tokens, string label)

  {
    List<IAstSelection> fields = [];
    if (!tokens.Take('{')) {
      return fields.EmptyArray();
    }

    while (!tokens.Take('}')) {
      IResult<IAstSelection> selection = _selection.Parse(tokens, label);
      if (selection.IsError()) {
        return selection.AsResultArray(fields);
      } else if (selection.Required(fields.Add)) {
        continue;
      }

      IResult<IAstField> field = _field.Parse(tokens, label);
      if (field.IsError()) {
        return field.AsResultArray(fields);
      }

      field.WithResult(fields.Add);
    }

    return fields.Count == 0
      ? tokens.PartialArray(label, "at least one field or selection", () => fields)
      : fields.OkArray();
  }

  internal static ParseObject Factory(IParserRepository p) => new(p);
}
