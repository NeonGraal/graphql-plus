using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class ObjFieldTypeTests<TInput>
  : AstAbbreviatedTests<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithModifiers(TInput input)
      => FieldChecks.HashCode_WithModifiers(input);

  [Theory, RepeatData]
  public void String_WithModifiers(TInput input)
    => FieldChecks.String_WithModifiers(input,
      InputString(input).Replace(")", "[] ? )", StringComparison.Ordinal));

  [Theory, RepeatData]
  public void Equality_WithModifiers(TInput input)
    => FieldChecks.Equality_WithModifiers(input);

  [Theory, RepeatData]
  public void Inequality_WithModifiers(TInput input)
    => FieldChecks.Inequality_WithModifiers(input);

  [Theory, RepeatData]
  public void ModifiedType_WithArgs(TInput input, string[] arguments)
    => FieldChecks.ModifiedType_WithArgs(input, arguments);

  [Theory, RepeatData]
  public void ModifiedType_WithModifiers(TInput input)
    => FieldChecks.ModifiedType_WithModifiers(input);

  [Theory, RepeatData]
  public void ModifiedType_WithModifiersAndArgs(TInput input, string[] arguments)
    => FieldChecks.ModifiedType_WithModifiersAndArgs(input, arguments);

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(TInput input, string enumLabel)
      => FieldChecks.HashCode_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void String_WithEnumValue(TInput input, string enumLabel)
    => FieldChecks.String_WithEnumValue(input, enumLabel,
      InputString(input)
      .Replace(":", "=", StringComparison.Ordinal)
      .Replace(")", $".{enumLabel} )", StringComparison.Ordinal));

  [Theory, RepeatData]
  public void Equality_WithEnumValue(TInput input, string enumLabel)
    => FieldChecks.Equality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(TInput input, string enumValue1, string enumValue2)
    => FieldChecks.Inequality_BetweenEnumValues(input, enumValue1, enumValue2);

  internal abstract IObjFieldTypeChecks<TInput> FieldChecks { get; }
  internal override IAstAbbreviatedChecks<TInput> AbbreviatedChecks => FieldChecks;
}

internal abstract class ObjFieldTypeChecks<TInput, TObjType>(
  ObjFieldTypeChecks<TInput, TObjType>.TypeBy createType,
  BaseAstChecks<TObjType>.CloneBy<TInput> cloneInput
) : AstAbbreviatedChecks<TInput, TObjType>(input => createType(input, BaseBy(input)), cloneInput)
  , IObjFieldTypeChecks<TInput>
  where TObjType : IGqlpObjFieldType
  where TInput : ITypeInput
{
  private readonly TypeBy _createType = createType;

  internal delegate TObjType TypeBy(TInput input, IGqlpObjBase objBase);

  internal static ObjBaseAst BaseBy(TInput input)
    => new(AstNulls.At, input.Type, "") { IsTypeParam = input.TypeParam };

  public void HashCode_WithModifiers(TInput input)
      => HashCode(() => WithModifiers(CreateInput(input)));

  public void String_WithModifiers(TInput input, string expected)
    => Text(() => WithModifiers(CreateInput(input)), expected);

  public void Equality_WithModifiers(TInput input)
    => Equality(() => WithModifiers(CreateInput(input)));

  public void Inequality_WithModifiers(TInput input)
    => InequalityWith(input, () => WithModifiers(CreateInput(input)));

  public void HashCode_WithEnumValue(TInput input, string enumLabel)
      => HashCode(() => CreateEnum(input, enumLabel));

  public void String_WithEnumValue(TInput input, string enumLabel, string expected)
    => Text(
      () => CreateEnum(input, enumLabel), expected);

  public void Equality_WithEnumValue(TInput input, string enumLabel)
    => Equality(() => CreateEnum(input, enumLabel));

  public void Inequality_BetweenEnumValues(TInput input, string enumValue1, string enumValue2)
    => InequalityBetween(enumValue1, enumValue2,
      enumLabel => CreateEnum(input, enumLabel),
      enumValue1 == enumValue2);

  public void ModifiedType_WithArgs(TInput input, string[] arguments)
  {
    TObjType field = _createType(input, BaseBy(input) with { Args = arguments.TypeArgs() });
    string expected = $"{input.Type} < {arguments.Joined()} >";

    field.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiers(TInput input)
  {
    TObjType field = WithModifiers(CreateInput(input));
    string expected = $"{input.Type} [] ?";

    field.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiersAndArgs(TInput input, string[] arguments)
  {
    TObjType field = WithModifiers(_createType(input, BaseBy(input) with { Args = arguments.TypeArgs() }));
    string expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    field.ModifiedType.ShouldBe(expected);
  }

  protected abstract TObjType WithModifiers(TObjType objType);

  protected abstract TObjType CreateEnum(TInput input, string enumLabel);
}

internal interface IObjFieldTypeChecks<TInput>
  : IAstAbbreviatedChecks<TInput>
{
  void HashCode_WithModifiers(TInput input);
  void String_WithModifiers(TInput input, string expected);
  void Equality_WithModifiers(TInput input);
  void Inequality_WithModifiers(TInput input);

  void HashCode_WithEnumValue(TInput input, string enumLabel);
  void String_WithEnumValue(TInput input, string enumLabel, string expected);
  void Equality_WithEnumValue(TInput input, string enumLabel);
  void Inequality_BetweenEnumValues(TInput input, string enumValue1, string enumValue2);

  void ModifiedType_WithArgs(TInput input, string[] arguments);
  void ModifiedType_WithModifiers(TInput input);
  void ModifiedType_WithModifiersAndArgs(TInput input, string[] arguments);
}
