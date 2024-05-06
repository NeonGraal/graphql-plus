namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectFieldTests<TObjField, TObjBase>
  : AstAliasedTests<FieldInput>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(FieldInput input)
      => FieldChecks.HashCode_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(FieldInput input)
    => FieldChecks.String_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(FieldInput input)
    => FieldChecks.Equality_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(FieldInput input)
    => FieldChecks.Inequality_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void ModifiedType_WithArguments(FieldInput input, string[] arguments)
    => FieldChecks.ModifiedType_WithArguments(input, arguments);

  [Theory, RepeatData(Repeats)]
  public void ModifiedType_WithModifiers(FieldInput input)
    => FieldChecks.ModifiedType_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void ModifiedType_WithModifiersAndArguments(FieldInput input, string[] arguments)
    => FieldChecks.ModifiedType_WithModifiersAndArguments(input, arguments);

  internal sealed override IAstAliasedChecks<FieldInput> AliasedChecks => FieldChecks;

  internal abstract IAstObjectFieldChecks<TObjField, TObjBase> FieldChecks { get; }
}

internal sealed class AstObjectFieldChecks<TObjField, TObjBase>
  : AstAliasedChecks<FieldInput, TObjField>
  , IAstObjectFieldChecks<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  private readonly FieldBy _createField;
  private readonly BaseBy _createBase;
  private readonly ArgumentsBy _createArguments;

  internal delegate TObjBase BaseBy(FieldInput input);
  internal delegate TObjField FieldBy(FieldInput input, TObjBase refBase);
  internal delegate TObjBase[] ArgumentsBy(string[] arguments);

  public AstObjectFieldChecks(FieldBy createField, BaseBy createBase, AstObjectFieldChecks<TObjField, TObjBase>.ArgumentsBy createArguments)
    : base(input => createField(input, createBase(input)))
  {
    _createField = createField;
    _createBase = createBase;
    _createArguments = createArguments;
  }

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

  public void ModifiedType_WithArguments(FieldInput input, string[] arguments)
  {
    TObjField field = _createField(input, _createBase(input) with { Arguments = _createArguments(arguments) });
    string expected = $"{input.Type} < {arguments.Joined()} >";

    field.ModifiedType.Should().Be(expected);
  }

  public void ModifiedType_WithModifiers(FieldInput input)
  {
    TObjField field = CreateModifiers(input);
    string expected = $"{input.Type} [] ?";

    field.ModifiedType.Should().Be(expected);
  }

  public void ModifiedType_WithModifiersAndArguments(FieldInput input, string[] arguments)
  {
    TObjField field = _createField(
        input,
        _createBase(input) with { Arguments = _createArguments(arguments) }
      ) with { Modifiers = TestMods() };
    string expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    field.ModifiedType.Should().Be(expected);
  }

  private TObjField CreateModifiers(FieldInput input)
    => CreateInput(input) with { Modifiers = TestMods() };
}

internal interface IAstObjectFieldChecks<TObjField, TObjBase>
  : IAstAliasedChecks<FieldInput>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  void HashCode_WithModifiers(FieldInput input);
  void String_WithModifiers(FieldInput input);
  void Equality_WithModifiers(FieldInput input);
  void Inequality_WithModifiers(FieldInput input);
  void ModifiedType_WithArguments(FieldInput input, string[] arguments);
  void ModifiedType_WithModifiers(FieldInput input);
  void ModifiedType_WithModifiersAndArguments(FieldInput input, string[] arguments);
}
