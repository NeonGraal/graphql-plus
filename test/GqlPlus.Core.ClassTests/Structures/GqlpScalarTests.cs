using System.Globalization;

namespace GqlPlus;

public class GqlpScalarTests
{
  [Theory, RepeatData]
  public void ToString_GivenBoolean_ReturnsBoolean(bool value)
  {
    GqlpScalar scalar = new(value);

    scalar.ToString().ShouldBe(value.ToString());
  }

  [Theory, RepeatData]
  public void ToString_GivenNumber_ReturnsNumber(decimal value)
  {
    GqlpScalar scalar = new(value);

    scalar.ToString().ShouldBe(value.ToString(CultureInfo.CurrentCulture));
  }

  [Theory, RepeatData]
  public void ToString_GivenText_ReturnsText(string value)
  {
    GqlpScalar scalar = new(value);

    scalar.ToString().ShouldBe(value);
  }
}
