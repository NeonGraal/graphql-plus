using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class EnumParser<E>
  : IEnumParser<E>
  where E : struct
{
  public IResult<E> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
      => tokens.Identifier(out var option)
        ? Enum.TryParse<E>(option, true, out var result)
          ? result.Ok()
          : tokens.Error(label, "valid enum value", result)
        : 0.Empty<E>();
}

public interface IEnumParser<E>
  : Parser<E>.I
  where E : struct
{ }
