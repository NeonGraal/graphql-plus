namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstReferenceTests<TReference>
  : AstAbbreviatedTests<string>
  where TReference : AstReference<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithIsTypeParameter(string input)
      => ReferenceChecks.HashCode_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void String_WithIsTypeParameter(string input)
    => ReferenceChecks.String_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithIsTypeParameter(string input)
    => ReferenceChecks.Equality_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1)
    => ReferenceChecks.Inequality_BetweenIsTypeParameters(input, isTypeParam1);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArguments(string input, string argument)
    => ReferenceChecks.HashCode_WithArguments(input, argument);

  [Theory, RepeatData(Repeats)]
  public void String_WithArguments(string input, string argument)
    => ReferenceChecks.String_WithArguments(input, argument);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArguments(string input, string argument)
    => ReferenceChecks.Equality_WithArguments(input, argument);

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenArguments(string input, string argument1, string argument2)
    => ReferenceChecks.Inequality_BetweenArguments(input, argument1, argument2);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithDefault(string input)
    => ReferenceChecks.FullType_WithDefault(input);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithIsTypeParameter(string input)
    => ReferenceChecks.FullType_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithArguments(string input, string argument)
    => ReferenceChecks.FullType_WithArguments(input, argument);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithIsTypeParameterAndArguments(string input, string argument)
    => ReferenceChecks.FullType_WithIsTypeParameterAndArguments(input, argument);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => ReferenceChecks;

  internal abstract IAstReferenceChecks<TReference> ReferenceChecks { get; }
}
