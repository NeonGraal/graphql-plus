namespace GqlPlus.Matching;

public abstract class ObjArgMatcherTests<TObjArg>
  : MatcherTestsBase
  where TObjArg : class, IGqlpObjArg
{
  internal ObjArgMatcher<TObjArg> Matcher { get; set; }

  internal Matcher<IGqlpType>.I AnyType { get; set; }

  protected ObjArgMatcherTests()
  {
    Matcher<IGqlpType>.D anyDelegate = MatcherFor(out Matcher<IGqlpType>.I anyInterface);
    AnyType = anyInterface;

    Matcher = new(anyDelegate);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingAll(string name, string constraint)
  {
    TObjArg arg = NFor<TObjArg>(name);
    arg.FullType.Returns(constraint);

    bool result = Matcher.Matches(arg, "_Any", Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingArgFullType(string name, string constraint)
  {
    TObjArg arg = NFor<TObjArg>(name);
    arg.FullType.Returns(constraint);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingArgParamType(string name, string type, string constraint)
  {
    this.SkipIf(type == constraint);

    TObjArg arg = NFor<TObjArg>(name);
    arg.FullType.Returns(type);
    arg.IsTypeParam.Returns(true);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingArgTypeLabel(string name, string type, string constraint)
  {
    TObjArg arg = NFor<TObjArg>(name);
    arg.FullType.Returns(type);

    IGqlpType baseType = NFor<IGqlpType>(type);
    baseType.Label.Returns(constraint);
    Types[type] = baseType;

    bool result = Matcher.Matches(arg, "_" + constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsSame_WhenCallingAnyMatcher(string name, string type, string constraint, bool expected)
  {
    TObjArg arg = NFor<TObjArg>(name);
    arg.FullType.Returns(type);

    IGqlpType baseType = NFor<IGqlpType>(type);
    Types[type] = baseType;

    AnyTypeReturns(baseType, constraint, expected);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBe(expected);
  }

  protected void AnyTypeReturns(IGqlpType type, string constraint, bool expected)
    => AnyType.Matches(type, constraint, Context).Returns(expected);
}

public class DualArgMatcherTests
  : ObjArgMatcherTests<IGqlpDualArg>
{ }

public class InputArgMatcherTests
  : ObjArgMatcherTests<IGqlpInputArg>
{ }
