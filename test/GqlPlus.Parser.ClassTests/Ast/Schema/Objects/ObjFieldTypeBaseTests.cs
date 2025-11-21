using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class ObjFieldTypeBaseTests<TInput>
  : ObjEnumBaseTests<TInput>
{
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
  TypeBy<TInput, TObjType> createType
) : ObjEnumChecks<TInput, TObjType>(ToCreateBy(createType))
  , IObjFieldTypeChecks<TInput>
  where TObjType : IGqlpObjFieldType
  where TInput : ITypeInput
{
  private readonly TypeBy<TInput, TObjType> _createType = createType;

  public void ModifiedType_WithArgs(TInput input, string[] arguments)
  {
    TObjType field = _createType(input, CreateBase(input) with { Args = arguments.TypeArgs() });
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
    TObjType field = WithModifiers(_createType(input, CreateBase(input) with { Args = arguments.TypeArgs() }));
    string expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    field.ModifiedType.ShouldBe(expected);
  }

  internal static CreateBy<TInput> ToCreateBy(TypeBy<TInput, TObjType> createType)
    => input => createType(input, CreateBase(input));

  internal static ObjBaseAst CreateBase(TInput input)
     => new(AstNulls.At, input.Type, "");

  protected override string EnumString(TInput input, string enumLabel)
    => InputString(input)
    .Replace(":", "=", StringComparison.Ordinal)
    .Replace(")", $".{enumLabel} )", StringComparison.Ordinal);

  protected abstract TObjType WithModifiers(TObjType objType);
}

internal sealed class ObjFieldModifiersChecks<TInput, TObjType>(
  TypeBy<TInput, TObjType> createType,
  Func<TObjType, TObjType> addModifiers,
  [CallerArgumentExpression(nameof(createType))] string createExpression = ""
) : ModifiersChecks<TInput, TObjType>(ObjFieldTypeChecks<TInput, TObjType>.ToCreateBy(createType), addModifiers, createExpression)
  where TObjType : IGqlpObjFieldType
  where TInput : ITypeInput
{ }

internal sealed class ObjFieldCloneChecks<TInput, TObjType>(
  TypeBy<TInput, TObjType> createType,
  BaseAstChecks<TObjType>.CloneBy<TInput> cloneInput,
  [CallerArgumentExpression(nameof(createType))] string createExpression = "",
  [CallerArgumentExpression(nameof(cloneInput))] string cloneExpression = ""
) : CloneChecks<TInput, TObjType>(ObjFieldTypeChecks<TInput, TObjType>.ToCreateBy(createType), cloneInput, createExpression, cloneExpression)
  where TObjType : IGqlpObjFieldType
  where TInput : ITypeInput
{ }

internal delegate TObjType TypeBy<TInput, TObjType>(TInput input, IGqlpObjBase objBase)
  where TObjType : IGqlpObjFieldType
  where TInput : ITypeInput;

internal interface IObjFieldTypeChecks<TInput>
  : IObjEnumChecks<TInput>
{
  void ModifiedType_WithArgs(TInput input, string[] arguments);
  void ModifiedType_WithModifiers(TInput input);
  void ModifiedType_WithModifiersAndArgs(TInput input, string[] arguments);
}
