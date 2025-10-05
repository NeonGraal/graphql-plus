namespace GqlPlus.Matching;

public abstract class ObjectDualSameMatcherTests<TObject>(TypeKind kind)
  : ObjectSameMatcherTests<TObject>(kind)
  where TObject : class, IGqlpObject
{
  [Theory, RepeatData]
  public void Object_Matches_DualParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    TObject type = A.Obj<TObject>(Kind, name, parent);

    IGqlpDualObject parentType = A.Obj<IGqlpDualObject>(Kind, parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  internal override ObjectSameMatcher<TObject> Sut => DualSut;
  internal abstract MatchObjectSameDualBase<TObject> DualSut { get; }
}

public class InputObjectSameMatcherTests
  : ObjectDualSameMatcherTests<IGqlpInputObject>
{
  public InputObjectSameMatcherTests()
    : base(TypeKind.Input)
    => DualSut = new(LoggerFactory);

  internal override MatchObjectSameDualBase<IGqlpInputObject> DualSut { get; }
}

public class OutputObjectSameMatcherTests
  : ObjectDualSameMatcherTests<IGqlpOutputObject>
{
  public OutputObjectSameMatcherTests()
    : base(TypeKind.Output)
    => DualSut = new(LoggerFactory);

  internal override MatchObjectSameDualBase<IGqlpOutputObject> DualSut { get; }
}
