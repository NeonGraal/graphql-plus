namespace GqlPlus;

public class DeferOneTests
{
  [Theory, RepeatData]
  public void I_ValidFactory_ReturnsFactoryValue(string value)
  {
    DeferOne<string> defer = new(() => value);

    string result = defer.I;

    result.ShouldBe(value);
  }

  [Theory, RepeatData]
  public void ImplicitConvert_FromDelegate_ReturnsFactoryValue(string value)
  {
    DeferOne<string>.D factory = () => value;

    DeferOne<string> result = factory;

    result.I.ShouldBe(value);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    DeferOne<string>.D? factory = null;

    Action result = () => _ = (DeferOne<string>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
