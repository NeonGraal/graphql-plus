using GqlPlus.Matching;

namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectVerifierTestsBase<TObject, TBase, TField, TAlt, TArg>
  : UsageVerifierTestsBase<TObject>
  where TObject : class, IGqlpObject<TBase, TField, TAlt>
  where TBase : class, IGqlpObjBase<TArg>
  where TField : class, IGqlpObjField<TBase>
  where TAlt : class, IGqlpObjAlternate<TArg>
  where TArg : class, IGqlpObjArg
{
  internal readonly ForM<TField> MergeFields = new();
  internal readonly ForM<TAlt> MergeAlternates = new();

  protected ObjectVerifierTestsBase()
  {
    ArgMatcher = A.Of<Matcher<TArg>.I>();

    ArgDelegate = A.Of<Matcher<TArg>.D>();
    ArgDelegate().Returns(ArgMatcher);
  }

  protected Matcher<TArg>.I ArgMatcher { get; }
  protected Matcher<TArg>.D ArgDelegate { get; }

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
  {
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithField_ReturnsNoErrors(string fieldName)
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectField(fieldName, "String");

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithSameField_ReturnsErrors(string fieldName, string name)
  {
    TField field = ObjectField(fieldName, name);
    TheObject.Name.Returns(name);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithSameFieldRecurse_ReturnsErrors(string fieldName, string name, string fieldType)
  {
    this.SkipEqual(fieldType, name);

    TObject parentType = DefineObject(fieldType);
    ObjectField(fieldName, name, parentType);

    ObjectField(fieldName, fieldType);
    TheObject.Name.Returns(name);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatInlineData(ModifierKind.Opt), RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithSameFieldModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = ObjectField(fieldName, name);
    IGqlpModifier modifier = A.Modifier(kind, "String");
    field.Modifiers.Returns([modifier]);

    TheObject.Name.Returns(name);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatInlineData(ModifierKind.Opt), RepeatInlineData(ModifierKind.List), RepeatInlineData(ModifierKind.Dict)]
  public void Verify_WithSameFieldRecurseModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName, string fieldType)
  {
    this.SkipEqual(fieldType, name);

    Define<IGqlpTypeSpecial>("String");

    TObject parentType = DefineObject(fieldType);
    TField field = ObjectField(fieldName, name, parentType);
    IGqlpModifier modifier = A.Modifier(kind, "String");
    field.Modifiers.Returns([modifier]);

    ObjectField(fieldName, fieldType);
    TheObject.Name.Returns(name);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>(constraint);

    ObjectParam(TheObject, paramName, constraint);

    TBase objBase = A.ObjBase<TBase, TArg>(paramName, true);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase);
    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldKeyParam_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectParam(TheObject, paramName, "String");

    TField field = ObjectField(fieldName, "String");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Param, paramName);
    field.Modifiers.Returns([modifier]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDict_ReturnsNoErrors(string fieldName, string key)
  {
    Define<IGqlpTypeSpecial>("String", key);

    TField field = ObjectField(fieldName, "String");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Dict, key);
    field.Modifiers.Returns([modifier]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictUndefined_ReturnsError(string fieldName, string key)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = ObjectField(fieldName, "String");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Dict, key);
    field.Modifiers.Returns([modifier]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>("String", constraint);

    ObjectParam(TheObject, paramName, constraint);

    TField field = ObjectField(fieldName, "String");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Param, paramName);
    field.Modifiers.Returns([modifier]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictParamUndefined_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = ObjectField(fieldName, "String");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Param, paramName);
    field.Modifiers.Returns([modifier]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_WithAlternate_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    ObjectAlternate("String");
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateAlternate_ReturnsNoErrors(string altType)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject other = DefineObject(altType);
    ObjectAlternate("String", other);

    ObjectAlternate(altType);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateSimpleArg_ReturnsErrors(string argType)
  {
    Define<IGqlpTypeSpecial>("String");

    TArg arg = A.Named<TArg>(argType);
    ObjectAlternate("String").SetArgs(arg);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateNoArg_ReturnsError(string altType, string paramName, string argType)
  {
    this.SkipEqual(argType, altType);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(altType, paramName, true);
    ObjectParam(other, paramName, argType);

    ObjectAlternate(altType);
    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateParentAlternate_ReturnsNoErrors(string parentName, string altType)
  {
    this.SkipEqual(parentName, altType);

    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = A.Obj<TObject, TBase>(parentName);
    ObjectAlternate("String", parentObject);
    Usages.Add(parentObject);
    Definitions.Add(parentObject);

    TObject altObject = A.Obj<TObject, TBase>(altType, parentName);
    Usages.Add(altObject);
    Definitions.Add(altObject);

    ObjectAlternate(altType);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithAlternateParentAlternateCantMerge_ReturnsErrors(string parentName, string altType)
  {
    this.SkipEqual(parentName, altType);

    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = A.Obj<TObject, TBase>(parentName);
    ObjectAlternate("String", parentObject);
    Usages.Add(parentObject);
    Definitions.Add(parentObject);

    TObject altObject = A.Obj<TObject, TBase>(altType, parentName);
    Usages.Add(altObject);
    Definitions.Add(altObject);

    ObjectAlternate(altType);
    Usages.Add(TheObject);

    MergeAlternates.CanMergeReturns("Merge fails".MakeMessages());

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithParent_ReturnsNoErrors(string parentName)
  {
    TObject parentType = A.Obj<TObject, TBase>(parentName);
    Usages.Add(parentType);
    Definitions.Add(parentType);

    TBase parentBase = A.ObjBase<TBase, TArg>(parentName);
    TheObject.SetParent(parentBase);
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithSameParent_ReturnsErrors(string name)
  {
    TObject parentType = A.Obj<TObject, TBase>(name);
    Usages.Add(parentType);
    Definitions.Add(parentType);

    TBase parentBase = A.ObjBase<TBase, TArg>(name);
    TheObject.SetParent(parentBase);
    TheObject.Name.Returns(name);
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithSameParentRecurse_ReturnsErrors(string name, string parentName)
  {
    this.SkipEqual(parentName, name);

    TObject parentType = A.Obj<TObject, TBase>(parentName, name);
    Usages.Add(parentType);
    Definitions.Add(parentType);

    TBase parentBase = A.ObjBase<TBase, TArg>(parentName);
    TheObject.SetParent(parentBase);
    TheObject.Name.Returns(name);
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithWrongParamParent_ReturnsErrors(string parentName, string paramName, string constraint)
  {
    this.SkipEqual(parentName, paramName);

    Define<IGqlpTypeSpecial>(constraint);

    ObjectParam(TheObject, paramName, constraint);

    TBase parentBase = A.ObjBase<TBase, TArg>(parentName, true);
    TheObject.SetParent(parentBase);
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithParentField_ReturnsNoErrors(string fieldName, string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = A.ObjField<TField, TBase>(fieldName, A.ObjBase<TBase, TArg>("String"));

    TObject parent = A.Obj<TObject, TBase>(parentName);
    parent.Fields.Returns([field]);
    parent.ObjFields.Returns([field]);
    Definitions.Add(parent);

    TBase parentBase = A.ObjBase<TBase, TArg>(parentName);
    TheObject.SetParent(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithParentAlternate_ReturnsNoErrors(string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject parent = A.Obj<TObject, TBase>(parentName);
    AddTypes(parent);
    ObjectAlternate("String", parent);
    Definitions.Add(parent);

    TBase parentBase = A.ObjBase<TBase, TArg>(parentName);
    TheObject.SetParent(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithTypeParams_ReturnsNoErrors(string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>(constraint);

    ObjectParam(TheObject, paramName, constraint);

    TBase parent = A.Named<TBase>(paramName);
    parent.IsTypeParam.Returns(true);
    TheObject.SetParent(parent);

    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithTypeParamsNoConstraint_ReturnsError(string typeParam)
  {
    ObjectParam(TheObject, typeParam, "");

    TBase parent = A.Named<TBase>(typeParam);
    parent.IsTypeParam.Returns(true);
    TheObject.SetParent(parent);

    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgGeneric_ReturnsError(string fieldName, string otherName, string paramName, string argType, string argParam)
  {
    this.SkipEqual(argType, argParam);

    Define<IGqlpSimple>(argParam);

    TObject otherArg = A.Obj<TObject, TBase>(argType);
    ObjectParam(otherArg, argParam, argParam);
    Definitions.Add(otherArg);

    TObject other = A.Obj<TObject, TBase>(otherName);
    ObjectParam(other, paramName, argType);
    Definitions.Add(other);

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName).SetArgs(arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase);
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoParam_ReturnsError(string fieldName, string otherName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(otherName);

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName).SetArgs(arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase);
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoConstraint_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(otherName, paramName, true);
    ObjectParam(other, paramName, "");

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName).SetArgs(arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase);
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoMatch_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(otherName, paramName, true);
    ObjectParam(other, paramName, argType);

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName).SetArgs(arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase);
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(false);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  private TObject DefineObject(string name)
  {
    TObject obj = A.Obj<TObject, TBase>(name);
    Definitions.Add(obj);
    Usages.Add(obj);
    return obj;
  }

  private TAlt ObjectAlternate(string type, TObject? obj = null)
  {
    obj ??= TheObject;

    TAlt alt = A.Named<TAlt, IGqlpObjAlternate>(type);
    string label = typeof(TAlt).Name[5..^9];
    alt.Label.Returns(label);
    alt.FullType.Returns(type);

    obj.Alternates.Returns([alt]);
    obj.ObjAlternates.Returns([alt]);

    return alt;
  }

  private TField ObjectField(string fieldName, string fieldType, TObject? obj = null)
  {
    obj ??= TheObject;

    TBase objBase = A.ObjBase<TBase, TArg>(fieldType);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase);

    obj.Fields.Returns([field]);
    obj.ObjFields.Returns([field]);

    return field;
  }

  private static TObject ObjectParam(TObject obj, string paramName, string constraint)
  {
    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    obj.TypeParams.Returns([typeParam]);
    return obj;
  }
}
