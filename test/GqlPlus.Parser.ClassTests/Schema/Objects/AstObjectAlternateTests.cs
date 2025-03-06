using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public abstract class AstObjectAlternateTests<TObjBase>
  : AstAbbreviatedTests<AlternateInput>
  where TObjBase : IGqlpObjBase
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

  internal abstract IAstObjectAlternateChecks<TObjBase> AlternateChecks { get; }
}

internal sealed class AstObjectAlternateChecks<TObjAltAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>(
  AstObjectAlternateChecks<TObjAltAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>.AlternateBy createAlternate,
  AstObjectAlternateChecks<TObjAltAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>.BaseBy createBase,
  AstObjectAlternateChecks<TObjAltAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>.ArgsBy createArgs
) : AstAbbreviatedChecks<AlternateInput, TObjAltAst>(input => createAlternate(input, createBase(input)))
  , IAstObjectAlternateChecks<TObjBase>
  where TObjAltAst : AstObjAlternate<TObjBase>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
{
  private readonly AlternateBy _createAlternate = createAlternate;
  private readonly BaseBy _createBase = createBase;
  private readonly ArgsBy _createArgs = createArgs;

  internal delegate TObjBaseAst BaseBy(AlternateInput input);
  internal delegate TObjAltAst AlternateBy(AlternateInput input, TObjBase refBase);
  internal delegate TObjArgAst[] ArgsBy(string[] arguments);

  public void HashCode_WithModifiers(AlternateInput input)
      => HashCode(() => CreateModifiers(input));

  public void String_WithModifiers(AlternateInput input)
    => Text(
      () => CreateModifiers(input),
      $"( !{Abbr} {input.Type} [] ? )");

  public void Equality_WithModifiers(AlternateInput input)
    => Equality(() => CreateModifiers(input));

  public void Inequality_WithModifiers(AlternateInput input)
    => InequalityWith(input, () => CreateModifiers(input));

  public void ModifiedType_WithArgs(AlternateInput input, string[] arguments)
  {
    TObjAltAst alternate = _createAlternate(input, _createBase(input) with { BaseArgs = _createArgs(arguments) });
    string expected = $"{input.Type} < {arguments.Joined()} >";

    alternate.ModifiedType.Should().Be(expected);
  }

  public void ModifiedType_WithModifiers(AlternateInput input)
  {
    TObjAltAst alternate = CreateModifiers(input);
    string expected = $"{input.Type} [] ?";

    alternate.ModifiedType.Should().Be(expected);
  }

  public void ModifiedType_WithModifiersAndArgs(AlternateInput input, string[] arguments)
  {
    TObjAltAst alternate = _createAlternate(
        input,
        _createBase(input) with { BaseArgs = _createArgs(arguments) }
      ) with { Modifiers = TestMods() };
    string expected = $"{input.Type} < {arguments.Joined()} > [] ?";

    alternate.ModifiedType.Should().Be(expected);
  }

  private TObjAltAst CreateModifiers(AlternateInput input)
    => CreateInput(input) with { Modifiers = TestMods() };
}

internal interface IAstObjectAlternateChecks<TObjBase>
  : IAstAbbreviatedChecks<AlternateInput>
  where TObjBase : IGqlpObjBase
{
  void HashCode_WithModifiers(AlternateInput input);
  void String_WithModifiers(AlternateInput input);
  void Equality_WithModifiers(AlternateInput input);
  void Inequality_WithModifiers(AlternateInput input);
  void ModifiedType_WithArgs(AlternateInput input, string[] arguments);
  void ModifiedType_WithModifiers(AlternateInput input);
  void ModifiedType_WithModifiersAndArgs(AlternateInput input, string[] arguments);
}
