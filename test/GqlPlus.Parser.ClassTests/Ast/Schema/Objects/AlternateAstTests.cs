namespace GqlPlus.Ast.Schema.Objects;

public partial class AlternateAstTests
{
  [CheckTests(Inherited = true)]
  internal IObjEnumChecks<TypeInput> EnumChecks { get; } = new AlternateEnumChecks();

  [CheckTests]
  internal IModifiersChecks<TypeInput> ModifiersChecks { get; } = new AlternateModifiersChecks();

  [CheckTests]
  internal ICloneChecks<TypeInput> CloneChecks { get; } = new CloneChecks<TypeInput, AlternateAst>(
    CreateAlternate,
    (original, input) => original with { Name = input.Type });

  internal static AlternateAst CreateAlternate(TypeInput input)
    => new(AstNulls.At, input.Type, "");
}

internal sealed class AlternateEnumChecks()
  : ObjEnumChecks<TypeInput, AlternateAst>(AlternateAstTests.CreateAlternate)
{
  protected override string InputString(TypeInput input)
    => $"( {input.Type} )";

  protected override AlternateAst CreateEnum(TypeInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, input.Type, enumLabel) };
}

internal sealed class AlternateModifiersChecks()
  : ModifiersChecks<TypeInput, AlternateAst>(
      AlternateAstTests.CreateAlternate,
      ast => ast with { Modifiers = TestMods() })
{
  protected override string InputString(TypeInput input)
    => $"( {input.Type} )";
}
