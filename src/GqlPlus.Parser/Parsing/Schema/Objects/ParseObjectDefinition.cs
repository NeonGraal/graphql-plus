using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjectDefinition<TObjField, TObjBase>(
  Parser<AstAlternate<TObjBase>>.DA alternates,
  Parser<TObjField>.D objField,
  Parser<TObjBase>.D objBase
) : Parser<ObjectDefinition<TObjField, TObjBase>>.I
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{
  private readonly Parser<AstAlternate<TObjBase>>.LA _alternates = alternates;
  private readonly Parser<TObjField>.L _objField = objField;
  private readonly Parser<TObjBase>.L _objBase = objBase;

  public IResult<ObjectDefinition<TObjField, TObjBase>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);
    ObjectDefinition<TObjField, TObjBase> result = new();
    if (tokens.Take(':')) {
      IResult<TObjBase> objBase = _objBase.Parse(tokens, label);
      if (objBase.IsError()) {
        return objBase.AsResult(result);
      }

      objBase.WithResult(parent => result.Parent = parent);
    }

    List<TObjField> fields = [];
    IResult<TObjField> objectField = _objField.Parse(tokens, label);
    if (objectField.IsError()) {
      return objectField.AsPartial(result);
    }

    while (objectField.Required(fields.Add)) {
      objectField = _objField.Parse(tokens, label);
      if (objectField.IsError()) {
        return objectField.AsPartial(result, fields.Add, () =>
          result.Fields = [.. fields]);
      }
    }

    result.Fields = [.. fields];
    IResultArray<AstAlternate<TObjBase>> objectAlternates = _alternates.Parse(tokens, label);
    return !objectAlternates.Optional(alternates => result.Alternates = [.. alternates])
      ? objectAlternates.AsPartial(result)
      : tokens.End(label, () => result);
  }
}
