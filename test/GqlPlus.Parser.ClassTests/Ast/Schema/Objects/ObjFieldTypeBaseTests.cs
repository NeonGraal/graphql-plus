using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class ObjFieldTypeBaseTests<TInput>
  : ObjEnumBaseTests<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithModifiers(TInput input)
      => FieldChecks.HashCode_WithModifiers(input);

  [Theory, RepeatData]
  public void Text_WithModifiers(TInput input)
    => FieldChecks.Text_WithModifiers(input);

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

  internal abstract IObjFieldTypeChecks<TInput> FieldChecks { get; }
  internal sealed override IObjEnumChecks<TInput> EnumChecks => FieldChecks;
}

internal abstract class ObjFieldTypeChecks<TInput, TObjType>(
  ObjFieldTypeChecks<TInput, TObjType>.TypeBy createType
) : ObjEnumChecks<TInput, TObjType>(input => createType(input, ObjBaseFactory.Create(input)))
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

  public void Text_WithModifiers(TInput input)
    => Text(
      () => WithModifiers(CreateInput(input)),
      InputString(input).Replace(")", "[] ? )", StringComparison.Ordinal));

  public void Equality_WithModifiers(TInput input)
    => Equality(() => WithModifiers(CreateInput(input)));

  public void Inequality_WithModifiers(TInput input)
    => InequalityWith(input, () => WithModifiers(CreateInput(input)));

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

  protected override string EnumString(TInput input, string enumLabel)
    => InputString(input)
    .Replace(":", "=", StringComparison.Ordinal)
    .Replace(")", $".{enumLabel} )", StringComparison.Ordinal);

  protected abstract TObjType WithModifiers(TObjType objType);
}

internal interface IObjFieldTypeChecks<TInput>
  : IObjEnumChecks<TInput>
{
  void HashCode_WithModifiers(TInput input);
  void Text_WithModifiers(TInput input);
  void Equality_WithModifiers(TInput input);
  void Inequality_WithModifiers(TInput input);

  void ModifiedType_WithArgs(TInput input, string[] arguments);
  void ModifiedType_WithModifiers(TInput input);
  void ModifiedType_WithModifiersAndArgs(TInput input, string[] arguments);
}
