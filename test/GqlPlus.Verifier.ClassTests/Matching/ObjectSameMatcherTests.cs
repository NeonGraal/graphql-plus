namespace GqlPlus.Matching;

public abstract class ObjectSameMatcherTests<TObject>
  : MatcherTestsBase
  where TObject : class, IGqlpObject
{
  internal ObjectSameMatcher<TObject> Sut { get; }

  protected ObjectSameMatcherTests()
    => Sut = new(LoggerFactory);

  [Theory, RepeatData]
  public void Object_Matches_SameName_ReturnsTrue(string constraint)
  {
    TObject type = A.Obj<TObject>(constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipEqual(name, constraint);

    TObject type = A.Obj<TObject>(name, constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    TObject type = A.Obj<TObject>(name, parent);

    TObject parentType = A.Obj<TObject>(parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DualObjectSameMatcherTests
  : ObjectSameMatcherTests<IGqlpDualObject>
{ }

public abstract class ObjectDualSameMatcherTests<TObject>
  : ObjectSameMatcherTests<TObject>
  where TObject : class, IGqlpObject
{

  [Theory, RepeatData]
  public void Object_Matches_DualParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    TObject type = A.Obj<TObject>(name, parent);

    IGqlpDualObject parentType = A.Obj<IGqlpDualObject>(parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class InputObjectSameMatcherTests
  : ObjectDualSameMatcherTests<IGqlpInputObject>
{ }

public class OutputObjectSameMatcherTests
  : ObjectDualSameMatcherTests<IGqlpOutputObject>
{ }
