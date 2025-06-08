namespace GqlPlus.Matching;

public class OutputArgMatcherTests
  : ObjArgMatcherTests<IGqlpOutputArg>
{
  public OutputArgMatcherTests()
  {
    Matcher<IGqlpType>.D anyDelegate = MatcherFor(out Matcher<IGqlpType>.I anyInterface);
    AnyType = anyInterface;

    Matcher = new OutputArgMatcher(LoggerFactory, anyDelegate);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintParentOfEnum_WithArgLabel(string name, string enumName, string enumLabel, string constraint)
  {
    this.SkipIf(enumName == constraint);

    IGqlpOutputArg arg = A.Named<IGqlpOutputArg>(name);
    IGqlpObjType enumType = A.Named<IGqlpObjType>(enumName);
    arg.EnumType.Returns(enumType);
    arg.EnumLabel.Returns(enumLabel);

    IGqlpEnum enumParent = A.Enum(enumName, [enumLabel]);
    Types[enumName] = enumParent;

    IGqlpEnum enumConstraint = A.Enum(constraint, [], enumName);
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsFalse_WhenConstraintEnumNotLabel_WithArgType(string name, string enumLabel, string constraint)
  {
    IGqlpOutputArg arg = A.Named<IGqlpOutputArg>(name);
    IGqlpObjType enumType = A.Named<IGqlpObjType>(enumLabel);
    arg.EnumType.Returns(enumType);

    IGqlpEnum enumConstraint = A.Enum(constraint, []);
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintDomParentOfEnum_WithArgLabel(string name, string enumName, string enumLabel, string constraint)
  {
    this.SkipIf(enumName == constraint);

    IGqlpOutputArg arg = A.Named<IGqlpOutputArg>(name);
    IGqlpObjType enumType = A.Named<IGqlpObjType>(enumName);
    arg.EnumType.Returns(enumType);
    arg.EnumLabel.Returns(enumLabel);

    IGqlpEnum enumParent = A.Enum(enumName, [enumLabel]);
    Types[enumName] = enumParent;

    IGqlpDomain<IGqlpDomainLabel> domConstraint = A.DomainEnum(constraint, enumName, enumLabel);
    Types[constraint] = domConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsFalse_WhenConstraintDomNotLabel_WithArgType(string name, string enumLabel, string constraint)
  {
    IGqlpOutputArg arg = A.Named<IGqlpOutputArg>(name);
    IGqlpObjType enumType = A.Named<IGqlpObjType>(enumLabel);
    arg.EnumType.Returns(enumType);

    IGqlpDomain<IGqlpDomainLabel> domConstraint = A.DomainEnum(constraint, "", "");
    Types[constraint] = domConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintSame_WithEnumTypeParam(string name, string enumName, string paramName, string constraint)
  {
    IGqlpOutputArg arg = A.Named<IGqlpOutputArg>(name);
    IGqlpObjType enumType = A.Named<IGqlpObjType>(enumName);
    enumType.IsTypeParam.Returns(true);
    arg.EnumType.Returns(enumType);
    arg.FullType.Returns("$" + enumName);

    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    Types[arg.FullType] = typeParam;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenConstraintChildOfEnum_WithArgLabel(string name, string enumName, string enumLabel, string constraint, bool expected)
  {
    this.SkipIf(enumName == constraint);

    IGqlpOutputArg arg = A.Named<IGqlpOutputArg>(name);
    IGqlpObjType enumType = A.Named<IGqlpObjType>(enumName);
    arg.FullType.Returns(enumName);
    arg.EnumType.Returns(enumType);
    arg.EnumLabel.Returns(enumLabel);

    IGqlpEnum enumParent = A.Enum(enumName, [enumLabel], constraint);
    Types[enumName] = enumParent;

    IGqlpEnum enumConstraint = A.Enum(constraint, []);
    Types[constraint] = enumConstraint;

    AnyTypeReturns(enumParent, constraint, expected);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBe(expected);
  }
}
