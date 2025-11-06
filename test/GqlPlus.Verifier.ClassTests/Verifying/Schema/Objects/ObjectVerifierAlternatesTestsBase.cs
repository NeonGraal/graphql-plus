using GqlPlus.Building;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectVerifierAlternatesTestsBase<TObjField>(
  TypeKind kind
) : ObjectVerifierTestsBase<TObjField>(kind)
  where TObjField : class, IGqlpObjField
{
  [Fact]
  public void Verify_WithAlternate_ReturnsNoErrors()
  {
    Define(A.DomainString("String"));

    TheBuilder.WithAlternate("String");

    Verify_NoErrors();
  }

  [Theory, RepeatClassData<CollectionsTestData>]
  public void Verify_WithAlternateModifier_ReturnsNoErrors(ModifierKind kind)
  {
    Define(A.DomainString("String"));

    TheBuilder.WithAlternate("String", a => a.WithModifier(kind, "String"));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateSame_ReturnsErrors(string name)
  {
    TheBuilder.WithAlternate(name);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatClassData<CollectionsTestData>]
  public void Verify_WithAlternateSameModifier_ReturnsErrors(ModifierKind kind, string name)
  {
    Define(A.DomainString("String"));

    TheBuilder.WithAlternate(name, a => a.WithModifier(kind, "String"));

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateRecurse_ReturnsNoErrors(string altType)
  {
    Define(A.DomainString("String"));

    DefineObject(altType, o => o.WithAlternate("String"));

    TheBuilder.WithAlternate(altType);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateSameRecurse_ReturnsErrors(string name, string altType)
  {
    DefineObject(altType, o => o.WithAlternate(name));

    TheBuilder.WithAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatClassData<CollectionsTestData>]

  public void Verify_WithAlternateSameRecurseModifier_ReturnsErrors(ModifierKind kind, string name, string altType)
  {
    Define(A.DomainString("String"));

    DefineObject(altType, o => o.WithAlternate(name, a => a.WithModifier(kind, "String")));

    TheBuilder.WithAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateParentSame_ReturnsErrors(string name, string altType)
  {
    DefineObject(altType, o => o.WithParent(name));

    TheBuilder.WithAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatClassData<CollectionsTestData>]
  public void Verify_WithAlternateParentSameModifier_ReturnsErrors(ModifierKind kind, string name, string altType)
  {
    Define(A.DomainString("String"));

    DefineObject(altType, o => o.WithParent(name));

    TheBuilder.WithAlternate(altType, a => a.WithModifier(kind, "String"));

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateSimpleArg_ReturnsErrors(string argType)
  {
    Define(A.DomainString("String"));

    TheBuilder.WithAlternate("String", a => a.WithArg(argType));

    Verify_Errors("Expected none, given 1");
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateNoArg_ReturnsError(string altType, string paramName, string argType)
  {
    this.SkipEqual(argType, altType);

    Define<IGqlpSimple>(argType);

    DefineObject(altType, o => o
      .WithTypeParam(paramName, argType)
      .WithParent(paramName, p => p.IsTypeParam()));

    TheBuilder.WithAlternate(altType);

    Verify_Errors("Expected 1, given 0");
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateParentAlternate_ReturnsNoErrors(string parentName, string altType)
  {
    this.SkipEqual(parentName, altType);

    Define(A.DomainString("String"));

    DefineObject(parentName, o => o.WithAlternate("String"));

    DefineObject(altType, o => o.WithParent(parentName));

    TheBuilder.WithAlternate(altType);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateParentAlternateCantMerge_ReturnsErrors(string parentName, string altType)
  {
    this.SkipEqual(parentName, altType);

    Define(A.DomainString("String"));

    DefineObject(parentName, o => o.WithAlternate("String"));

    DefineObject(altType, o => o.WithParent(parentName));

    TheBuilder.WithAlternate(altType);

    MergeAlternates.CanMergeReturns("Merge fails".MakeMessages());

    Verify_Errors("Can't merge");
  }

  [Theory, RepeatData]
  public void Verify_WithParentAlternate_ReturnsNoErrors(string parentName)
  {
    Define(A.DomainString("String"));

    DefineObject(parentName, o => o.WithAlternate("String"));
    // AddTypes(parent);

    TheBuilder.WithParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateEnum_ReturnsNoErrors(string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    TheBuilder.WithAlternate(enumType, a => a.WithObjEnum(enumLabel));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateEnumLabel_ReturnsNoErrors(string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    TheBuilder.WithAlternate("", a => a.WithObjEnum(enumLabel));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateEnumUndefined_ReturnsErrors(string enumType, string enumLabel)
  {
    TheBuilder.WithAlternate(enumType, a => a.WithObjEnum(enumLabel));

    Verify_Errors("not an Enum");
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateEnumWrongLabel_ReturnsErrors(string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, ["bad" + enumLabel]));

    TheBuilder.WithAlternate(enumType, a => a.WithObjEnum(enumLabel));

    Verify_Errors("not a Label");
  }
}

public class CollectionsTestData
  : TheoryData<ModifierKind>
{
  public CollectionsTestData()
  {
    Add(ModifierKind.List);
    Add(ModifierKind.Dict);
  }
}
