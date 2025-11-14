using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Ast.Schema.Objects;

public class AlternateAstTests
  : AstAbbreviatedTests<TypeInput>
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

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(TypeInput input, string enumLabel)
      => AlternateChecks.HashCode_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Text_WithEnumValue(TypeInput input, string enumLabel)
    => AlternateChecks.Text_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Equality_WithEnumValue(TypeInput input, string enumLabel)
    => AlternateChecks.Equality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_WithEnumValue(TypeInput input, string enumLabel)
    => AlternateChecks.Inequality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void ModifiedType_WithArgs(TypeInput input, string[] arguments)
    => AlternateChecks.ModifiedType_WithArgs(input, arguments);

  [Theory, RepeatData]
  public void ModifiedType_WithModifiers(TypeInput input)
    => AlternateChecks.ModifiedType_WithModifiers(input);

  [Theory, RepeatData]
  public void ModifiedType_WithModifiersAndArgs(TypeInput input, string[] arguments)
    => AlternateChecks.ModifiedType_WithModifiersAndArgs(input, arguments);

  internal sealed override IAstAbbreviatedChecks<TypeInput> AbbreviatedChecks => AlternateChecks;

  internal IAstObjectAlternateChecks AlternateChecks { get; } = new AstObjectAlternateChecks();
}

internal sealed class AstObjectAlternateChecks
  : AstAbbreviatedChecks<TypeInput, AlternateAst>
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

  public void HashCode_WithEnumValue(TypeInput input, string enumLabel)
      => HashCode(() => CreateEnumValue(input, enumLabel));

  public void Text_WithEnumValue(TypeInput input, string enumLabel)
    => Text(
      () => CreateEnumValue(input, enumLabel),
      $"( {input.Type}.{enumLabel} )");

  public void Equality_WithEnumValue(TypeInput input, string enumLabel)
    => Equality(() => CreateEnumValue(input, enumLabel));

  public void Inequality_WithEnumValue(TypeInput input, string enumLabel)
    => InequalityWith(input, () => CreateEnumValue(input, enumLabel));

  public void ModifiedType_WithArgs(TypeInput input, string[] arguments)
  {
    AlternateAst alternate = CreateAlternate(input) with { Args = arguments.TypeArgs() };
    string expected = $"{input.Type} < {arguments.Joined()} >";

    alternate.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiers(TypeInput input)
  {
    AlternateAst alternate = CreateModifiers(input);
    string expected = $"{input.Type} [] ?";

    alternate.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiersAndArgs(TypeInput input, string[] arguments)
  {
    AlternateAst alternate = CreateAlternate(input) with {
      Args = arguments.TypeArgs(),
      Modifiers = TestMods()
    };
    string expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    alternate.ModifiedType.ShouldBe(expected);
  }

  protected override string InputString(TypeInput input)
    => $"( {input.Type} )";

  private AlternateAst CreateEnumValue(TypeInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, input.Type, enumLabel) };

  private AlternateAst CreateModifiers(TypeInput input)
    => CreateInput(input) with { Modifiers = TestMods() };
}

internal interface IAstObjectAlternateChecks
  : IAstAbbreviatedChecks<TypeInput>
{
  void HashCode_WithModifiers(TypeInput input);
  void Text_WithModifiers(TypeInput input);
  void Equality_WithModifiers(TypeInput input);
  void Inequality_WithModifiers(TypeInput input);

  void HashCode_WithEnumValue(TypeInput input, string enumLabel);
  void Text_WithEnumValue(TypeInput input, string enumLabel);
  void Equality_WithEnumValue(TypeInput input, string enumLabel);
  void Inequality_WithEnumValue(TypeInput input, string enumLabel);

  void ModifiedType_WithArgs(TypeInput input, string[] arguments);
  void ModifiedType_WithModifiers(TypeInput input);
  void ModifiedType_WithModifiersAndArgs(TypeInput input, string[] arguments);
}
