using System.Diagnostics.CodeAnalysis;
using GqlPlus.Matching;
using NSubstitute.Core;

namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectVerifierTestsBase<TObject, TField>
  : UsageVerifierTestsBase<TObject>
  where TObject : class, IGqlpObject<TField>
  where TField : class, IGqlpObjField
{
  internal readonly ForM<TField> MergeFields = new();
  internal readonly ForM<IGqlpObjAlt> MergeAlternates = new();
  protected TypeKind Kind { get; }

  protected ObjectVerifierTestsBase(TypeKind kind)
  {
    Kind = kind;

    ArgMatcher = A.Of<Matcher<IGqlpObjTypeArg>.I>();

    ArgDelegate = A.Of<Matcher<IGqlpObjTypeArg>.D>();
    ArgDelegate().Returns(ArgMatcher);
  }

  protected Matcher<IGqlpObjTypeArg>.I ArgMatcher { get; }
  protected Matcher<IGqlpObjTypeArg>.D ArgDelegate { get; }

  protected sealed override TObject TheUsage => TheObject;

  protected abstract TObject TheObject { get; }

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

    ObjectField(fieldName, "String");

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithSameField_ReturnsErrors(string fieldName, string name)
  {
    ObjectField(fieldName, name);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatInlineData(ModifierKind.Opt), RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithSameFieldModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = ObjectField(fieldName, name);
    SetModifier(field, kind, "String");

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithSameFieldRecurse_ReturnsErrors(string fieldName, string name, string typeName)
  {
    this.SkipEqual(typeName, name);

    TObject fieldType = DefineObject(typeName);
    ObjectField(fieldName, name, fieldType);

    ObjectField(fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatInlineData(ModifierKind.Opt), RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithSameFieldRecurseModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName, string typeName)
  {
    this.SkipEqual(typeName, name);

    Define<IGqlpTypeSpecial>("String");

    TObject fieldType = DefineObject(typeName);
    TField field = ObjectField(fieldName, name, fieldType);
    SetModifier(field, kind, "String");

    ObjectField(fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithSameFieldParent_ReturnsErrors(string fieldName, string name, string typeName)
  {
    this.SkipEqual(typeName, name);

    TObject fieldType = DefineObject(typeName);
    ObjectParent(name, fieldType);

    ObjectField(fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatInlineData(ModifierKind.Opt), RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithSameFieldParentModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName, string typeName)
  {
    this.SkipEqual(typeName, name);

    Define<IGqlpTypeSpecial>("String");

    TObject fieldType = DefineObject(typeName);
    ObjectParent(name, fieldType);

    TField field = ObjectField(fieldName, typeName);
    SetModifier(field, kind, "String");

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithFieldParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>(constraint);

    ObjectParam(paramName, constraint);

    TField field = ObjectField(fieldName, paramName, isTypeParam: true);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldKeyParam_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectParam(paramName, "String");

    TField field = ObjectField(fieldName, "String");
    SetModifier(field, ModifierKind.Param, paramName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDict_ReturnsNoErrors(string fieldName, string key)
  {
    Define<IGqlpTypeSpecial>("String", key);

    TField field = ObjectField(fieldName, "String");
    SetModifier(field, ModifierKind.Dict, key);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictUndefined_ReturnsError(string fieldName, string key)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = ObjectField(fieldName, "String");
    SetModifier(field, ModifierKind.Dict, key);

    Verify_Errors("not defined");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>("String", constraint);

    ObjectParam(paramName, constraint);

    TField field = ObjectField(fieldName, "String");
    SetModifier(field, ModifierKind.Param, paramName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictParamUndefined_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = ObjectField(fieldName, "String");
    SetModifier(field, ModifierKind.Param, paramName);

    Verify_Errors("not defined");
  }

  [Fact]
  public void Verify_WithAlternate_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectAlternate("String");

    Verify_NoErrors();
  }

  [Theory, RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithAlternateModifier_ReturnsNoErrors(ModifierKind kind)
  {
    Define<IGqlpTypeSpecial>("String");

    IGqlpObjAlt alt = ObjectAlternate("String");
    SetModifier(alt, kind, "String");

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithSameAlternate_ReturnsErrors(string name)
  {
    ObjectAlternate(name);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithSameAlternateModifier_ReturnsErrors(ModifierKind kind, string name)
  {
    Define<IGqlpTypeSpecial>("String");

    IGqlpObjAlt alt = ObjectAlternate(name);
    SetModifier(alt, kind, "String");

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateRecurse_ReturnsNoErrors(string altType)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject other = DefineObject(altType);
    ObjectAlternate("String", other);

    ObjectAlternate(altType);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithSameAlternateRecurse_ReturnsErrors(string name, string altType)
  {
    TObject other = DefineObject(altType);
    ObjectAlternate(name, other);

    ObjectAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithSameAlternateRecurseModifier_ReturnsErrors(ModifierKind kind, string name, string altType)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject other = DefineObject(altType);
    IGqlpObjAlt alt = ObjectAlternate(name, other);
    SetModifier(alt, kind, "String");

    ObjectAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithSameAlternateParent_ReturnsErrors(string name, string altType)
  {
    TObject other = DefineObject(altType);
    ObjectParent(name, other);

    ObjectAlternate(altType);

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatInlineData(ModifierKind.Opt), RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithSameAlternateParentModifier_ReturnsErrors(ModifierKind kind, string name, string altType)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject other = DefineObject(altType);
    ObjectParent(name, other);

    IGqlpObjAlt alt = ObjectAlternate(altType);
    SetModifier(alt, kind, "String");

    Verify_Errors("cannot be an alternate of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateSimpleArg_ReturnsErrors(string argType)
  {
    Define<IGqlpTypeSpecial>("String");

    BaseArg(ObjectAlternate("String"), argType);

    Verify_Errors("Expected none, given 1");
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateNoArg_ReturnsError(string altType, string paramName, string argType)
  {
    this.SkipEqual(argType, altType);

    Define<IGqlpSimple>(argType);

    TObject other = DefineObject(altType, paramName, true);
    ObjectParam(paramName, argType, other);

    ObjectAlternate(altType);

    Verify_Errors("Expected 1, given 0");
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateParentAlternate_ReturnsNoErrors(string parentName, string altType)
  {
    this.SkipEqual(parentName, altType);

    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = DefineObject(parentName);
    ObjectAlternate("String", parentObject);

    DefineObject(altType, parentName);

    ObjectAlternate(altType);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateParentAlternateCantMerge_ReturnsErrors(string parentName, string altType)
  {
    this.SkipEqual(parentName, altType);

    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = DefineObject(parentName);
    ObjectAlternate("String", parentObject);

    DefineObject(altType, parentName);

    ObjectAlternate(altType);

    MergeAlternates.CanMergeReturns("Merge fails".MakeMessages());

    Verify_Errors("Can't merge");
  }

  [Theory, RepeatData]
  public void Verify_WithParent_ReturnsNoErrors(string parentName)
  {
    DefineObject(parentName);

    ObjectParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithSameParent_ReturnsErrors(string name)
  {
    ObjectParent(name);

    Verify_Errors("cannot be a child of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithSameParentRecurse_ReturnsErrors(string name, string parentName)
  {
    this.SkipEqual(parentName, name);

    DefineObject(parentName, name);

    ObjectParent(parentName);

    Verify_Errors("cannot be a child of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithWrongParamParent_ReturnsErrors(string parentName, string paramName, string constraint)
  {
    this.SkipEqual(parentName, paramName);

    Define<IGqlpTypeSpecial>(constraint);

    ObjectParam(paramName, constraint);
    ObjectAlternate(paramName, isTypeParam: true);

    ObjectParent(parentName, isTypeParam: true);

    Verify_Errors("not defined");
  }

  [Theory, RepeatData]
  public void Verify_WithParentField_ReturnsNoErrors(string fieldName, string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject parent = DefineObject(parentName);
    ObjectField(fieldName, "String", parent);

    ObjectParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithParentAlternate_ReturnsNoErrors(string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject parent = DefineObject(parentName);
    AddTypes(parent);
    ObjectAlternate("String", parent);

    ObjectParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithTypeParams_ReturnsNoErrors(string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>(constraint);

    ObjectParam(paramName, constraint);

    ObjectParent(paramName, isTypeParam: true);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithTypeParamsNoConstraint_ReturnsError(string typeParam)
  {
    ObjectParam(typeParam, "");

    ObjectParent(typeParam, isTypeParam: true);

    Verify_Errors("not defined");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgGeneric_ReturnsError(string fieldName, string otherName, string paramName, string argType, string argParam)
  {
    this.SkipEqual(argType, argParam)
      .SkipEqual(otherName, argParam)
      .SkipEqual(otherName, paramName);

    Define<IGqlpSimple>(argParam);

    TObject otherArg = DefineObject(argType);
    ObjectParam(argParam, argParam, otherArg);
    ObjectAlternate(argParam, otherArg, true);

    TObject other = DefineObject(otherName);
    ObjectParam(paramName, argType, other);
    ObjectAlternate(paramName, other, true);

    IGqlpObjTypeArg arg = FieldArg(ObjectField(fieldName, otherName), argType);
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("Expected 1, given none");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoParam_ReturnsError(string fieldName, string otherName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    TObject other = DefineObject(otherName);

    IGqlpObjTypeArg arg = FieldArg(ObjectField(fieldName, otherName), argType);
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("Expected 0, given 1");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoConstraint_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    TObject other = DefineObject(otherName, paramName, true);
    ObjectParam(paramName, "", other);

    IGqlpObjTypeArg arg = FieldArg(ObjectField(fieldName, otherName), argType);
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("undefined");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoMatch_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    TObject other = DefineObject(otherName, paramName, true);
    ObjectParam(paramName, argType, other);

    IGqlpObjTypeArg arg = FieldArg(ObjectField(fieldName, otherName), argType);
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(false);

    Verify_Errors("not match");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnum_ReturnsNoErrors(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    ObjectFieldEnum(fieldName, enumType, enumLabel);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumLabel_ReturnsNoErrors(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    TField field = ObjectField(fieldName, "");
    IGqlpEnumValue enumValue = A.EnumValue("", enumLabel);
    field.EnumValue.Returns(enumValue);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumUndefined_ReturnsError(string fieldName, string enumType, string enumLabel)
  {
    ObjectFieldEnum(fieldName, enumType, enumLabel);

    Verify_Errors("not an Enum");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumWrongLabel_ReturnsError(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, ["bad" + enumLabel]));

    ObjectFieldEnum(fieldName, enumType, enumLabel);

    Verify_Errors("not a Label");
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateEnum_ReturnsNoErrors(string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    ObjectAltEnum(enumType, enumLabel);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateEnumLabel_ReturnsNoErrors(string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    ObjectAltEnum("", enumLabel);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateEnumUndefined_ReturnsErrors(string enumType, string enumLabel)
  {
    ObjectAltEnum(enumType, enumLabel);

    Verify_Errors("not an Enum");
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateEnumWrongLabel_ReturnsErrors(string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, ["bad" + enumLabel]));

    ObjectAltEnum(enumType, enumLabel);

    Verify_Errors("not a Label");
  }

  [Theory, RepeatData]
  public void Verify_WithEnumTypeArg_ReturnsNoErrors(string fieldName, string enumType, string enumLabel, string argName, string typeName)
  {
    this.SkipEqual(typeName, enumType).SkipEqual(typeName, enumLabel).SkipEqual(enumType, enumLabel);

    AddTypes(A.Enum(enumType, [enumLabel]));

    TObject other = DefineObject(typeName, argName, isTypeParam: true);
    ObjectParam(argName, enumType, other);

    TField field = ObjectField(fieldName, typeName);
    IGqlpObjTypeArg arg = FieldEnumArg(field, "", enumLabel);
    arg.WhenForAnyArgs(a => a.SetEnumType(""))
      .Do(HandleSetEnumType);

    ArgMatcher.Matches(arg, enumType, Arg.Any<EnumContext>()).Returns(true);

    Verify_NoErrors();

    void HandleSetEnumType(CallInfo c)
    {
      IGqlpEnumValue enumValue = A.EnumValue(enumType, enumLabel);
      arg.EnumValue.Returns(enumValue);
      arg.Name.Returns(enumType);
    }
  }

  protected void Verify_NoErrors(string name = "")
  {
    TheObject.Name.Returns(name.IfWhiteSpace("Object"));
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

  protected TObject DefineObject(string name, string parent = "", bool isTypeParam = false)
  {
    TObject obj = A.Obj<TObject>(Kind, name, parent, isTypeParam);
    Definitions.Add(obj);
    Usages.Add(obj);
    return obj;
  }

  protected IGqlpObjBase ObjectParent(string parentName, TObject? obj = null, bool isTypeParam = false)
  {
    obj ??= TheObject;

    IGqlpObjBase parentBase = A.ObjBase(parentName, isTypeParam);
    obj.SetParent(parentBase);

    return parentBase;
  }

  protected IGqlpObjAlt ObjectAlternate(string type, TObject? obj = null, bool isTypeParam = false)
  {
    obj ??= TheObject;

    IGqlpObjAlt alt = A.Named<IGqlpObjAlt, IGqlpObjAlt>(type);
    string fullType = isTypeParam ? "$" + type : type;
    alt.FullType.Returns(fullType);
    alt.IsTypeParam.Returns(isTypeParam);
    alt.EnumValue.Returns((IGqlpEnumValue?)null);

    obj.Alternates.Returns([alt]);

    return alt;
  }

  protected IGqlpObjAlt ObjectAltEnum(string enumType, string enumLabel, TObject? obj = null)
  {
    obj ??= TheObject;

    IGqlpObjAlt alt = A.Named<IGqlpObjAlt, IGqlpObjAlt>(enumType);
    alt.FullType.Returns(enumType);
    IGqlpEnumValue enumValue = A.EnumValue(enumType, enumLabel);
    alt.EnumValue.Returns(enumValue);

    obj.Alternates.Returns([alt]);

    return alt;
  }

  protected TField ObjectField(string fieldName, string fieldType, TObject? obj = null, bool isTypeParam = false)
  {
    obj ??= TheObject;

    IGqlpObjBase objBase = A.ObjBase(fieldType, isTypeParam);
    TField field = A.ObjField<TField>(fieldName, objBase);

    obj.Fields.Returns([field]);
    obj.ObjFields.Returns([field]);

    return field;
  }

  protected TField ObjectFieldEnum(string fieldName, string enumType, string enumLabel, TObject? obj = null)
  {
    obj ??= TheObject;

    TField field = A.ObjField<TField>(fieldName, enumType);
    IGqlpEnumValue enumValue = A.EnumValue(enumType, enumLabel);
    field.EnumValue.Returns(enumValue);

    obj.Fields.Returns([field]);
    obj.ObjFields.Returns([field]);

    return field;
  }

  protected IGqlpTypeParam ObjectParam(string paramName, string constraint, TObject? obj = null)
  {
    obj ??= TheObject;

    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    obj.TypeParams.Returns([typeParam]);

    return typeParam;
  }

  protected static IGqlpObjTypeArg BaseArg(IGqlpObjBase type, string argName, bool isTypeParam = false)
  {
    IGqlpObjTypeArg arg = A.ObjTypeArg(argName, isTypeParam);
    type.SetArgs(arg);
    return arg;
  }
  protected static IGqlpObjTypeArg BaseEnumArg(IGqlpObjBase type, string enumType, string enumLabel)
  {
    IGqlpObjType enumObjType = A.Named<IGqlpObjType>(enumType);

    IGqlpObjTypeArg arg = A.ObjTypeArg(enumType);
    arg.FullType.Returns(enumType);
    IGqlpEnumValue enumValue = A.EnumValue(enumType, enumLabel);
    arg.EnumValue.Returns(enumValue);

    type.SetArgs(arg);
    return arg;
  }

  protected static IGqlpObjTypeArg FieldArg([NotNull] TField field, string argName, bool isTypeParam = false)
    => BaseArg(field.Type, argName, isTypeParam);
  protected static IGqlpObjTypeArg FieldEnumArg([NotNull] TField field, string enumType, string enumLabel)
    => BaseEnumArg(field.Type, enumType, enumLabel);

  protected static TMod SetModifier<TMod>([NotNull] TMod modified, ModifierKind kind, string key = "")
    where TMod : IGqlpModifiers
  {
    IGqlpModifier modifier = A.Modifier(kind, key);
    modified.Modifiers.Returns([modifier]);
    return modified;
  }
}
