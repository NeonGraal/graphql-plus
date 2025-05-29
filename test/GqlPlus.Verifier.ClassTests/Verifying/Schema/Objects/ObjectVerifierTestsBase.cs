using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

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

    TField field = NFor<TField>(fieldName);
    TBase dualBase = NFor<TBase>("String");
    SetFieldType(field, dualBase);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
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
    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = NFor<TObject>(parentName);
    TAlt parentAlt = MakeAlt("String");
    parentObject.Alternates.Returns([parentAlt]);
    parentObject.ObjAlternates.Returns([parentAlt]);
    Usages.Add(parentObject);
    Definitions.Add(parentObject);

    TBase parentBase = NFor<TBase>(parentName);
    TObject altObject = NFor<TObject>(alternateName);
    altObject.Parent.Returns(parentBase);
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

    TBase parentBase = NFor<TBase>(parentName);
    TheObject.Parent.Returns(parentBase);
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithParentField_ReturnsNoErrors(string fieldName, string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = NFor<TField>(fieldName);
    TBase dualBase = NFor<TBase>("String");
    SetFieldType(field, dualBase);

    TObject parent = NFor<TObject>(parentName);
    parent.Fields.Returns([field]);
    parent.ObjFields.Returns([field]);
    Definitions.Add(parent);

    TBase parentBase = NFor<TBase>(parentName);
    TheObject.Parent.Returns(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithParentAlternate_ReturnsNoErrors(string parentName)
  {
    Define<IGqlpTypeSpecial>("String");

    TAlt alternate = MakeAlt("String");

    TObject parent = NFor<TObject>(parentName);
    parent.Alternates.Returns([alternate]);
    parent.ObjAlternates.Returns([alternate]);
    Definitions.Add(parent);

    TBase parentBase = NFor<TBase>(parentName);
    TheObject.Parent.Returns(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithTypeParams_ReturnsNoErrors(string typeParam)
  {
    IGqlpTypeParam[] typeParams = NForA<IGqlpTypeParam>(typeParam);
    TheObject.TypeParams.Returns(typeParams);
    TBase parent = NFor<TBase>(typeParam);
    parent.IsTypeParam.Returns(true);
    TheObject.ObjParent.Returns(parent);

    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Object_WithTypeArg_ReturnsNoErrors(string fieldName, string otherName, string paramName, string argType)
  {
    Define<IGqlpSimple>(argType);

    TObject other = NFor<TObject>(otherName);
    IGqlpTypeParam typeParam = NFor<IGqlpTypeParam>(paramName);
    typeParam.Constraint.Returns(argType);
    other.TypeParams.Returns([typeParam]);
    TBase parent = NFor<TBase>(paramName);
    parent.IsTypeParam.Returns(true);
    other.ObjParent.Returns(parent);

    TField field = NFor<TField>(fieldName);
    TBase dualBase = NFor<TBase>(otherName);
    TArg[] args = NForA<TArg>(argType);
    dualBase.Args.Returns(args);
    dualBase.BaseArgs.Returns(args);
    SetFieldType(field, dualBase);

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  protected void SetFieldType([NotNull] TField field, TBase type)
  {
    field.Type.Returns(type);
    field.BaseType.Returns(type);
  }

  private static TAlt MakeAlt(string type)
  {
    TAlt alternate = NFor<TAlt>(type);
    alternate.FullType.Returns(type);
    return alternate;
  }
}
