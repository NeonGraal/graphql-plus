using GqlPlus.Building;
using GqlPlus.Building.Schema;
using GqlPlus.Building.Schema.Objects;
using GqlPlus.Matching;

namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectVerifierTestsBase<TObject, TField>
  : UsageVerifierTestsBase<TObject>
  where TObject : class, IGqlpObject<TField>
  where TField : class, IGqlpObjField
{
  internal readonly ForM<TField> MergeFields = new();
  internal readonly ForM<IGqlpAlternate> MergeAlternates = new();
  protected TypeKind Kind { get; }

  protected ObjectVerifierTestsBase(TypeKind kind)
  {
    Kind = kind;

    ArgMatcher = A.Of<Matcher<IGqlpTypeArg>.I>();

    ArgDelegate = A.Of<Matcher<IGqlpTypeArg>.D>();
    ArgDelegate().Returns(ArgMatcher);

    TheBuilder = new(kind.ToString(), kind);
  }

  protected Matcher<IGqlpTypeArg>.I ArgMatcher { get; }
  protected Matcher<IGqlpTypeArg>.D ArgDelegate { get; }

  protected sealed override TObject TheUsage => TheObject;

  protected ObjectBuilder<TObject, TField> TheBuilder { get; }
  protected TObject TheObject => _theObject ??= TheBuilder.AsObject;
  private TObject? _theObject;

  [Fact]
  public void Verify_CallsMergeFieldsAndAlternates_WithoutErrors()
  {
    Verifier.Verify(UsageAliased, Errors);

    Verifier.ShouldSatisfyAllConditions(
      MergeFields.NotCalled,
      MergeAlternates.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_WithBasic_ReturnsNoErrors()
    => Verify_NoErrors();

  [Theory, RepeatData]
  public void Verify_WithField_ReturnsNoErrors(string fieldName)
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectField(TheBuilder, fieldName, "String");

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithSameField_ReturnsErrors(string fieldName, string name)
  {
    ObjectField(TheBuilder, fieldName, name);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatClassData<ModifersTestData>]

  public void Verify_WithSameFieldModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName)
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectField(TheBuilder, fieldName, name, f => f.WithModifier(kind, "String"));

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithSameFieldRecurse_ReturnsErrors(string fieldName, string name, string typeName)
  {
    this.SkipEqual(typeName, name);

    DefineObject(typeName, o => ObjectField(o, fieldName, name));

    ObjectField(TheBuilder, fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatClassData<ModifersTestData>]

  public void Verify_WithSameFieldRecurseModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName, string typeName)
  {
    this.SkipEqual(typeName, name);

    Define<IGqlpTypeSpecial>("String");

    DefineObject(typeName, o =>
      ObjectField(o, fieldName, name, f => f
        .WithModifier(kind, "String")));

    ObjectField(TheBuilder, fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithSameFieldParent_ReturnsErrors(string fieldName, string name, string typeName)
  {
    this.SkipEqual(typeName, name);

    DefineObject(typeName, o => o.WithParent(name));

    ObjectField(TheBuilder, fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatClassData<ModifersTestData>]

  public void Verify_WithSameFieldParentModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName, string typeName)
  {
    this.SkipEqual(typeName, name);

    Define<IGqlpTypeSpecial>("String");

    DefineObject(typeName, o => o.WithParent(name));

    ObjectField(TheBuilder, fieldName, typeName, f => f.WithModifier(kind, "String"));

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithFieldParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>(constraint);

    TheBuilder.WithTypeParam(paramName, constraint);

    ObjectField(TheBuilder, fieldName, paramName, f => f.WithType(t => t.IsTypeParam()));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldKeyParam_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define<IGqlpTypeSpecial>("String");

    TheBuilder.WithTypeParam(paramName, "String");

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Param, paramName));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDict_ReturnsNoErrors(string fieldName, string key)
  {
    Define<IGqlpTypeSpecial>("String", key);

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Dict, key));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictUndefined_ReturnsError(string fieldName, string key)
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Dict, key));

    Verify_Errors("not defined");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>("String", constraint);

    TheBuilder.WithTypeParam(paramName, constraint);

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Param, paramName));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictParamUndefined_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Param, paramName));

    Verify_Errors("not defined");
  }

  [Fact]
  public void Verify_WithAlternate_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    TheBuilder.WithAlternate("String");

    Verify_NoErrors();
  }

  [Theory, RepeatClassData<CollectionsTestData>]
  public void Verify_WithAlternateModifier_ReturnsNoErrors(ModifierKind kind)
  {
    Define<IGqlpTypeSpecial>("String");

    TheBuilder.WithAlternate("String", a => a.WithModifier(kind, "String"));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithSameAlternate_ReturnsErrors(string name)
  {
    TheBuilder.WithAlternate(name);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatClassData<CollectionsTestData>]
  public void Verify_WithSameAlternateModifier_ReturnsErrors(ModifierKind kind, string name)
  {
    Define<IGqlpTypeSpecial>("String");

    TheBuilder.WithAlternate(name, a => a.WithModifier(kind, "String"));

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateRecurse_ReturnsNoErrors(string altType)
  {
    Define<IGqlpTypeSpecial>("String");

    DefineObject(altType, o => o.WithAlternate("String"));

    TheBuilder.WithAlternate(altType);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithSameAlternateRecurse_ReturnsErrors(string name, string altType)
  {
    DefineObject(altType, o => o.WithAlternate(name));

    TheBuilder.WithAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatClassData<CollectionsTestData>]

  public void Verify_WithSameAlternateRecurseModifier_ReturnsErrors(ModifierKind kind, string name, string altType)
  {
    Define<IGqlpTypeSpecial>("String");

    DefineObject(altType, o => o.WithAlternate(name, a => a.WithModifier(kind, "String")));

    TheBuilder.WithAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithSameAlternateParent_ReturnsErrors(string name, string altType)
  {
    DefineObject(altType, o => o.WithParent(name));

    TheBuilder.WithAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatClassData<ModifersTestData>]
  public void Verify_WithSameAlternateParentModifier_ReturnsErrors(ModifierKind kind, string name, string altType)
  {
    Define<IGqlpTypeSpecial>("String");

    DefineObject(altType, o => o.WithParent(name));

    TheBuilder.WithAlternate(altType, a => a.WithModifier(kind, "String"));

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateSimpleArg_ReturnsErrors(string argType)
  {
    Define<IGqlpTypeSpecial>("String");

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

    Define<IGqlpTypeSpecial>("String");

    DefineObject(parentName, o => o.WithAlternate("String"));

    DefineObject(altType, o => o.WithParent(parentName));

    TheBuilder.WithAlternate(altType);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateParentAlternateCantMerge_ReturnsErrors(string parentName, string altType)
  {
    this.SkipEqual(parentName, altType);

    Define<IGqlpTypeSpecial>("String");

    DefineObject(parentName, o => o.WithAlternate("String"));

    DefineObject(altType, o => o.WithParent(parentName));

    TheBuilder.WithAlternate(altType);

    MergeAlternates.CanMergeReturns("Merge fails".MakeMessages());

    Verify_Errors("Can't merge");
  }

  [Theory, RepeatData]
  public void Verify_WithParent_ReturnsNoErrors(string parentName)
  {
    DefineObject(parentName);

    TheBuilder.WithParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithSameParent_ReturnsErrors(string name)
  {
    TheBuilder.WithParent(name);

    Verify_Errors("cannot be a child of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithSameParentRecurse_ReturnsErrors(string name, string parentName)
  {
    this.SkipEqual(parentName, name);

    DefineObject(parentName, o => o.WithParent(name));

    TheBuilder.WithParent(parentName);

    Verify_Errors("cannot be a child of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithWrongParamParent_ReturnsErrors(string parentName, string paramName, string constraint)
  {
    this.SkipEqual(parentName, paramName);

    Define<IGqlpTypeSpecial>(constraint);

    TheBuilder
      .WithTypeParam(paramName, constraint)
      .WithParent(parentName, t => t.IsTypeParam())
      .WithAlternate(paramName, a => a.IsTypeParam());

    Verify_Errors("not defined");
  }

  [Theory, RepeatData]
  public void Verify_WithParentField_ReturnsNoErrors(string fieldName, string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    DefineObject(parentName, o => ObjectField(o, fieldName, "String"));

    TheBuilder.WithParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithParentAlternate_ReturnsNoErrors(string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    DefineObject(parentName, o => o.WithAlternate("String"));
    // AddTypes(parent);

    TheBuilder.WithParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithTypeParams_ReturnsNoErrors(string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>(constraint);

    TheBuilder
      .WithTypeParam(paramName, constraint)
      .WithParent(paramName, t => t.IsTypeParam());

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithTypeParamsNoConstraint_ReturnsError(string typeParam)
  {
    TheBuilder.WithTypeParam(typeParam, "");

    TheBuilder.WithParent(typeParam, t => t.IsTypeParam());

    Verify_Errors("not defined");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgGeneric_ReturnsError(string fieldName, string otherName, string paramName, string argType, string argParam)
  {
    this.SkipEqual(argType, argParam)
      .SkipEqual(otherName, argParam)
      .SkipEqual(otherName, paramName);

    Define<IGqlpSimple>(argParam);

    DefineObject(argType, o => o
      .WithTypeParam(argParam, argParam)
      .WithAlternate(argParam, a => a.IsTypeParam()));

    DefineObject(otherName, o => o
      .WithTypeParam(paramName, argType)
      .WithAlternate(paramName, a => a.IsTypeParam()));

    IGqlpTypeArg arg = A.TypeArg(argType).AsTypeArg;
    ObjectField(TheBuilder, fieldName, otherName, f => f.WithType(t => t.WithArgs(arg)));
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("Expected 1, given none");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoParam_ReturnsError(string fieldName, string otherName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    DefineObject(otherName);

    IGqlpTypeArg arg = A.TypeArg(argType).AsTypeArg;
    ObjectField(TheBuilder, fieldName, otherName, f => f.WithType(t => t.WithArgs(arg)));
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("Expected 0, given 1");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoConstraint_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    DefineObject(otherName, o => o
      .WithTypeParam(paramName, "")
      .WithParent(paramName, p => p.IsTypeParam()));

    IGqlpTypeArg arg = A.TypeArg(argType).AsTypeArg;
    ObjectField(TheBuilder, fieldName, otherName, f => f.WithType(t => t.WithArgs(arg)));
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("undefined");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoMatch_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    DefineObject(otherName, o => o
      .WithTypeParam(paramName, argType)
      .WithParent(paramName, p => p.IsTypeParam()));

    IGqlpTypeArg arg = A.TypeArg(argType).AsTypeArg;
    ObjectField(TheBuilder, fieldName, otherName, f => f.WithType(t => t.WithArgs(arg)));
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(false);

    Verify_Errors("not match");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnum_ReturnsNoErrors(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    ObjectField(TheBuilder, fieldName, enumType, f => f.WithObjEnum(enumLabel));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumLabel_ReturnsNoErrors(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    ObjectField(TheBuilder, fieldName, "", f => f.WithObjEnum(enumLabel));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumUndefined_ReturnsError(string fieldName, string enumType, string enumLabel)
  {
    ObjectField(TheBuilder, fieldName, enumType, f => f.WithObjEnum(enumLabel));

    Verify_Errors("not an Enum");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumWrongLabel_ReturnsError(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, ["bad" + enumLabel]));

    ObjectField(TheBuilder, fieldName, enumType, f => f.WithObjEnum(enumLabel));

    Verify_Errors("not a Label");
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

  [Theory, RepeatData]
  public void Verify_WithEnumTypeArg_ReturnsNoErrors(string fieldName, string enumType, string enumLabel, string argName, string typeName)
  {
    this.SkipEqual(typeName, enumType).SkipEqual(typeName, enumLabel).SkipEqual(enumType, enumLabel);

    AddTypes(A.Enum(enumType, [enumLabel]));

    DefineObject(typeName, o => o
      .WithTypeParam(argName, enumType)
      .WithParent(argName, p => p.IsTypeParam()));

    IGqlpTypeArg arg = A.TypeArg("").WithObjEnum(enumLabel).AsTypeArg;
    ObjectField(TheBuilder, fieldName, typeName, f => f
      .WithType(t => t.WithArgs(arg)));

    ArgMatcher.Matches(arg, enumType, Arg.Any<EnumContext>()).Returns(true);

    Verify_NoErrors();
  }

  protected void Verify_NoErrors()
  {
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  protected void Verify_Errors(string message, string name = "")
  {
    TheObject.Name.Returns(name.IfWhiteSpace("Object"));
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldSatisfyAllConditions(
      e => e.ShouldNotBeEmpty(),
      e => e.ShouldContain(m => m.Message.Contains(message), string.Join('\n', Errors.Select(m => " - " + m.Message))));
  }

  protected void DefineObject(string name, Action<ObjectBuilder<TObject, TField>>? config = null)
  {
    ObjectBuilder<TObject, TField> builder = A.Obj<TObject, TField>(Kind, name);
    config?.Invoke(builder);
    TObject obj = builder.AsObject;
    Definitions.Add(obj);
    Usages.Add(obj);
  }

  protected void ObjectField(ObjectBuilder<TObject, TField> builder, string fieldName, string fieldType, Action<ObjFieldBuilder<TField>>? config = null)
    => builder.WithObjFields(A.ObjField<TField>(fieldName, fieldType).FluentAction(config).AsObjField);
}

public class ModifersTestData
  : CollectionsTestData
{
  public ModifersTestData()
  {
    Add(ModifierKind.Opt);
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
