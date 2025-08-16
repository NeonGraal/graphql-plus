﻿using GqlPlus.Matching;

namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectVerifierTestsBase<TObject, TBase, TField, TAlt, TArg>
  : UsageVerifierTestsBase<TObject>
  where TObject : class, IGqlpObject<TBase, TField, TAlt>
  where TBase : class, IGqlpObjBase<TArg>
  where TField : class, IGqlpObjField<TBase>
  where TAlt : class, IGqlpObjAlternate
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

    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    TheObject.TypeParams.Returns([typeParam]);

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

    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    TheObject.TypeParams.Returns([typeParam]);

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

    TAlt alternate = MakeAlt("String");

    TheObject.Alternates.Returns([alternate]);
    TheObject.ObjAlternates.Returns([alternate]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithAlternateParentAlternate_ReturnsNoErrors(string parentName, string alternateName)
  {
    this.SkipIf(parentName == alternateName);

    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = A.Obj<TObject, TBase>(parentName);
    TAlt parentAlt = MakeAlt("String");
    parentObject.Alternates.Returns([parentAlt]);
    parentObject.ObjAlternates.Returns([parentAlt]);
    Usages.Add(parentObject);
    Definitions.Add(parentObject);

    TObject altObject = A.Obj<TObject, TBase>(alternateName, parentName);
    Usages.Add(altObject);
    Definitions.Add(altObject);

    TAlt alternate = MakeAlt(alternateName);

    TheObject.Alternates.Returns([alternate]);
    TheObject.ObjAlternates.Returns([alternate]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithParent_ReturnsNoErrors(string parentName)
  {
    Define<TObject>(parentName);

    TBase parentBase = A.Named<TBase>(parentName);
    TheObject.Parent.Returns(parentBase);
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

    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    TheObject.TypeParams.Returns([typeParam]);
    TBase parentBase = A.ObjBase<TBase>(parentName, "", true);
    TheObject.Parent.Returns(parentBase);
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

    TBase parentBase = A.Named<TBase, IGqlpObjBase>(parentName);
    TheObject.Parent.Returns(parentBase);
    TheObject.ObjParent.Returns(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithParentAlternate_ReturnsNoErrors(string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TAlt alternate = MakeAlt("String");

    TObject parent = A.Obj<TObject, TBase>(parentName);
    parent.Alternates.Returns([alternate]);
    parent.ObjAlternates.Returns([alternate]);
    Definitions.Add(parent);

    TBase parentBase = A.Named<TBase, IGqlpObjBase>(parentName);
    TheObject.Parent.Returns(parentBase);
    TheObject.ObjParent.Returns(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithTypeParams_ReturnsNoErrors(string paramName, string constraint)
  {
    Define<IGqlpTypeSpecial>(constraint);

    IGqlpTypeParam typeParam = A.TypeParam(paramName, constraint);
    TheObject.TypeParams.Returns([typeParam]);
    TBase parent = A.Named<TBase>(paramName);
    parent.IsTypeParam.Returns(true);
    TheObject.ObjParent.Returns(parent);

    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithTypeParamsNoConstraint_ReturnsError(string typeParam)
  {
    IGqlpTypeParam[] typeParams = A.NamedArray<IGqlpTypeParam>(typeParam);
    TheObject.TypeParams.Returns(typeParams);
    TBase parent = A.Named<TBase>(typeParam);
    parent.IsTypeParam.Returns(true);
    TheObject.ObjParent.Returns(parent);

    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithTypeArg_ReturnsNoErrors(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipIf(argType == otherName);

    Define<IGqlpSimple>(argType);

    TObject other = A.Obj<TObject, TBase>(otherName, paramName, true);
    IGqlpTypeParam typeParam = A.TypeParam(paramName, argType);
    other.TypeParams.Returns([typeParam]);

    TArg arg = A.Named<TArg>(argType);
    TBase objBase = A.ObjBase<TBase, TArg>(otherName, arg);
    TField field = A.ObjField<TField, TBase>(fieldName, objBase, "");
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  private static TAlt MakeAlt(string type)
  {
    TAlt alternate = A.Named<TAlt>(type);
    alternate.FullType.Returns(type);
    return alternate;
  }
}
