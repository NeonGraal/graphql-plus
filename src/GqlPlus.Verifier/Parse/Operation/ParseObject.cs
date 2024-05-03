using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal class ParseObject(
  Parser<FieldAst>.D field,
  Parser<IAstSelection>.D selection
) : Parser<IAstSelection>.IA
{
  private readonly Parser<FieldAst>.L _field = field;
  private readonly Parser<IAstSelection>.L _selection = selection;

  public IResultArray<IAstSelection> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var fields = new List<IAstSelection>();
    if (!tokens.Take('{')) {
      return fields.EmptyArray();
    }

    while (!tokens.Take('}')) {
      var selection = _selection.Parse(tokens, label);
      if (selection.IsError()) {
        return selection.AsResultArray(fields);
      } else if (selection.Required(fields.Add)) {
        continue;
      }

      var field = _field.Parse(tokens, label);
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
