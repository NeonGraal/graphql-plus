using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

public abstract class ValueObjectParser<T> : Parser<AstObject<T>>.I
  where T : AstValue<T>
{
  private readonly Parser<Field<T>>.L _field;

  protected ValueObjectParser(Parser<Field<T>>.D field)
    => _field = field;

  public abstract string Label { get; }

  public IResult<AstObject<T>> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var result = new AstObject<T>();

    if (!tokens.Take('{')) {
      return result.Empty();
    }

    while (!tokens.Take('}')) {
      var field = _field.Parse(tokens);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return tokens.Error(Label, "a field in object", result);
      }

      tokens.Take(',');
    }

    return result.Ok();
  }
}
