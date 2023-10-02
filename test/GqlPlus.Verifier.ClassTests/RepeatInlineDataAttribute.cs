using AutoFixture.Xunit2;

namespace GqlPlus.Verifier.ClassTests;

public class RepeatInlineDataAttribute : InlineAutoDataAttribute
{
  public RepeatInlineDataAttribute(int repeat, params object[] values)
    : base(new RepeatDataAttribute(repeat), values) { }
}
