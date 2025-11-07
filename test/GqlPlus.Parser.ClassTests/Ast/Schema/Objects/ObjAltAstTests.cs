using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Ast.Schema.Objects;

public class AlternateAstTests
  : AstAbbreviatedTests<AlternateInput>
{
  [Theory, RepeatData]
  public void HashCode_WithModifiers(AlternateInput input)
      => AlternateChecks.HashCode_WithModifiers(input);

  [Theory, RepeatData]
  public void String_WithModifiers(AlternateInput input)
    => AlternateChecks.String_WithModifiers(input);

  [Theory, RepeatData]
  public void Equality_WithModifiers(AlternateInput input)
    => AlternateChecks.Equality_WithModifiers(input);

  [Theory, RepeatData]
  public void Inequality_WithModifiers(AlternateInput input)
    => AlternateChecks.Inequality_WithModifiers(input);

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(AlternateInput input, string enumLabel)
      => AlternateChecks.HashCode_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void String_WithEnumValue(AlternateInput input, string enumLabel)
    => AlternateChecks.String_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Equality_WithEnumValue(AlternateInput input, string enumLabel)
    => AlternateChecks.Equality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_WithEnumValue(AlternateInput input, string enumLabel)
    => AlternateChecks.Inequality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void ModifiedType_WithArgs(AlternateInput input, string[] arguments)
    => AlternateChecks.ModifiedType_WithArgs(input, arguments);

  [Theory, RepeatData]
  public void ModifiedType_WithModifiers(AlternateInput input)
    => AlternateChecks.ModifiedType_WithModifiers(input);

  [Theory, RepeatData]
  public void ModifiedType_WithModifiersAndArgs(AlternateInput input, string[] arguments)
    => AlternateChecks.ModifiedType_WithModifiersAndArgs(input, arguments);

  internal sealed override IAstAbbreviatedChecks<AlternateInput> AbbreviatedChecks => AlternateChecks;

  protected override string InputString(AlternateInput input)
    => $"( {input.Type} )";

  internal IAstObjectAlternateChecks AlternateChecks { get; } = new AstObjectAlternateChecks();
}

internal sealed class AstObjectAlternateChecks
  : AstAbbreviatedChecks<AlternateInput, AlternateAst>
  , IAstObjectAlternateChecks
{
  [SuppressMessage("Style", "IDE0290:Use primary constructor")]
  public AstObjectAlternateChecks()
    : base(CreateAlternate, CloneAlternate)
  { }
  internal delegate ObjBaseAst BaseBy(AlternateInput input);

  private static AlternateAst CloneAlternate(AlternateAst original, AlternateInput input)
    => original with { Name = input.Type };
  internal static AlternateAst CreateAlternate(AlternateInput input)
    => new(AstNulls.At, input.Type, "");

  public void HashCode_WithModifiers(AlternateInput input)
      => HashCode(() => CreateModifiers(input));

  public void String_WithModifiers(AlternateInput input)
    => Text(
      () => CreateModifiers(input),
      $"( {input.Type} [] ? )");

  public void Equality_WithModifiers(AlternateInput input)
    => Equality(() => CreateModifiers(input));

  public void Inequality_WithModifiers(AlternateInput input)
    => InequalityWith(input, () => CreateModifiers(input));

  public void HashCode_WithEnumValue(AlternateInput input, string enumLabel)
      => HashCode(() => CreateEnumValue(input, enumLabel));

  public void String_WithEnumValue(AlternateInput input, string enumLabel)
    => Text(
      () => CreateEnumValue(input, enumLabel),
      $"( {input.Type}.{enumLabel} )");

  public void Equality_WithEnumValue(AlternateInput input, string enumLabel)
    => Equality(() => CreateEnumValue(input, enumLabel));

  public void Inequality_WithEnumValue(AlternateInput input, string enumLabel)
    => InequalityWith(input, () => CreateEnumValue(input, enumLabel));

  public void ModifiedType_WithArgs(AlternateInput input, string[] arguments)
  {
    AlternateAst alternate = CreateAlternate(input) with { Args = arguments.TypeArgs() };
    string expected = $"{input.Type} < {arguments.Joined()} >";

    alternate.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiers(AlternateInput input)
  {
    AlternateAst alternate = CreateModifiers(input);
    string expected = $"{input.Type} [] ?";

    alternate.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiersAndArgs(AlternateInput input, string[] arguments)
  {
    AlternateAst alternate = CreateAlternate(input) with {
      Args = arguments.TypeArgs(),
      Modifiers = TestMods()
    };
    string expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    alternate.ModifiedType.ShouldBe(expected);
  }

  private AlternateAst CreateEnumValue(AlternateInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, input.Type, enumLabel) };

  private AlternateAst CreateModifiers(AlternateInput input)
    => CreateInput(input) with { Modifiers = TestMods() };
}

internal interface IAstObjectAlternateChecks
  : IAstAbbreviatedChecks<AlternateInput>
{
  void HashCode_WithModifiers(AlternateInput input);
  void String_WithModifiers(AlternateInput input);
  void Equality_WithModifiers(AlternateInput input);
  void Inequality_WithModifiers(AlternateInput input);

  void HashCode_WithEnumValue(AlternateInput input, string enumLabel);
  void String_WithEnumValue(AlternateInput input, string enumLabel);
  void Equality_WithEnumValue(AlternateInput input, string enumLabel);
  void Inequality_WithEnumValue(AlternateInput input, string enumLabel);

  void ModifiedType_WithArgs(AlternateInput input, string[] arguments);
  void ModifiedType_WithModifiers(AlternateInput input);
  void ModifiedType_WithModifiersAndArgs(AlternateInput input, string[] arguments);
}
