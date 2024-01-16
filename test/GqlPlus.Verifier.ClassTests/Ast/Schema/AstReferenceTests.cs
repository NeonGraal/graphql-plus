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

internal sealed class AstReferenceChecks<TReference>
  : AstAbbreviatedChecks<string, TReference>, IAstReferenceChecks<TReference>
  where TReference : AstReference<TReference>
{
  private readonly ReferenceBy _createReference;
  private readonly ArgumentsBy _createArguments;

  internal delegate TReference ReferenceBy(string input);
  internal delegate TReference[] ArgumentsBy(string argument);

  public AstReferenceChecks(ReferenceBy createReference, AstReferenceChecks<TReference>.ArgumentsBy createArguments)
    : base(input => createReference(input))
  {
    _createReference = createReference;
    _createArguments = createArguments;
  }

  public void HashCode_WithIsTypeParameter(string input)
      => HashCode(() => _createReference(input) with { IsTypeParameter = true });

  public void String_WithIsTypeParameter(string input)
    => String(
      () => _createReference(input) with { IsTypeParameter = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParameter(string input)
    => Equality(() => _createReference(input) with { IsTypeParameter = true });

  public void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => _createReference(input) with { IsTypeParameter = isTypeParam },
      false);

  public void HashCode_WithArguments(string input, string argument)
    => HashCode(() => _createReference(input) with { Arguments = _createArguments(argument) });

  public void String_WithArguments(string input, string argument)
    => String(
      () => _createReference(input) with { Arguments = _createArguments(argument) },
      $"( {input} < {argument} > )");

  public void Equality_WithArguments(string input, string argument)
    => Equality(() => _createReference(input) with { Arguments = _createArguments(argument) });

  public void Inequality_BetweenArguments(string input, string argument1, string argument2)
  => InequalityBetween(argument1, argument2,
    argument => _createReference(input) with { Arguments = _createArguments(argument) },
    argument1 == argument2);

  public void FullType_WithDefault(string input)
  {
    var reference = _createReference(input);

    reference.FullType.Should().Be(input);
  }

  public void FullType_WithIsTypeParameter(string input)
  {
    var reference = _createReference(input) with { IsTypeParameter = true };

    reference.FullType.Should().Be("$" + input);
  }

  public void FullType_WithArguments(string input, string argument)
  {
    var reference = _createReference(input) with { Arguments = _createArguments(argument) };

    reference.FullType.Should().Be(input + $" < {argument} >");
  }

  public void FullType_WithIsTypeParameterAndArguments(string input, string argument)
  {
    var reference = _createReference(input) with {
      IsTypeParameter = true,
      Arguments = _createArguments(argument)
    };

    reference.FullType.Should().Be($"${input} < {argument} >");
  }
}

internal interface IAstReferenceChecks<TReference>
  : IAstAbbreviatedChecks<string>
  where TReference : AstReference<TReference>
{
  void HashCode_WithIsTypeParameter(string input);
  void String_WithIsTypeParameter(string input);
  void Equality_WithIsTypeParameter(string input);
  void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1);
  void HashCode_WithArguments(string input, string argument);
  void String_WithArguments(string input, string argument);
  void Equality_WithArguments(string input, string argument);
  void Inequality_BetweenArguments(string input, string argument1, string argument2);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParameter(string input);
  void FullType_WithArguments(string input, string argument);
  void FullType_WithIsTypeParameterAndArguments(string input, string argument);
}
