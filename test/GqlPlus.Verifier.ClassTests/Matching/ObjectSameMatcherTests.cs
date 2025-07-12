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
    TObject type = A.Named<TObject>(constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipIf(name == constraint);

    TObject type = A.Named<TObject>(name);
    IGqlpObjBase typeBase = A.Named<IGqlpObjBase>(constraint);
    type.Parent.Returns(typeBase);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipIf(name == parent);

    TObject type = A.Named<TObject>(name);
    IGqlpObjBase typeBase = A.Named<IGqlpObjBase>(parent);
    type.Parent.Returns(typeBase);

    TObject parentType = A.Named<TObject>(parent);
    IGqlpObjBase parentBase = A.Named<IGqlpObjBase>(constraint);
    parentType.Parent.Returns(parentBase);
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
    this.SkipIf(name == parent);

    TObject type = A.Named<TObject>(name);
    IGqlpObjBase typeBase = A.Named<IGqlpObjBase>(parent);
    type.Parent.Returns(typeBase);

    IGqlpDualObject parentType = A.Named<IGqlpDualObject>(parent);
    IGqlpObjBase parentBase = A.Named<IGqlpObjBase>(constraint);
    parentType.Parent.Returns(parentBase);
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
