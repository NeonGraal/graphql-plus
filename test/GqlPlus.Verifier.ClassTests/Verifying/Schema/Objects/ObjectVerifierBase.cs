﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectVerifierBase<TObject, TBase, TField, TAlternate>
  : UsageVerifierBase<TObject>
  where TObject : class, IGqlpObject<TBase, TField, TAlternate>
  where TBase : class, IGqlpObjBase
  where TField : class, IGqlpObjField<TBase>
  where TAlternate : class, IGqlpObjAlternate
{
  internal readonly ForM<TField> MergeFields = new();
  internal readonly ForM<TAlternate> MergeAlternates = new();

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

  [Fact]
  public void Verify_Object_WithField_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = NFor<TField>("field");
    TBase dualBase = NFor<TBase>("String");
    field.Type.Returns(dualBase);
    field.BaseType.Returns(dualBase);

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

    TAlternate alternate = NFor<TAlternate>("String");

    TheObject.Alternates.Returns([alternate]);
    TheObject.ObjAlternates.Returns([alternate]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Object_WithParent_ReturnsNoErrors()
  {
    Define<TObject>("Parent");

    TBase parentBase = NFor<TBase>("Parent");
    TheObject.Parent.Returns(parentBase);
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Object_WithParentField_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    TField field = NFor<TField>("field");
    TBase dualBase = NFor<TBase>("String");
    field.Type.Returns(dualBase);
    field.BaseType.Returns(dualBase);

    TObject parent = NFor<TObject>("Parent");
    parent.Fields.Returns([field]);
    parent.ObjFields.Returns([field]);
    Definitions.Add(parent);

    TBase parentBase = NFor<TBase>("Parent");
    TheObject.Parent.Returns(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Object_WithParentAlternate_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    TAlternate alternate = NFor<TAlternate>("String");

    TObject parent = NFor<TObject>("Parent");
    parent.Alternates.Returns([alternate]);
    parent.ObjAlternates.Returns([alternate]);
    Definitions.Add(parent);

    TBase parentBase = NFor<TBase>("Parent");
    TheObject.Parent.Returns(parentBase);
    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
