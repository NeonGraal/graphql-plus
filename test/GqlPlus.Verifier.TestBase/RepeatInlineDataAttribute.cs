using AutoFixture.Xunit2;

namespace GqlPlus.Verifier;

public sealed class RepeatInlineDataAttribute(int repeat, params object[] values)
  : InlineAutoDataAttribute(new RepeatDataAttribute(repeat), values)
{
  public int Repeat { get; } = repeat;
}
