using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class EnumParser<TEnum>
  : IEnumParser<TEnum>
  where TEnum : struct
{
  public IResult<TEnum> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
      => tokens.Identifier(out var option)
        ? Enum.TryParse<TEnum>(option, true, out var result)
          ? result.Ok()
          : tokens.Error(label, "valid enum value", result)
        : 0.Empty<TEnum>();
}

public interface IEnumParser<TEnum>
  : Parser<TEnum>.I
  where TEnum : struct
{ }
