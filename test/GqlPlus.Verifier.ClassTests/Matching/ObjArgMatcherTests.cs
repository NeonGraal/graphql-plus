namespace GqlPlus.Matching;

public class ObjArgMatcherTests
  : MatcherTestsBase
{
  internal ObjTypeArgMatcher Matcher { get; set; }

  internal Matcher<IGqlpType>.I AnyType { get; set; }

  public ObjArgMatcherTests()
  {
    Matcher<IGqlpType>.D anyDelegate = MatcherFor(out Matcher<IGqlpType>.I anyInterface);
    AnyType = anyInterface;

    Matcher = new(LoggerFactory, anyDelegate);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingArgFullType(string name, string constraint)
  {
    IGqlpObjTypeArg arg = A.Named<IGqlpObjTypeArg>(name);
    arg.FullType.Returns(constraint);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingArgParamType(string name, string paramName, string constraint)
  {
    this.SkipEqual(paramName, constraint);

    IGqlpObjTypeArg arg = A.Named<IGqlpObjTypeArg>(name);
    arg.FullType.Returns("$" + paramName);
    arg.IsTypeParam.Returns(true);

    IGqlpType typeParam = A.Named<IGqlpType>(constraint);
    Types[arg.FullType] = typeParam;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsSame_WhenCallingAnyMatcher(string name, string type, string constraint, bool expected)
  {
    this.SkipEqual(type, constraint);

    IGqlpObjTypeArg arg = A.Named<IGqlpObjTypeArg>(name);
    arg.FullType.Returns(type);

    IGqlpType baseType = A.Named<IGqlpType>(type);
    Types[type] = baseType;

    AnyTypeReturns(baseType, constraint, expected);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintParentOfEnum_WithArgLabel(string enumName, string enumLabel, string constraint)
  {
    this.SkipEqual(enumName, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg(enumName, enumLabel);
    IGqlpEnum enumParent = A.Enum(enumName, [enumLabel]);
    Types[enumName] = enumParent;

    IGqlpEnum enumConstraint = A.Enum(constraint, enumName);
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsFalse_WhenConstraintEnumNotLabel_WithArgType(string name, string enumLabel, string constraint)
  {
    this.SkipEqual3(enumLabel, name, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg("", enumLabel);
    IGqlpEnum enumConstraint = A.Enum(constraint, []);
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintDomParentOfEnum_WithArgLabel(string enumName, string enumLabel, string constraint)
  {
    this.SkipEqual(enumName, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg(enumName, enumLabel);
    IGqlpEnum enumParent = A.Enum(enumName, [enumLabel]);
    Types[enumName] = enumParent;

    IGqlpDomain<IGqlpDomainLabel> domConstraint = A.DomainEnum(constraint, null, enumName, enumLabel);
    Types[constraint] = domConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsFalse_WhenConstraintDomNotLabel_WithArgType(string name, string enumLabel, string constraint)
  {
    this.SkipEqual3(enumLabel, name, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg("", enumLabel);
    IGqlpDomain<IGqlpDomainLabel> domConstraint = A.DomainEnum(constraint, null);
    Types[constraint] = domConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintSame_WithEnumTypeParam(string name, string enumName, string paramName, string constraint)
  {
    IGqlpObjTypeArg arg = A.Named<IGqlpObjTypeArg>(name);
    IGqlpObjType enumType = A.Named<IGqlpObjType>(enumName);
    enumType.IsTypeParam.Returns(true);
    arg.FullType.Returns("$" + enumName);

    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    Types[arg.FullType] = typeParam;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenConstraintChildOfEnum_WithArgLabel(string enumName, string enumLabel, string constraint, bool expected)
  {
    this.SkipEqual(enumName, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg(enumName, enumLabel);
    IGqlpEnum enumParent = A.Enum(enumName, [enumLabel], constraint);
    Types[enumName] = enumParent;

    IGqlpEnum enumConstraint = A.Enum(constraint, []);
    Types[constraint] = enumConstraint;

    AnyTypeReturns(enumParent, constraint, expected);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBe(expected);
  }

  protected void AnyTypeReturns(IGqlpType type, string constraint, bool expected)
    => AnyType.Matches(type, constraint, Context).Returns(expected);
}
