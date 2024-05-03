using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Simple;

internal class EnumParser<TEnum>
  : IEnumParser<TEnum>
  where TEnum : struct
{
  public IResult<TEnum> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
      => tokens.Identifier(out string? option)
        ? Enum.TryParse<TEnum>(option, true, out TEnum result)
          ? result.Ok()
          : tokens.Error(label, "valid enum value", result)
        : 0.Empty<TEnum>();
}

public interface IEnumParser<TEnum>
  : Parser<TEnum>.I
  where TEnum : struct
{ }
