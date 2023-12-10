namespace GqlPlus.Verifier.Ast.Schema;

internal class AstFieldChecks<TField, TReference>
  : BaseAliasedAstChecks<FieldInput, TField>, IAstFieldChecks<TField, TReference>
  where TField : AstField<TReference> where TReference : AstReference<TReference>
{
  public AstFieldChecks(CreateBy<FieldInput> create)
    : base(create) { }

  public void HashCode_WithModifiers(FieldInput input)
      => HashCode(() => CreateModifiers(input));

  public void String_WithModifiers(FieldInput input)
    => String(
      () => CreateModifiers(input),
      ModifiersString(input));

  public void Equality_WithModifiers(FieldInput input)
    => Equality(() => CreateModifiers(input));

  public void Inequality_WithModifiers(FieldInput input)
    => InequalityWith(input, () => CreateModifiers(input));

  public string ModifiersString(FieldInput input)
    => $"( !{Abbr} {input.Name} : {input.Type} [] ? )";

  private TField CreateModifiers(FieldInput input)
    => CreateInput(input) with { Modifiers = TestMods() };
}

public record struct FieldInput(string Name, string Type);

internal interface IAstFieldChecks<TField, TReference>
  : IBaseAliasedAstChecks<FieldInput>
  where TField : AstField<TReference> where TReference : AstReference<TReference>
{
  void HashCode_WithModifiers(FieldInput input);
  void String_WithModifiers(FieldInput input);
  void Equality_WithModifiers(FieldInput input);
  void Inequality_WithModifiers(FieldInput input);
}
