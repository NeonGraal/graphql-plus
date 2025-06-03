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
  public void Matches_ReturnsFalse_WhenConstraintEnumNotLabel_WithArgType(string name, string enumLabel, string constraint)
  {
    IGqlpOutputArg arg = NFor<IGqlpOutputArg>(name);
    IGqlpObjType enumType = NFor<IGqlpObjType>(enumLabel);
    arg.EnumType.Returns(enumType);

    IGqlpEnum enumConstraint = NFor<IGqlpEnum>(constraint);
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintDomParentOfEnum_WithArgLabel(string name, string enumName, string enumLabel, string constraint)
  {
    IGqlpOutputArg arg = NFor<IGqlpOutputArg>(name);
    IGqlpObjType enumType = NFor<IGqlpObjType>(enumName);
    arg.EnumType.Returns(enumType);
    arg.EnumLabel.Returns(enumLabel);

    IGqlpEnum enumParent = NFor<IGqlpEnum>(enumName);
    enumParent.HasValue(enumLabel).Returns(true);
    Types[enumName] = enumParent;

    IGqlpDomain<IGqlpDomainLabel> domConstraint = NFor<IGqlpDomain<IGqlpDomainLabel>>(constraint);
    IGqlpDomainLabel domainLabel = EFor<IGqlpDomainLabel>();
    domainLabel.EnumType.Returns(enumName);
    domainLabel.EnumItem.Returns(enumLabel);
    domConstraint.Items.Returns([domainLabel]);
    Types[constraint] = domConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsFalse_WhenConstraintDomNotLabel_WithArgType(string name, string enumLabel, string constraint)
  {
    IGqlpOutputArg arg = NFor<IGqlpOutputArg>(name);
    IGqlpObjType enumType = NFor<IGqlpObjType>(enumLabel);
    arg.EnumType.Returns(enumType);

    IGqlpDomain<IGqlpDomainLabel> domConstraint = NFor<IGqlpDomain<IGqlpDomainLabel>>(constraint);
    Types[constraint] = domConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintSame_WithEnumTypeParam(string name, string enumName, string paramName, string constraint)
  {
    IGqlpOutputArg arg = NFor<IGqlpOutputArg>(name);
    IGqlpObjType enumType = NFor<IGqlpObjType>(enumName);
    enumType.IsTypeParam.Returns(true);
    arg.EnumType.Returns(enumType);
    arg.FullType.Returns("$" + enumName);

    IGqlpTypeParam typeParam = NFor<IGqlpTypeParam>(paramName);
    typeParam.Constraint.Returns(constraint);
    Types[arg.FullType] = typeParam;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenConstraintChildOfEnum_WithArgLabel(string name, string enumName, string enumLabel, string constraint, bool expected)
  {
    this.SkipIf(enumName == constraint);

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
