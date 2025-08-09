﻿using System.Text.RegularExpressions;

namespace GqlPlus.Decoding;

internal interface INameFilterDecoder
  : IDecoder<string>
{ }

internal class NameFilterModelDecoder
  : ScalarDecoder<string>, INameFilterDecoder
{
  internal static readonly Regex Valid = new(@"^[a-zA-Z_.*]+$");

  protected override IMessages DecodeBoolean(bool? boolValue, out string? output)
    => Error($"A boolean ({boolValue.TrueFalse()}) is not a valid NameFilter value", output = null);
  protected override IMessages DecodeNumber(decimal? numValue, out string? output)
    => Error($"A number ({numValue:0.#####}) is not a valid NameFilter value", output = null);
  protected override IMessages DecodeText(string strValue, out string? output)
  {
    if (Valid.IsMatch(strValue)) {
      return base.Ok(output = strValue);
    }

    return Error($"'{strValue}' is not a valid NameFilter value", output = null);
  }
}
