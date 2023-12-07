using AutoFixture.Xunit2;

namespace GqlPlus.Verifier;

public class RepeatInlineDataAttribute(int repeat, params object[] values)
  : InlineAutoDataAttribute(new RepeatDataAttribute(repeat), values)
{ }
