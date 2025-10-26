﻿using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class EnumParser<TEnum>
  : IEnumParser<TEnum>
  where TEnum : struct
{
  public IResult<TEnum> Parse(ITokenizer tokens, string label)

      => tokens.Identifier(out string? option)
        ? Enum.TryParse(option, true, out TEnum result)
          ? result.Ok()
          : tokens.Error(label, "valid enum value", result)
        : default(TEnum).Empty();
}

public interface IEnumParser<TEnum>
  : Parser<TEnum>.I
  where TEnum : struct
{ }
