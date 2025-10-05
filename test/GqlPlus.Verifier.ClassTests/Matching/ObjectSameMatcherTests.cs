namespace GqlPlus.Matching;

public abstract class ObjectSameMatcherTests<TObject>(
  TypeKind kind
) : MatchTestsBase
  where TObject : class, IGqlpObject
{
  internal abstract ObjectSameMatcher<TObject> Sut { get; }
  protected TypeKind Kind { get; } = kind;

  [Theory, RepeatData]
  public void Object_Matches_SameName_ReturnsTrue(string constraint)
  {
    TObject type = A.Obj<TObject>(Kind, constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipEqual(name, constraint);

    TObject type = A.Obj<TObject>(Kind, name, constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    TObject type = A.Obj<TObject>(Kind, name, parent);

    TObject parentType = A.Obj<TObject>(Kind, parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DualObjectSameMatcherTests
  : ObjectSameMatcherTests<IGqlpDualObject>
{
  public DualObjectSameMatcherTests()
    : base(TypeKind.Dual)
    => Sut = new(LoggerFactory);

  internal override ObjectSameMatcher<IGqlpDualObject> Sut { get; }
}
