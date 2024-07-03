using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectArgumentTests<TObjArg>
  : AstAbbreviatedTests<string>
  where TObjArg : IGqlpObjArgument
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithIsTypeParameter(string input)
      => ObjArgumentChecks.HashCode_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void String_WithIsTypeParameter(string input)
    => ObjArgumentChecks.String_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithIsTypeParameter(string input)
    => ObjArgumentChecks.Equality_WithIsTypeParameter(input);

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1)
    => ObjArgumentChecks.Inequality_BetweenIsTypeParameters(input, isTypeParam1);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithDefault(string input)
    => ObjArgumentChecks.FullType_WithDefault(input);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithIsTypeParameter(string input)
    => ObjArgumentChecks.FullType_WithIsTypeParameter(input);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => ObjArgumentChecks;

  internal abstract IAstObjArgumentChecks<TObjArg> ObjArgumentChecks { get; }
}

internal sealed class AstObjArgumentChecks<TObjArg, TObjArgAst>(
  AstObjArgumentChecks<TObjArg, TObjArgAst>.ArgumentBy createArgument
) : AstAbbreviatedChecks<string, TObjArg>(input => createArgument(input))
  , IAstObjArgumentChecks<TObjArg>
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  internal delegate TObjArgAst ArgumentBy(string input);

  public void HashCode_WithIsTypeParameter(string input)
      => HashCode(() => createArgument(input) with { IsTypeParameter = true });

  public void String_WithIsTypeParameter(string input)
    => Text(
      () => createArgument(input) with { IsTypeParameter = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParameter(string input)
    => Equality(() => createArgument(input) with { IsTypeParameter = true });

  public void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => createArgument(input) with { IsTypeParameter = isTypeParam },
      false);

  public void FullType_WithDefault(string input)
  {
    TObjArg objArgument = createArgument(input);

    objArgument.FullType.Should().Be(input);
  }

  public void FullType_WithIsTypeParameter(string input)
  {
    TObjArg objArgument = createArgument(input) with { IsTypeParameter = true };

    objArgument.FullType.Should().Be("$" + input);
  }
}

internal interface IAstObjArgumentChecks<TObjArg>
  : IAstAbbreviatedChecks<string>
  where TObjArg : IGqlpObjArgument
{
  void HashCode_WithIsTypeParameter(string input);
  void String_WithIsTypeParameter(string input);
  void Equality_WithIsTypeParameter(string input);
  void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParameter(string input);
}
