using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Ast.Schema.Objects;

public class ObjAltAstTests
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
  : AstAbbreviatedChecks<AlternateInput, ObjAltAst>
  , IAstObjectAlternateChecks
{
  [SuppressMessage("Style", "IDE0290:Use primary constructor")]
  public AstObjectAlternateChecks()
    : base(AlternateBy)
  { }

  internal delegate ObjBaseAst BaseBy(AlternateInput input);
  internal static ObjAltAst AlternateBy(AlternateInput input)
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

  public void ModifiedType_WithArgs(AlternateInput input, string[] arguments)
  {
    ObjAltAst alternate = AlternateBy(input) with { Args = arguments.ObjTypeArgs() };
    string expected = $"{input.Type} < {arguments.Joined()} >";

    alternate.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiers(AlternateInput input)
  {
    ObjAltAst alternate = CreateModifiers(input);
    string expected = $"{input.Type} [] ?";

    alternate.ModifiedType.ShouldBe(expected);
  }

  public void ModifiedType_WithModifiersAndArgs(AlternateInput input, string[] arguments)
  {
    ObjAltAst alternate = AlternateBy(input) with {
      Args = arguments.ObjTypeArgs(),
      Modifiers = TestMods()
    };
    string expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    alternate.ModifiedType.ShouldBe(expected);
  }

  private ObjAltAst CreateModifiers(AlternateInput input)
    => CreateInput(input) with { Modifiers = TestMods() };
}

internal interface IAstObjectAlternateChecks
  : IAstAbbreviatedChecks<AlternateInput>
{
  void HashCode_WithModifiers(AlternateInput input);
  void String_WithModifiers(AlternateInput input);
  void Equality_WithModifiers(AlternateInput input);
  void Inequality_WithModifiers(AlternateInput input);
  void ModifiedType_WithArgs(AlternateInput input, string[] arguments);
  void ModifiedType_WithModifiers(AlternateInput input);
  void ModifiedType_WithModifiersAndArgs(AlternateInput input, string[] arguments);
}
