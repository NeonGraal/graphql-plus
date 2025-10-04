namespace GqlPlus.Matching;

public abstract class ObjectSameMatcherTests<TObject>
  : MatcherTestsBase
  where TObject : class, IGqlpObject
{
  internal ObjectSameMatcher<TObject> Sut { get; }
  protected TypeKind Kind { get; }

  protected ObjectSameMatcherTests(TypeKind kind)
    => (Kind, Sut) = (kind, new(LoggerFactory));

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
  { }
}

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
}

public class InputObjectSameMatcherTests
  : ObjectDualSameMatcherTests<IGqlpInputObject>
{
  public InputObjectSameMatcherTests()
    : base(TypeKind.Input)
  { }
}

public class OutputObjectSameMatcherTests
  : ObjectDualSameMatcherTests<IGqlpOutputObject>
{
  public OutputObjectSameMatcherTests()
    : base(TypeKind.Output)
  { }
}
