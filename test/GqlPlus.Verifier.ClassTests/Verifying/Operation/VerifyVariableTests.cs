using GqlPlus.Abstractions.Operation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyVariableTests
  : VerifierBase
{
  private readonly IGqlpConstant _defValue = EFor<IGqlpConstant>();
  private readonly IGqlpConstant _constant = For<IGqlpConstant>();

  private readonly IGqlpVariable _item = For<IGqlpVariable>();
  private readonly IGqlpFieldKey _keyField = EFor<IGqlpFieldKey>();

  private readonly VerifyVariable _verifier = new();
  private readonly List<IGqlpModifier> _modifiers = [];

  public VerifyVariableTests()
  {
    _item.DefaultValue.Returns(_defValue);
    _item.Modifiers.Returns(_modifiers);

    _keyField.EnumValue.Returns("Null.null");
  }

  [Fact]
  public void Verify_NoModifiersOrDefault()
  {
    _item.DefaultValue.ReturnsNull();

    _verifier.Verify(_item, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_JustDefault()
  {
    _verifier.Verify(_item, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_NullDefault()
  {
    _defValue.Value.Returns(_keyField);

    _verifier.Verify(_item, Errors);

    Errors.Count.ShouldBe(1);
  }

  [Fact]
  public void Verify_OptionalNullDefault()
  {
    _defValue.Value.Returns(_keyField);

    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_CorrectListDefault()
  {
    _defValue.Values.Returns([_constant]);

    AddModifier(ModifierKind.List);

    _verifier.Verify(_item, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_ObjectListDefault()
  {
    IGqlpFields<IGqlpConstant> fields = For<IGqlpFields<IGqlpConstant>>();
    fields.Count.Returns(1);
    _defValue.Fields.Returns(fields);

    AddModifier(ModifierKind.List);

    _verifier.Verify(_item, Errors);

    Errors.Count.ShouldBe(1);
  }

  [Fact]
  public void Verify_CorrectObjectDefault()
  {
    _defValue.Value.ReturnsNull();

    AddModifier(ModifierKind.Dict);

    _verifier.Verify(_item, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_ListObjectDefault()
  {
    _defValue.Values.Returns([_constant]);

    AddModifier(ModifierKind.Dict);

    _verifier.Verify(_item, Errors);

    Errors.Count.ShouldBe(1);
  }

  [Fact]
  public void Verify_OptionalListDefault()
  {
    _defValue.Values.Returns([_constant]);

    AddModifier(ModifierKind.List);
    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_ObjectOptionalListDefault()
  {
    IGqlpFields<IGqlpConstant> fields = For<IGqlpFields<IGqlpConstant>>();
    fields.Count.Returns(1);
    _defValue.Fields.Returns(fields);

    AddModifier(ModifierKind.List);
    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    Errors.Count.ShouldBe(1);
  }

  [Fact]
  public void Verify_OptionalObjectDefault()
  {
    _defValue.Value.ReturnsNull();

    AddModifier(ModifierKind.Dict);
    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_ListOptionalObjectDefault()
  {
    _defValue.Values.Returns([_constant]);

    AddModifier(ModifierKind.Dict);
    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    Errors.Count.ShouldBe(1);
  }

  private void AddModifier(ModifierKind kind)
  {
    IGqlpModifier modifier = For<IGqlpModifier>();
    modifier.ModifierKind.Returns(kind);
    _modifiers.Add(modifier);
  }
}
