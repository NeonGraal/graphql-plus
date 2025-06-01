namespace GqlPlus.Matching;

public class OutputArgMatcherTests
  : ObjArgMatcherTests<IGqlpOutputArg>
{
  public OutputArgMatcherTests()
  {
    Matcher<IGqlpType>.D anyDelegate = MatcherFor(out Matcher<IGqlpType>.I anyInterface);
    AnyType = anyInterface;

    Matcher = new OutputArgMatcher(anyDelegate);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintParentOfEnum_WithArgLabel(string name, string enumName, string enumLabel, string constraint)
  {
    IGqlpOutputArg arg = NFor<IGqlpOutputArg>(name);
    IGqlpObjType enumType = NFor<IGqlpObjType>(enumName);
    arg.EnumType.Returns(enumType);
    arg.EnumLabel.Returns(enumLabel);

    IGqlpEnum enumParent = NFor<IGqlpEnum>(enumName);
    enumParent.HasValue(enumLabel).Returns(true);
    Types[enumName] = enumParent;

    IGqlpEnum enumConstraint = NFor<IGqlpEnum>(constraint);
    enumConstraint.Parent.Returns(enumName);
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenConstraintChildOfEnum_WithArgLabel(string name, string enumName, string enumLabel, string constraint, bool expected)
  {
    IGqlpOutputArg arg = NFor<IGqlpOutputArg>(name);
    IGqlpObjType enumType = NFor<IGqlpObjType>(enumName);
    arg.FullType.Returns(enumName);
    arg.EnumType.Returns(enumType);
    arg.EnumLabel.Returns(enumLabel);

    IGqlpEnum enumParent = NFor<IGqlpEnum>(enumName);
    enumParent.Parent.Returns(constraint);
    enumParent.HasValue(enumLabel).Returns(true);
    Types[enumName] = enumParent;

    IGqlpEnum enumConstraint = NFor<IGqlpEnum>(constraint);
    Types[constraint] = enumConstraint;

    AnyTypeReturns(enumParent, constraint, expected);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBe(expected);
  }
}
