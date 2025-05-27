using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

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

    TAlternate alternate = MakeAlt("String");

    TheObject.Alternates.Returns([alternate]);
    TheObject.ObjAlternates.Returns([alternate]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Object_WithAlternateParentAlternate_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    TObject parentObject = NFor<TObject>("Parent");
    TAlternate parentAlt = MakeAlt("String");
    parentObject.Alternates.Returns([parentAlt]);
    parentObject.ObjAlternates.Returns([parentAlt]);
    Usages.Add(parentObject);
    Definitions.Add(parentObject);

    TBase parentBase = NFor<TBase>("Parent");
    TObject altObject = NFor<TObject>("Alternate");
    altObject.Parent.Returns(parentBase);
    Usages.Add(altObject);
    Definitions.Add(altObject);

    TAlternate alternate = MakeAlt("Alternate");

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
    SetFieldType(field, dualBase);

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

    TAlternate alternate = MakeAlt("String");

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

  protected void SetFieldType([NotNull] TField field, TBase type)
  {
    field.Type.Returns(type);
    field.BaseType.Returns(type);
  }

  private static TAlternate MakeAlt(string type)
  {
    TAlternate alternate = NFor<TAlternate>(type);
    alternate.FullType.Returns(type);
    return alternate;
  }
}
