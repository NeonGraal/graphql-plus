namespace GqlPlus.Matching;

public abstract class MatchObjectParentDualTestsBase<TObject, TField>(TypeKind kind)
  : ObjectParentMatcherTests<TObject, TField>(kind)
  where TObject : class, IGqlpObject<TField>
  where TField : class, IGqlpObjField
{
  [Theory, RepeatData]
  public void Object_Matches_DualParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    TObject type = A.Obj<TObject, TField>(Kind, name, parent);

    IGqlpDualObject parentType = A.Obj<IGqlpDualObject, IGqlpDualField>(Kind, parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  internal override ObjectParentMatcher<TObject> Sut => DualSut;
  internal abstract MatchObjectParentDualBase<TObject> DualSut { get; }
}

public class InputParentMatcherTests
  : MatchObjectParentDualTestsBase<IGqlpInputObject, IGqlpInputField>
{
  public InputParentMatcherTests()
    : base(TypeKind.Input)
    => DualSut = new(LoggerFactory);

  internal override MatchObjectParentDualBase<IGqlpInputObject> DualSut { get; }
}

public class OutputParentMatcherTests
  : MatchObjectParentDualTestsBase<IGqlpOutputObject, IGqlpOutputField>
{
  public OutputParentMatcherTests()
    : base(TypeKind.Output)
    => DualSut = new(LoggerFactory);

  internal override MatchObjectParentDualBase<IGqlpOutputObject> DualSut { get; }
}
