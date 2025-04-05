﻿namespace GqlPlus.Convert;

public class RenderLinesValueTests
  : RenderLinesValueBase
{
  protected override string Tag => "";
  protected override string Expected_Empty() => string.Empty;
  protected override string Expected_String(string value) => value;
  protected override string Expected_Identifier(string value) => value;
  protected override string Expected_Decimal(decimal value) => $"{value:0.#####}";
  protected override string Expected_Bool(bool value) => value.ToString().ToLowerInvariant();
}
