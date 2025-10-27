namespace GqlPlus.Matching;

public abstract class MatchObjectParentDualTestsBase<TField>(TypeKind kind)
  : ObjectParentMatcherTests<TField>(kind)
  where TField : class, IGqlpObjField
{
  [Theory, RepeatData]
  public void Object_Matches_DualParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    IGqlpObject<TField> type = A.Obj<TField>(Kind, name, parent);

    IGqlpObject<IGqlpDualField> parentType = A.Obj<IGqlpDualField>(Kind, parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  internal override ObjectParentMatcher<TField> Sut => DualSut;
  internal abstract MatchObjectParentDualBase<TField> DualSut { get; }
}

public class InputParentMatcherTests
  : MatchObjectParentDualTestsBase<IGqlpInputField>
{
  public InputParentMatcherTests()
    : base(TypeKind.Input)
    => DualSut = new(LoggerFactory);

  internal override MatchObjectParentDualBase<IGqlpInputField> DualSut { get; }
}

public class OutputParentMatcherTests
  : MatchObjectParentDualTestsBase<IGqlpOutputField>
{
  public OutputParentMatcherTests()
    : base(TypeKind.Output)
    => DualSut = new(LoggerFactory);

  internal override MatchObjectParentDualBase<IGqlpOutputField> DualSut { get; }
}
