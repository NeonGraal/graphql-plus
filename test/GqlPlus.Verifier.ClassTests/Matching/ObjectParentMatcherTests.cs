namespace GqlPlus.Matching;

public abstract class ObjectParentMatcherTests<TObject, TField>(
  TypeKind kind
) : MatchTestsBase
    where TObject : class, IGqlpObject<TField>
    where TField : class, IGqlpObjField
{
  internal abstract ObjectParentMatcher<TObject> Sut { get; }
  protected TypeKind Kind { get; } = kind;

  [Theory, RepeatData]
  public void Object_Matches_SameName_ReturnsTrue(string constraint)
  {
    TObject type = A.Obj<TObject, TField>(Kind, constraint).AsObject;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipEqual(name, constraint);

    TObject type = A.Obj<TObject, TField>(Kind, name, constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_ParentArgParam_ReturnsTrue(string name, string constraint, string typeArg)
  {
    this.SkipEqual(name, constraint);

    IGqlpTypeParam typeParam = A.TypeParam(typeArg, constraint);
    Types["$" + typeArg] = typeParam;

    TObject type = A.Obj<TObject, TField>(Kind, name, typeArg, true);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_ArgParamParent_ReturnsTrue(string name, string constraint, string typeArg, string parent)
  {
    this.SkipEqual(name, constraint);

    TObject parentType = A.Obj<TObject, TField>(Kind, parent, constraint);
    Types["$" + typeArg] = parentType;

    TObject type = A.Obj<TObject, TField>(Kind, name, typeArg, true);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    TObject type = A.Obj<TObject, TField>(Kind, name, parent);

    TObject parentType = A.Obj<TObject, TField>(Kind, parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DualObjectParentMatcherTests
  : ObjectParentMatcherTests<IGqlpDualObject, IGqlpDualField>
{
  public DualObjectParentMatcherTests()
    : base(TypeKind.Dual)
    => Sut = new(LoggerFactory);

  internal override ObjectParentMatcher<IGqlpDualObject> Sut { get; }
}
