﻿namespace GqlPlus.Matching;

public abstract class ObjectSameMatcherTests<TObject>
  : MatcherTestsBase
  where TObject : class, IGqlpObject
{
  private readonly ObjectSameMatcher<TObject> _sut;

  protected ObjectSameMatcherTests()
    => _sut = new(LoggerFactory);

  [Theory, RepeatData]
  public void Object_Matches_SameName_ReturnsTrue(string constraint)
  {
    TObject type = A.Named<TObject>(constraint);

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipIf(name == constraint);

    TObject type = A.Named<TObject>(name);
    IGqlpObjBase typeBase = A.Named<IGqlpObjBase>(constraint);
    type.Parent.Returns(typeBase);

    bool result = _sut.Matches(type, constraint, Context);

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

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DualObjectSameMatcherTests
  : ObjectSameMatcherTests<IGqlpDualObject>
{ }

public class InputObjectSameMatcherTests
  : ObjectSameMatcherTests<IGqlpInputObject>
{ }

public class OutputObjectSameMatcherTests
  : ObjectSameMatcherTests<IGqlpOutputObject>
{ }
