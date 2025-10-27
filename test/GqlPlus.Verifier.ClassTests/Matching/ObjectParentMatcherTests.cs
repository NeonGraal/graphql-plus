namespace GqlPlus.Matching;

public abstract class ObjectParentMatcherTests<TField>(
  TypeKind kind
) : MatchTestsBase
    where TField : class, IGqlpObjField
{
  internal abstract ObjectParentMatcher<TField> Sut { get; }
  protected TypeKind Kind { get; } = kind;

  [Theory, RepeatData]
  public void Object_Matches_SameName_ReturnsTrue(string constraint)
  {
    IGqlpObject<TField> type = A.Obj<TField>(Kind, constraint).AsObject;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipEqual(name, constraint);

    IGqlpObject<TField> type = A.Obj<TField>(Kind, name, constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_ParentArgParam_ReturnsTrue(string name, string constraint, string typeArg)
  {
    this.SkipEqual(name, constraint);

    IGqlpTypeParam typeParam = A.TypeParam(typeArg, constraint);
    Types["$" + typeArg] = typeParam;

    IGqlpObject<TField> type = A.Obj<TField>(Kind, name, typeArg, true);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_ArgParamParent_ReturnsTrue(string name, string constraint, string typeArg, string parent)
  {
    this.SkipEqual(name, constraint);

    IGqlpObject<TField> parentType = A.Obj<TField>(Kind, parent, constraint);
    Types["$" + typeArg] = parentType;

    IGqlpObject<TField> type = A.Obj<TField>(Kind, name, typeArg, true);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    IGqlpObject<TField> type = A.Obj<TField>(Kind, name, parent);

    IGqlpObject<TField> parentType = A.Obj<TField>(Kind, parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DualObjectParentMatcherTests
  : ObjectParentMatcherTests<IGqlpDualField>
{
  public DualObjectParentMatcherTests()
    : base(TypeKind.Dual)
    => Sut = new(LoggerFactory);

  internal override ObjectParentMatcher<IGqlpDualField> Sut { get; }
}
