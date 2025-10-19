using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Matching;

public class ObjArgMatcherTests
  : MatchTestsBase
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
  public void Matches_ReturnsTrue_WhenMatchingArgFullType(string constraint)
  {
    IGqlpObjTypeArg arg = A.ObjTypeArg(constraint);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingArgParamType(string name, string constraint)
  {
    this.SkipEqual(name, constraint);

    IGqlpObjTypeArg arg = A.ObjTypeArg(name, true);

    IGqlpType typeParam = A.Named<IGqlpType>(constraint);
    Types[arg.FullType] = typeParam;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsSame_WhenCallingAnyMatcher(string name, string constraint, bool expected)
  {
    this.SkipEqual(name, constraint);

    IGqlpObjTypeArg arg = A.ObjTypeArg(name);

    IGqlpType baseType = A.Named<IGqlpType>(name);
    Types[name] = baseType;

    AnyTypeReturns(baseType, constraint, expected);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintEnum_WithArgLabel(string enumName, string enumLabel, string constraint)
  {
    this.SkipEqual(enumName, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg(enumName, enumLabel);
    IGqlpEnum enumType = A.Enum(enumName, [enumLabel]);
    Types[enumName] = enumType;

    IGqlpEnum enumConstraint = A.Enum(constraint)
      .WithParent(enumName)
      .AsEnum;
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintEnumParent_WithArgLabel(string enumName, string enumParent, string enumLabel, string constraint)
  {
    this.SkipEqual3(enumName, enumParent, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg(enumParent, enumLabel);
    IGqlpEnum parentType = A.Enum(enumParent, [enumLabel]);
    Types[enumParent] = parentType;

    IGqlpEnum enumType = A.Enum(enumName)
      .WithParent(enumParent)
      .AsEnum;
    Types[enumName] = enumType;

    IGqlpEnum enumConstraint = A.Enum(constraint)
      .WithParent(enumName)
      .AsEnum;
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsFalse_WhenConstraintEnumNotLabel_WithArgType(string name, string enumLabel, string constraint)
  {
    this.SkipEqual3(enumLabel, name, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg("", enumLabel);
    IGqlpEnum enumConstraint = A.Enum(constraint).AsEnum;
    Types[constraint] = enumConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintDomOfEnum_WithArgLabel(string enumName, string enumLabel, string constraint)
  {
    this.SkipEqual(enumName, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg(enumName, enumLabel);
    IGqlpEnum enumType = A.Enum(enumName, [enumLabel]);
    Types[enumName] = enumType;

    IGqlpDomain<IGqlpDomainLabel> domConstraint = A.DomainEnum(constraint, enumName, enumLabel);
    Types[constraint] = domConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintDomParentOfEnum_WithArgLabel(string enumName, string enumLabel, string domName, string constraint)
  {
    this.SkipEqual3(enumName, domName, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg(enumName, enumLabel);
    IGqlpEnum enumParent = A.Enum(enumName, [enumLabel]);
    Types[enumName] = enumParent;

    IGqlpDomain<IGqlpDomainLabel> domType = A.DomainEnum(domName, enumName, enumLabel);
    Types[domName] = domType;

    IGqlpDomain<IGqlpDomainLabel> domConstraint = A.DomainEnum(constraint);
    Types[constraint] = A.SetParent(domConstraint, domName);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsFalse_WhenConstraintDomNotLabel_WithArgType(string name, string enumLabel, string constraint)
  {
    this.SkipEqual3(enumLabel, name, constraint);

    IGqlpObjTypeArg arg = A.ObjEnumArg("", enumLabel);
    IGqlpDomain<IGqlpDomainLabel> domConstraint = A.DomainEnum(constraint);
    Types[constraint] = domConstraint;

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenConstraintSame_WithEnumTypeParam(string name, string enumName, string paramName, string constraint)
  {
    IGqlpObjTypeArg arg = A.ObjTypeArg(name);
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

    IGqlpEnum enumConstraint = A.Enum(constraint).AsEnum;
    Types[constraint] = enumConstraint;

    AnyTypeReturns(enumParent, constraint, expected);

    bool result = Matcher.Matches(arg, constraint, Context);

    result.ShouldBe(expected);
  }

  protected void AnyTypeReturns(IGqlpType type, string constraint, bool expected)
    => AnyType.Matches(type, constraint, Context).Returns(expected);
}
