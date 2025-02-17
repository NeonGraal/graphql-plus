using GqlPlus.Abstractions.Operation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyVariableTests
  : VerifierBase
{
  private readonly IGqlpConstant _defValue;
  private readonly IGqlpVariable _item;

  private readonly VerifyVariable _verifier = new();
  private readonly List<IGqlpModifier> _modifiers = [];

  public VerifyVariableTests()
  {
    _defValue = For<IGqlpConstant>();
    _defValue.MakeError("").ReturnsForAnyArgs(MakeMessages);

    _item = For<IGqlpVariable>();
    _item.DefaultValue.Returns(_defValue);
    _item.Modifiers.Returns(_modifiers);
  }

  [Fact]
  public void Verify_NoModifiersOrDefault()
  {
    _item.DefaultValue.ReturnsNull();

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_JustDefault()
  {
    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_NullDefault()
  {
    IGqlpFieldKey value = For<IGqlpFieldKey>();
    value.EnumValue.Returns("Null.null");
    _defValue.Value.Returns(value);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Count.Should().Be(1);
  }

  [Fact]
  public void Verify_OptionalNullDefault()
  {
    IGqlpFieldKey value = For<IGqlpFieldKey>();
    value.EnumValue.Returns("Null.null");
    _defValue.Value.Returns(value);

    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_CorrectListDefault()
  {
    IGqlpConstant value = For<IGqlpConstant>();
    _defValue.Values.Returns([value]);

    AddModifier(ModifierKind.List);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_ObjectListDefault()
  {
    IGqlpFields<IGqlpConstant> fields = For<IGqlpFields<IGqlpConstant>>();
    fields.Count.Returns(1);
    _defValue.Fields.Returns(fields);

    AddModifier(ModifierKind.List);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Count.Should().Be(1);
  }

  [Fact]
  public void Verify_CorrectObjectDefault()
  {
    _defValue.Value.ReturnsNull();

    AddModifier(ModifierKind.Dict);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_ListObjectDefault()
  {
    IGqlpConstant value = For<IGqlpConstant>();
    _defValue.Values.Returns([value]);

    AddModifier(ModifierKind.Dict);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Count.Should().Be(1);
  }

  [Fact]
  public void Verify_OptionalListDefault()
  {
    IGqlpConstant value = For<IGqlpConstant>();
    _defValue.Values.Returns([value]);

    AddModifier(ModifierKind.List);
    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Should().BeNullOrEmpty();
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

    using AssertionScope scope = new();

    Errors.Count.Should().Be(1);
  }

  [Fact]
  public void Verify_OptionalObjectDefault()
  {
    _defValue.Value.ReturnsNull();

    AddModifier(ModifierKind.Dict);
    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_ListOptionalObjectDefault()
  {
    IGqlpConstant value = For<IGqlpConstant>();
    _defValue.Values.Returns([value]);

    AddModifier(ModifierKind.Dict);
    AddModifier(ModifierKind.Opt);

    _verifier.Verify(_item, Errors);

    using AssertionScope scope = new();

    Errors.Count.Should().Be(1);
  }

  private void AddModifier(ModifierKind kind)
  {
    IGqlpModifier modifier = For<IGqlpModifier>();
    modifier.ModifierKind.Returns(kind);
    _modifiers.Add(modifier);
  }
}
