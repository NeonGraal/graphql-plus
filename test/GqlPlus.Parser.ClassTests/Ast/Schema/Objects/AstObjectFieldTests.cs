using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectFieldTests
  : AstAliasedTests<FieldInput>
{
  [Theory, RepeatData]
  public void HashCode_WithModifiers(FieldInput input)
      => FieldChecks.HashCode_WithModifiers(input);

  [Theory, RepeatData]
  public void String_WithModifiers(FieldInput input)
    => FieldChecks.String_WithModifiers(input);

  [Theory, RepeatData]
  public void Equality_WithModifiers(FieldInput input)
    => FieldChecks.Equality_WithModifiers(input);

  [Theory, RepeatData]
  public void Inequality_WithModifiers(FieldInput input)
    => FieldChecks.Inequality_WithModifiers(input);

  [Theory, RepeatData]
  public void ModifiedType_WithArgs(FieldInput input, string[] arguments)
    => FieldChecks.ModifiedType_WithArgs(input, arguments);

  [Theory, RepeatData]
  public void ModifiedType_WithModifiers(FieldInput input)
    => FieldChecks.ModifiedType_WithModifiers(input);

  [Theory, RepeatData]
  public void ModifiedType_WithModifiersAndArgs(FieldInput input, string[] arguments)
    => FieldChecks.ModifiedType_WithModifiersAndArgs(input, arguments);

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(FieldInput input, string enumLabel)
      => FieldChecks.HashCode_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void String_WithEnumValue(FieldInput input, string enumLabel)
    => FieldChecks.String_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Equality_WithEnumValue(FieldInput input, string enumLabel)
    => FieldChecks.Equality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(FieldInput input, string enumValue1, string enumValue2)
    => FieldChecks.Inequality_BetweenEnumValues(input, enumValue1, enumValue2);

  internal sealed override IAstAliasedChecks<FieldInput> AliasedChecks => FieldChecks;

  protected override string InputName(FieldInput input) => input.Name;

  internal abstract IAstObjectFieldChecks FieldChecks { get; }
}

internal sealed class AstObjectFieldChecks<TObjField>(
  AstObjectFieldChecks<TObjField>.FieldBy createField,
  BaseAstChecks<TObjField>.CloneBy<FieldInput> cloneField
) : AstAliasedChecks<FieldInput, TObjField>(input => createField(input, BaseBy(input)), cloneField)
  , IAstObjectFieldChecks
  where TObjField : AstObjField
{
  private readonly FieldBy _createField = createField;

  internal delegate TObjField FieldBy(FieldInput input, IGqlpObjBase objBase);

  internal static ObjBaseAst BaseBy(FieldInput input)
    => new(AstNulls.At, input.Type, "") { IsTypeParam = input.TypeParam };

  public void HashCode_WithModifiers(FieldInput input)
      => HashCode(() => CreateModifiers(input));

  public void String_WithModifiers(FieldInput input)
    => Text(
      () => CreateModifiers(input),
      $"( !{Abbr} {input.Name} : {input.Type} [] ? )");

  public void Equality_WithModifiers(FieldInput input)
    => Equality(() => CreateModifiers(input));

  public void Inequality_WithModifiers(FieldInput input)
    => InequalityWith(input, () => CreateModifiers(input));

  public void HashCode_WithEnumValue(FieldInput input, string enumLabel)
      => HashCode(() => CreateEnum(input, enumLabel));

  public void String_WithEnumValue(FieldInput input, string enumLabel)
    => Text(
      () => CreateEnum(input, enumLabel),
      $"( !{Abbr} {input.Name} = {input.Type} .{enumLabel} )");

  public void Equality_WithEnumValue(FieldInput input, string enumLabel)
    => Equality(() => CreateEnum(input, enumLabel));

  public void Inequality_BetweenEnumValues(FieldInput input, string enumValue1, string enumValue2)
    => InequalityBetween(enumValue1, enumValue2,
      enumLabel => CreateEnum(input, enumLabel),
      enumValue1 == enumValue2);

  public void ModifiedType_WithArgs(FieldInput input, string[] arguments)
  {
    TObjField field = _createField(input, BaseBy(input) with { Args = arguments.TypeArgs() });
    string expected = $"{input.Type} < {arguments.Joined()} >";

    field.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiers(FieldInput input)
  {
    TObjField field = CreateModifiers(input);
    string expected = $"{input.Type} [] ?";

    field.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiersAndArgs(FieldInput input, string[] arguments)
  {
    TObjField field = _createField(
        input,
        BaseBy(input) with { Args = arguments.TypeArgs() }
      ) with { Modifiers = TestMods() };
    string expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    field.ModifiedType.ShouldBe(expected);
  }

  private TObjField CreateModifiers(FieldInput input)
    => CreateInput(input) with { Modifiers = TestMods() };

  private TObjField CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
}

internal interface IAstObjectFieldChecks
  : IAstAliasedChecks<FieldInput>
{
  void HashCode_WithModifiers(FieldInput input);
  void String_WithModifiers(FieldInput input);
  void Equality_WithModifiers(FieldInput input);
  void Inequality_WithModifiers(FieldInput input);

  void HashCode_WithEnumValue(FieldInput input, string enumLabel);
  void String_WithEnumValue(FieldInput input, string enumLabel);
  void Equality_WithEnumValue(FieldInput input, string enumLabel);
  void Inequality_BetweenEnumValues(FieldInput input, string enumValue1, string enumValue2);

  void ModifiedType_WithArgs(FieldInput input, string[] arguments);
  void ModifiedType_WithModifiers(FieldInput input);
  void ModifiedType_WithModifiersAndArgs(FieldInput input, string[] arguments);
}
