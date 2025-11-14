using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Ast.Schema.Objects;

public class AlternateAstTests
  : ObjEnumBaseTests<TypeInput>
{
  [Theory, RepeatData]
  public void HashCode_WithModifiers(TypeInput input)
      => AlternateChecks.HashCode_WithModifiers(input);

  [Theory, RepeatData]
  public void Text_WithModifiers(TypeInput input)
    => AlternateChecks.Text_WithModifiers(input);

  [Theory, RepeatData]
  public void Equality_WithModifiers(TypeInput input)
    => AlternateChecks.Equality_WithModifiers(input);

  [Theory, RepeatData]
  public void Inequality_WithModifiers(TypeInput input)
    => AlternateChecks.Inequality_WithModifiers(input);

  internal sealed override IObjEnumChecks<TypeInput> EnumChecks => AlternateChecks;

  internal IAstObjectAlternateChecks AlternateChecks { get; } = new AstObjectAlternateChecks();
}

internal sealed class AstObjectAlternateChecks
  : ObjEnumChecks<TypeInput, AlternateAst>
  , IAstObjectAlternateChecks
{
  [SuppressMessage("Style", "IDE0290:Use primary constructor")]
  public AstObjectAlternateChecks()
    : base(CreateAlternate, CloneAlternate)
  { }
  internal delegate ObjBaseAst BaseBy(TypeInput input);

  private static AlternateAst CloneAlternate(AlternateAst original, TypeInput input)
    => original with { Name = input.Type };
  internal static AlternateAst CreateAlternate(TypeInput input)
    => new(AstNulls.At, input.Type, "");

  public void HashCode_WithModifiers(TypeInput input)
      => HashCode(() => CreateModifiers(input));

  public void Text_WithModifiers(TypeInput input)
    => Text(
      () => CreateModifiers(input),
      $"( {input.Type} [] ? )");

  public void Equality_WithModifiers(TypeInput input)
    => Equality(() => CreateModifiers(input));

  public void Inequality_WithModifiers(TypeInput input)
    => InequalityWith(input, () => CreateModifiers(input));

  private AlternateAst CreateModifiers(TypeInput input)
    => CreateInput(input) with { Modifiers = TestMods() };

  protected override string InputString(TypeInput input)
    => $"( {input.Type} )";
  protected override AlternateAst CreateEnum(TypeInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, input.Type, enumLabel) };
}

internal interface IAstObjectAlternateChecks
  : IObjEnumChecks<TypeInput>
{
  void HashCode_WithModifiers(TypeInput input);
  void Text_WithModifiers(TypeInput input);
  void Equality_WithModifiers(TypeInput input);
  void Inequality_WithModifiers(TypeInput input);
}
