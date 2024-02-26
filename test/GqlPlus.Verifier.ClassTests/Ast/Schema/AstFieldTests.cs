namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstFieldTests<TField, TReference>
  : AstAliasedTests<FieldInput>
  where TField : AstField<TReference> where TReference : AstReference<TReference>
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

  internal abstract IAstFieldChecks<TField, TReference> FieldChecks { get; }
}

internal sealed class AstFieldChecks<TField, TReference>
  : AstAliasedChecks<FieldInput, TField>, IAstFieldChecks<TField, TReference>
  where TField : AstField<TReference> where TReference : AstReference<TReference>
{
  private readonly FieldBy _createField;
  private readonly ReferenceBy _createReference;
  private readonly ArgumentsBy _createArguments;

  internal delegate TReference ReferenceBy(FieldInput input);
  internal delegate TField FieldBy(FieldInput input, TReference reference);
  internal delegate TReference[] ArgumentsBy(string[] arguments);

  public AstFieldChecks(FieldBy createField, ReferenceBy createReference, AstFieldChecks<TField, TReference>.ArgumentsBy createArguments)
    : base(input => createField(input, createReference(input)))
  {
    _createField = createField;
    _createReference = createReference;
    _createArguments = createArguments;
  }

  public void HashCode_WithModifiers(FieldInput input)
      => HashCode(() => CreateModifiers(input));

  public void String_WithModifiers(FieldInput input)
    => String(
      () => CreateModifiers(input),
      $"( !{Abbr} {input.Name} : {input.Type} [] ? )");

  public void Equality_WithModifiers(FieldInput input)
    => Equality(() => CreateModifiers(input));

  public void Inequality_WithModifiers(FieldInput input)
    => InequalityWith(input, () => CreateModifiers(input));

  public void ModifiedType_WithArguments(FieldInput input, string[] arguments)
  {
    var field = _createField(input, _createReference(input) with { Arguments = _createArguments(arguments) });
    var expected = $"{input.Type} < {arguments.Joined()} >";

    field.ModifiedType.Should().Be(expected);
  }

  public void ModifiedType_WithModifiers(FieldInput input)
  {
    var field = CreateModifiers(input);
    var expected = $"{input.Type} [] ?";

    field.ModifiedType.Should().Be(expected);
  }

  public void ModifiedType_WithModifiersAndArguments(FieldInput input, string[] arguments)
  {
    var field = _createField(
        input,
        _createReference(input) with { Arguments = _createArguments(arguments) }
      ) with { Modifiers = TestMods() };
    var expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    field.ModifiedType.Should().Be(expected);
  }

  private TField CreateModifiers(FieldInput input)
    => CreateInput(input) with { Modifiers = TestMods() };
}

internal interface IAstFieldChecks<TField, TReference>
  : IAstAliasedChecks<FieldInput>
  where TField : AstField<TReference> where TReference : AstReference<TReference>
{
  void HashCode_WithModifiers(FieldInput input);
  void String_WithModifiers(FieldInput input);
  void Equality_WithModifiers(FieldInput input);
  void Inequality_WithModifiers(FieldInput input);
  void ModifiedType_WithArguments(FieldInput input, string[] arguments);
  void ModifiedType_WithModifiers(FieldInput input);
  void ModifiedType_WithModifiersAndArguments(FieldInput input, string[] arguments);
}
