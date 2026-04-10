using GqlPlus.Abstractions.Operation;
using NSubstitute.ReturnsExtensions;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyVariableTests
  : VerifierTestsBase
{
  private readonly IAstConstant _defValue = A.Error<IAstConstant>();
  private readonly IAstConstant _constant = A.Constant("constant");

  private readonly IGqlpVariable _item = A.Variable("item");
  private readonly IAstFieldKey _keyField = A.EnumFieldKey(BuiltIn.NullType, BuiltIn.NullValue);

  private readonly VerifyVariable _verifier = new();
  private readonly List<IAstModifier> _modifiers = [];

  public VerifyVariableTests()
  {
    _item.DefaultValue.Returns(_defValue);
    _item.Modifiers.Returns(_modifiers);
  }

  [Fact]
  public void Verify_WithNoModifiersOrDefault_ReturnsNoErrors()
  {
    _item.DefaultValue.ReturnsNull();

    _verifier.Verify(_item, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_WithJustDefault_ReturnsNoErrors()
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
    IAstFields<IAstConstant> fields = A.Fields<IAstConstant>("", default!);
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

  [Theory, RepeatData]
  public void Verify_ObjectOptionalListDefault(string key, string value)
  {
    IAstConstant constant = A.Constant(value);
    IAstFields<IAstConstant> fields = A.Fields(key, constant);
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
    IAstModifier modifier = A.Modifier(kind);
    _modifiers.Add(modifier);
  }
}
