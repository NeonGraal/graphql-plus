namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstFieldTests<TField, TReference>
  : BaseAliasedAstTests<FieldInput>
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

  internal override IBaseAliasedAstChecks<FieldInput> AliasedChecks => FieldChecks;

  internal abstract IAstFieldChecks<TField, TReference> FieldChecks { get; }
}
