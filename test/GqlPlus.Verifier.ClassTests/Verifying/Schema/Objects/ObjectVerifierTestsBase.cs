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
  public void Verify_Object_ReturnsNoErrors()
  {
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithField_ReturnsNoErrors(string fieldName)
  {
    Define<IGqlpTypeSpecial>("String");

    TBase objBase = A.ObjBase<TBase>("String");
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithFieldParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>(constraint);

    ObjectParam(TheObject, paramName, constraint);

    TBase objBase = A.ObjBase<TBase>(paramName, "", true);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithFieldDict_ReturnsNoErrors(string fieldName, string key)
  {
    Define<IGqlpTypeSpecial>("String", key);

    TBase objBase = A.ObjBase<TBase>("String");
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Dict, key);
    field.Modifiers.Returns([modifier]);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithFieldDictUndefined_ReturnsError(string fieldName, string key)
  {
    Define<IGqlpTypeSpecial>("String");

    TBase objBase = A.ObjBase<TBase>("String");
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Dict, key);
    field.Modifiers.Returns([modifier]);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithFieldDictParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>("String", constraint);

    ObjectParam(TheObject, paramName, constraint);

    TBase objBase = A.ObjBase<TBase>("String");
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Param, paramName);
    field.Modifiers.Returns([modifier]);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithFieldDictParamUndefined_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define<IGqlpTypeSpecial>("String");

    TBase objBase = A.ObjBase<TBase>("String");
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Param, paramName);
    field.Modifiers.Returns([modifier]);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Object_WithAlternate_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    TAlt alt = ObjectAlternate(TheObject, "String");
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithAlternateAlternate_ReturnsNoErrors(string altType)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject other = A.Obj<TObject, TBase>(altType);
    ObjectAlternate(other, "String");
    Definitions.Add(other);

    TAlt alt = ObjectAlternate(TheObject, altType);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithAlternateSimpleArg_ReturnsError(string argType)
  {
    Define<IGqlpTypeSpecial>("String");

    TArg arg = A.Named<TArg>(argType);
    ObjectAlternate(TheObject, "String").SetArgs(arg);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithAlternateNoArg_ReturnsError(string altType, string paramName, string argType)
  {
    this.SkipIf(argType == altType);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(altType, paramName, true);
    ObjectParam(other, paramName, argType);

    ObjectAlternate(TheObject, altType);
    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithAlternateParentAlternate_ReturnsNoErrors(string parentName, string altType)
  {
    this.SkipIf(parentName == altType);

    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = A.Obj<TObject, TBase>(parentName);
    ObjectAlternate(parentObject, "String");
    Usages.Add(parentObject);
    Definitions.Add(parentObject);

    TObject altObject = A.Obj<TObject, TBase>(altType, parentName);
    Usages.Add(altObject);
    Definitions.Add(altObject);

    ObjectAlternate(TheObject, altType);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithAlternateParentAlternateCantMerge_ReturnsErrors(string parentName, string altType)
  {
    this.SkipIf(parentName == altType);

    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = A.Obj<TObject, TBase>(parentName);
    ObjectAlternate(parentObject, "String");
    Usages.Add(parentObject);
    Definitions.Add(parentObject);

    TObject altObject = A.Obj<TObject, TBase>(altType, parentName);
    Usages.Add(altObject);
    Definitions.Add(altObject);

    ObjectAlternate(TheObject, altType);
    Usages.Add(TheObject);

    MergeAlternates.CanMergeReturns("Merge fails".MakeMessages());

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithParent_ReturnsNoErrors(string parentName)
  {
    TObject parentType = A.Obj<TObject, TBase>(parentName);
    Usages.Add(parentType);
    Definitions.Add(parentType);

    TBase parentBase = A.ObjBase<TBase>(parentName);
    TheObject.SetParent(parentBase);
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithWrongParamParent_ReturnsErrors(string parentName, string paramName, string constraint)
  {
    this.SkipIf(parentName == paramName);

    Define<IGqlpTypeSpecial>(constraint);

    ObjectParam(TheObject, paramName, constraint);

    TBase parentBase = A.ObjBase<TBase>(parentName, "", true);
    TheObject.SetParent(parentBase);
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithParentField_ReturnsNoErrors(string fieldName, string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = A.ObjField<TField, TBase>(fieldName, A.ObjBase<TBase>("String"), "");

    TObject parent = A.Obj<TObject, TBase>(parentName);
    parent.Fields.Returns([field]);
    parent.ObjFields.Returns([field]);
    Definitions.Add(parent);

    TBase parentBase = A.ObjBase<TBase>(parentName);
    TheObject.SetParent(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithParentAlternate_ReturnsNoErrors(string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TObject parent = A.Obj<TObject, TBase>(parentName);
    AddTypes(parent);
    ObjectAlternate(parent, "String");
    Definitions.Add(parent);

    TBase parentBase = A.ObjBase<TBase>(parentName);
    TheObject.SetParent(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithTypeParams_ReturnsNoErrors(string paramName, string constraint)
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
  public void Verify_Object_WithTypeParamsNoConstraint_ReturnsError(string typeParam)
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
  public void Verify_Object_WithFieldTypeArgGeneric_ReturnsError(string fieldName, string otherName, string paramName, string argType, string argParam)
  {
    this.SkipIf(argType == otherName || argType == argParam);

    Define<IGqlpSimple>(argParam);

    TObject otherArg = A.Obj<TObject, TBase>(argType);
    ObjectParam(otherArg, argParam, argParam);
    Definitions.Add(otherArg);

    TObject other = A.Obj<TObject, TBase>(otherName);
    ObjectParam(other, paramName, argType);
    Definitions.Add(other);

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName, arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithFieldTypeArgNoParam_ReturnsError(string fieldName, string otherName, string argType)
  {
    this.SkipIf(argType == otherName);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(otherName);

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName, arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithFieldTypeArgNoConstraint_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipIf(argType == otherName);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(otherName, paramName, true);
    ObjectParam(other, paramName, "");

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName, arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithFieldTypeArgNoMatch_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipIf(argType == otherName);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(otherName, paramName, true);
    ObjectParam(other, paramName, argType);

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName, arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(false);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  private static TAlt ObjectAlternate(TObject obj, string type)
  {
    TAlt alt = A.Named<TAlt, IGqlpObjAlternate>(type);
    string label = typeof(TAlt).Name[5..^9];
    alt.Label.Returns(label);
    alt.FullType.Returns(type);

    obj.Alternates.Returns([alt]);
    obj.ObjAlternates.Returns([alt]);

    return alt;
  }

  private static TObject ObjectParam(TObject obj, string paramName, string constraint)
  {
    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    obj.TypeParams.Returns([typeParam]);
    return obj;
  }
}
