namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstReferenceTests<TRef>
  : AstAbbreviatedTests<string>
  where TRef : AstReference<TRef>
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

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1)
    => ReferenceChecks.Inequality_BetweenIsTypeParameters(input, isTypeParam1);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArguments(string input, string[] arguments)
    => ReferenceChecks.HashCode_WithArguments(input, arguments);

  [Theory, RepeatData(Repeats)]
  public void String_WithArguments(string input, string[] arguments)
    => ReferenceChecks.String_WithArguments(input, arguments);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArguments(string input, string[] arguments)
    => ReferenceChecks.Equality_WithArguments(input, arguments);

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenArguments(string input, string[] arguments1, string[] arguments2)
    => ReferenceChecks.Inequality_BetweenArguments(input, arguments1, arguments2);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithDefault(string input)
    => ReferenceChecks.FullType_WithDefault(input);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithIsTypeParameter(string input)
    => ReferenceChecks.FullType_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithArguments(string input, string[] arguments)
    => ReferenceChecks.FullType_WithArguments(input, arguments);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithIsTypeParameterAndArguments(string input, string[] arguments)
    => ReferenceChecks.FullType_WithIsTypeParameterAndArguments(input, arguments);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => ReferenceChecks;

  internal abstract IAstReferenceChecks<TRef> ReferenceChecks { get; }
}

internal sealed class AstReferenceChecks<TRef>
  : AstAbbreviatedChecks<string, TRef>, IAstReferenceChecks<TRef>
  where TRef : AstReference<TRef>
{
  private readonly ReferenceBy _createReference;
  private readonly ArgumentsBy _createArguments;

  internal delegate TRef ReferenceBy(string input);
  internal delegate TRef[] ArgumentsBy(string[] argument);

  public AstReferenceChecks(ReferenceBy createReference, AstReferenceChecks<TRef>.ArgumentsBy createArguments)
    : base(input => createReference(input))
  {
    _createReference = createReference;
    _createArguments = createArguments;
  }

  public void HashCode_WithIsTypeParameter(string input)
      => HashCode(() => _createReference(input) with { IsTypeParameter = true });

  public void String_WithIsTypeParameter(string input)
    => Text(
      () => _createReference(input) with { IsTypeParameter = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParameter(string input)
    => Equality(() => _createReference(input) with { IsTypeParameter = true });

  public void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => _createReference(input) with { IsTypeParameter = isTypeParam },
      false);

  public void HashCode_WithArguments(string input, string[] arguments)
    => HashCode(() => _createReference(input) with { Arguments = _createArguments(arguments) });

  public void String_WithArguments(string input, string[] arguments)
    => Text(
      () => _createReference(input) with { Arguments = _createArguments(arguments) },
      $"( {input} < {arguments.Joined()} > )");

  public void Equality_WithArguments(string input, string[] arguments)
    => Equality(() => _createReference(input) with { Arguments = _createArguments(arguments) });

  public void Inequality_BetweenArguments(string input, string[] arguments1, string[] arguments2)
  => InequalityBetween(arguments1, arguments2,
    arguments => _createReference(input) with { Arguments = _createArguments(arguments) },
    arguments1.OrderedEqual(arguments2));

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

  public void FullType_WithArguments(string input, string[] arguments)
  {
    var reference = _createReference(input) with { Arguments = _createArguments(arguments) };

    reference.FullType.Should().Be(input + $" < {arguments.Joined()} >");
  }

  public void FullType_WithIsTypeParameterAndArguments(string input, string[] arguments)
  {
    var reference = _createReference(input) with {
      IsTypeParameter = true,
      Arguments = _createArguments(arguments)
    };

    reference.FullType.Should().Be($"${input} < {arguments.Joined()} >");
  }
}

internal interface IAstReferenceChecks<TRef>
  : IAstAbbreviatedChecks<string>
  where TRef : AstReference<TRef>
{
  void HashCode_WithIsTypeParameter(string input);
  void String_WithIsTypeParameter(string input);
  void Equality_WithIsTypeParameter(string input);
  void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1);
  void HashCode_WithArguments(string input, string[] arguments);
  void String_WithArguments(string input, string[] arguments);
  void Equality_WithArguments(string input, string[] arguments);
  void Inequality_BetweenArguments(string input, string[] arguments1, string[] arguments2);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParameter(string input);
  void FullType_WithArguments(string input, string[] arguments);
  void FullType_WithIsTypeParameterAndArguments(string input, string[] arguments);
}
