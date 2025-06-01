namespace GqlPlus.Matching;

public abstract class ObjArgMatcherTests<TObjArg>
  : MatcherTestsBase
  where TObjArg : class, IGqlpObjArg
{
  internal ObjArgMatcher<TObjArg> Matcher { get; }

  private readonly Matcher<IGqlpType>.I _anyType;

  protected ObjArgMatcherTests()
  {
    Matcher<IGqlpType>.D anyType = MatcherFor(out _anyType);

    Matcher = new(anyType);
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

    _anyType.Matches(baseType, constraint, Context).Returns(expected);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBe(expected);
  }
}

public class DualArgMatcherTests
  : ObjArgMatcherTests<IGqlpDualArg>
{ }

public class InputArgMatcherTests
  : ObjArgMatcherTests<IGqlpInputArg>
{ }

public class OutputArgMatcherTests
  : ObjArgMatcherTests<IGqlpOutputArg>
{ }
