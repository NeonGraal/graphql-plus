namespace GqlPlus.Ast.Schema.Objects;

internal abstract class ObjEnumChecks<TInput, TObjType>(
  BaseAstChecks<TObjType>.CreateBy<TInput> createInput
) : AstAbbreviatedChecks<TInput, TObjType>(createInput)
  , IObjEnumChecks<TInput>
  where TObjType : IAstObjEnum
{
  public void HashCode_WithEnumValue(TInput input, string enumLabel)
      => HashCode(() => CreateEnum(input, enumLabel));

  public void Text_WithEnumValue(TInput input, string enumLabel)
    => Text(
      () => CreateEnum(input, enumLabel),
      EnumString(input, enumLabel));

  public void Equality_WithEnumValue(TInput input, string enumLabel)
    => Equality(() => CreateEnum(input, enumLabel));

  public void Inequality_WithEnumValue(TInput input, string enumLabel)
    => InequalityWith(input, () => CreateEnum(input, enumLabel));

  public void Inequality_BetweenEnumValues(TInput input, string enumValue1, string enumValue2)
    => InequalityBetween(enumValue1, enumValue2,
      enumLabel => CreateEnum(input, enumLabel),
      enumValue1 == enumValue2);

  public void SetEnumType_WithEnumValue(TInput input, string enumType)
  {
    TObjType objEnum = CreateInput(input);
    string enumLabel = objEnum.EnumTypeName;

    objEnum.SetEnumType(enumType);

    objEnum.EnumValue.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
      e => e.EnumLabel.ShouldBe(enumLabel),
      e => e.EnumType.ShouldBe(enumType)
      );
  }

  protected abstract TObjType CreateEnum(TInput input, string enumLabel);
  protected virtual string EnumString(TInput input, string enumLabel)
    => InputString(input).Replace(" )", $".{enumLabel} )", StringComparison.Ordinal);
}

internal interface IObjEnumChecks<TInput>
  : IAstAbbreviatedChecks<TInput>
{
  void HashCode_WithEnumValue(TInput input, string enumLabel);
  void Text_WithEnumValue(TInput input, string enumLabel);
  void Equality_WithEnumValue(TInput input, string enumLabel);
  void Inequality_WithEnumValue(TInput input, string enumLabel);
  void Inequality_BetweenEnumValues(TInput input, string enumValue1, string enumValue2);

  void SetEnumType_WithEnumValue(TInput input, string enumType);
}
