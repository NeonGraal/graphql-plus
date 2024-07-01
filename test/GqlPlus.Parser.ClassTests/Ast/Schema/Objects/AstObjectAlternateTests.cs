﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectAlternateTests<TObjBase>
  : AstAbbreviatedTests<AlternateInput>
  where TObjBase : IGqlpObjBase
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(AlternateInput input)
      => AlternateChecks.HashCode_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(AlternateInput input)
    => AlternateChecks.String_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(AlternateInput input)
    => AlternateChecks.Equality_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(AlternateInput input)
    => AlternateChecks.Inequality_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void ModifiedType_WithArguments(AlternateInput input, string[] arguments)
    => AlternateChecks.ModifiedType_WithArguments(input, arguments);

  [Theory, RepeatData(Repeats)]
  public void ModifiedType_WithModifiers(AlternateInput input)
    => AlternateChecks.ModifiedType_WithModifiers(input);

  [Theory, RepeatData(Repeats)]
  public void ModifiedType_WithModifiersAndArguments(AlternateInput input, string[] arguments)
    => AlternateChecks.ModifiedType_WithModifiersAndArguments(input, arguments);

  internal sealed override IAstAbbreviatedChecks<AlternateInput> AbbreviatedChecks => AlternateChecks;

  internal abstract IAstObjectAlternateChecks<TObjBase> AlternateChecks { get; }
}

internal sealed class AstObjectAlternateChecks<TObjAltAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  : AstAbbreviatedChecks<AlternateInput, TObjAltAst>
  , IAstObjectAlternateChecks<TObjBase>
  where TObjAltAst : AstObjAlternate<TObjBase>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  private readonly AlternateBy _createAlternate;
  private readonly BaseBy _createBase;
  private readonly ArgumentsBy _createArguments;

  internal delegate TObjBaseAst BaseBy(AlternateInput input);
  internal delegate TObjAltAst AlternateBy(AlternateInput input, TObjBase refBase);
  internal delegate TObjArgAst[] ArgumentsBy(string[] arguments);

  public AstObjectAlternateChecks(AlternateBy createAlternate, BaseBy createBase, ArgumentsBy createArguments)
    : base(input => createAlternate(input, createBase(input)))
  {
    _createAlternate = createAlternate;
    _createBase = createBase;
    _createArguments = createArguments;
  }

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

  public void ModifiedType_WithArguments(AlternateInput input, string[] arguments)
  {
    TObjAltAst alternate = _createAlternate(input, _createBase(input) with { BaseArguments = _createArguments(arguments) });
    string expected = $"{input.Type} < {arguments.Joined()} >";

    alternate.ModifiedType.Should().Be(expected);
  }

  public void ModifiedType_WithModifiers(AlternateInput input)
  {
    TObjAltAst alternate = CreateModifiers(input);
    string expected = $"{input.Type} [] ?";

    alternate.ModifiedType.Should().Be(expected);
  }

  public void ModifiedType_WithModifiersAndArguments(AlternateInput input, string[] arguments)
  {
    TObjAltAst alternate = _createAlternate(
        input,
        _createBase(input) with { BaseArguments = _createArguments(arguments) }
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
  void ModifiedType_WithArguments(AlternateInput input, string[] arguments);
  void ModifiedType_WithModifiers(AlternateInput input);
  void ModifiedType_WithModifiersAndArguments(AlternateInput input, string[] arguments);
}
