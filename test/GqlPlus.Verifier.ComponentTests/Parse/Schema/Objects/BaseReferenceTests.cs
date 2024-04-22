using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public abstract class BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => ReferenceChecks.WithMinimum(name);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameter_ReturnsCorrectAst(string name)
  => ReferenceChecks.WithTypeParameter(name);

  [Fact]
  public void WithTypeParameterBad_ReturnsFalse()
  => ReferenceChecks.WithTypeParameterBad();

  [Theory, RepeatData(Repeats)]
  public void WithTypeArguments_ReturnsCorrectAst(string name, string[] references)
  => ReferenceChecks.WithTypeArguments(name, references);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsBad_ReturnsCorrectAst(string name, string[] references)
  => ReferenceChecks.WithTypeArgumentsBad(name, references);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsNone_ReturnsFalse(string name)
  => ReferenceChecks.WithTypeArgumentsNone(name);

  internal abstract IBaseReferenceChecks ReferenceChecks { get; }
}

internal sealed class BaseReferenceParsedChecks<R>(
  IReferenceFactories<R> factories, Parser<R>.D parser
) : OneChecksParser<R>(parser), IBaseReferenceChecks
  where R : AstReference<R>
{
  private readonly IReferenceFactories<R> _factories = factories;

  public void WithMinimum(string name)
    => TrueExpected(name, Reference(name));

  public void WithTypeParameter(string name)
    => TrueExpected("$" + name, Reference(name) with { IsTypeParameter = true });

  public void WithTypeParameterBad()
    => False("$");

  public void WithTypeArguments(string name, string[] references)
    => TrueExpected(
      name + "<" + references.Joined() + ">",
      Reference(name) with {
        Arguments = [.. references.Select(Reference)]
      });

  public void WithTypeArgumentsBad(string name, string[] references)
    => False(name + "<" + references.Joined());

  public void WithTypeArgumentsNone(string name)
    => False(name + "<>");

  public R Reference(string type)
    => _factories.Reference(AstNulls.At, type);
}

public interface IBaseReferenceChecks
{
  void WithMinimum(string name);
  void WithTypeParameter(string name);
  void WithTypeParameterBad();
  void WithTypeArguments(string name, string[] references);
  void WithTypeArgumentsBad(string name, string[] references);
  void WithTypeArgumentsNone(string name);
}
