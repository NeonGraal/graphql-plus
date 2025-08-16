using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

public abstract class ObjectSameMatcherTests<TObject, TBase>
  : MatcherTestsBase
  where TObject : class, IGqlpObject<TBase>
  where TBase : class, IGqlpObjBase
{
  internal ObjectSameMatcher<TObject> Sut { get; }

  protected ObjectSameMatcherTests()
    => Sut = new(LoggerFactory);

  [Theory, RepeatData]
  public void Object_Matches_SameName_ReturnsTrue(string constraint)
  {
    TObject type = A.Obj<TObject, TBase>(constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipIf(name == constraint);

    TObject type = A.Obj<TObject, TBase>(name, constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipIf(name == parent);

    TObject type = A.Obj<TObject, TBase>(name, parent);

    TObject parentType = A.Obj<TObject, TBase>(parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DualObjectSameMatcherTests
  : ObjectSameMatcherTests<IGqlpDualObject, IGqlpDualBase>
{ }

public abstract class ObjectDualSameMatcherTests<TObject, TBase>
  : ObjectSameMatcherTests<TObject, TBase>
  where TObject : class, IGqlpObject<TBase>
  where TBase : class, IGqlpObjBase
{

  [Theory, RepeatData]
  public void Object_Matches_DualParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipIf(name == parent);

    TObject type = A.Obj<TObject, TBase>(name, parent);

    IGqlpDualObject parentType = A.Obj<IGqlpDualObject, IGqlpDualBase>(parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class InputObjectSameMatcherTests
  : ObjectDualSameMatcherTests<IGqlpInputObject, IGqlpInputBase>
{ }

public class OutputObjectSameMatcherTests
  : ObjectDualSameMatcherTests<IGqlpOutputObject, IGqlpOutputBase>
{ }
