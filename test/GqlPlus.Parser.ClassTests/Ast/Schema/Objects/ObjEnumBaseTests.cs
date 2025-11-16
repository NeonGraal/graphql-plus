using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class ObjEnumBaseTests<TInput>
  : AstAbbreviatedBaseTests<TInput>
{

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(TInput input, string enumLabel)
      => EnumChecks.HashCode_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Text_WithEnumValue(TInput input, string enumLabel)
    => EnumChecks.Text_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Equality_WithEnumValue(TInput input, string enumLabel)
    => EnumChecks.Equality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_WithEnumValue(TInput input, string enumLabel)
    => EnumChecks.Inequality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(TInput input, string enumValue1, string enumValue2)
    => EnumChecks.Inequality_BetweenEnumValues(input, enumValue1, enumValue2);

  internal abstract IObjEnumChecks<TInput> EnumChecks { get; }
  internal override IAstAbbreviatedChecks<TInput> AbbreviatedChecks => EnumChecks;
}

internal abstract class ObjEnumChecks<TInput, TObjType>(
  BaseAstChecks<TObjType>.CreateBy<TInput> createInput
) : AstAbbreviatedChecks<TInput, TObjType>(createInput)
  , IObjEnumChecks<TInput>
  where TObjType : IGqlpObjEnum
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
}
