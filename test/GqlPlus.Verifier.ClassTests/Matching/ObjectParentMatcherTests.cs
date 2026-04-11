using GqlPlus.Ast.Schema;

namespace GqlPlus.Matching;

public abstract class ObjectParentMatcherTests<TObjField>(
  TypeKind kind
) : MatchTestsBase
    where TObjField : class, IAstObjField
{
  internal abstract ObjectParentMatcher<TObjField> Sut { get; }
  protected TypeKind Kind { get; } = kind;

  [Theory, RepeatData]
  public void Object_Matches_SameName_ReturnsTrue(string constraint)
  {
    IAstObject<TObjField> type = A.Obj<TObjField>(Kind, constraint).AsObject;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_Parent_ReturnsTrue(string name, string constraint)
  {
    this.SkipEqual(name, constraint);

    IAstObject<TObjField> type = A.Obj<TObjField>(Kind, name, constraint);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_ParentArgParam_ReturnsTrue(string name, string constraint, string typeArg)
  {
    this.SkipEqual(name, constraint);

    IAstTypeParam typeParam = A.TypeParam(typeArg, constraint);
    Types["$" + typeArg] = typeParam;

    IAstObject<TObjField> type = A.Obj<TObjField>(Kind, name, typeArg, true);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_ArgParamParent_ReturnsTrue(string name, string constraint, string typeArg, string parent)
  {
    this.SkipEqual(name, constraint);

    IAstObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent, constraint);
    Types["$" + typeArg] = parentType;

    IAstObject<TObjField> type = A.Obj<TObjField>(Kind, name, typeArg, true);

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Object_Matches_GrandParent_ReturnsTrue(string name, string parent, string constraint)
  {
    this.SkipEqual(name, parent);

    IAstObject<TObjField> type = A.Obj<TObjField>(Kind, name, parent);

    IAstObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent, constraint);
    Types[parent] = parentType;

    bool result = Sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

public class DualObjectParentMatcherTests
  : ObjectParentMatcherTests<IAstDualField>
{
  public DualObjectParentMatcherTests()
    : base(TypeKind.Dual)
    => Sut = new(MatcherRepo);

  internal override ObjectParentMatcher<IAstDualField> Sut { get; }
}
