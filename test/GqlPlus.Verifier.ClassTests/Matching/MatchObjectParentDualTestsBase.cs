namespace GqlPlus.Matching;

public abstract class MatchObjectParentDualTestsBase<TObjField>(TypeKind kind)
  : ObjectParentMatcherTests<TObjField>(kind)
  where TObjField : class, IAstObjField
{
  [Theory, RepeatData]
  public void Object_Matches_DualParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    IAstObject<TObjField> type = A.Obj<TObjField>(Kind, name, parent);

    IAstObject<IAstDualField> parentType = A.Obj<IAstDualField>(Kind, parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  internal override ObjectParentMatcher<TObjField> Sut => DualSut;
  internal abstract MatchObjectParentDualBase<TObjField> DualSut { get; }
}

public class InputParentMatcherTests
  : MatchObjectParentDualTestsBase<IAstInputField>
{
  public InputParentMatcherTests()
    : base(TypeKind.Input)
    => DualSut = new(MatcherRepo);

  internal override MatchObjectParentDualBase<IAstInputField> DualSut { get; }
}

public class OutputParentMatcherTests
  : MatchObjectParentDualTestsBase<IAstOutputField>
{
  public OutputParentMatcherTests()
    : base(TypeKind.Output)
    => DualSut = new(MatcherRepo);

  internal override MatchObjectParentDualBase<IAstOutputField> DualSut { get; }
}
