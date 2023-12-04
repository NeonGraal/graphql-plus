using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class BaseReferenceParsedChecks<R>
  : OneChecksParser<R>, IBaseReferenceChecks
  where R : AstReference<R>
{
  private readonly IReferenceFactories<R> _factories;

  public BaseReferenceParsedChecks(IReferenceFactories<R> factories, Parser<R>.D parser)
    : base(parser)
    => _factories = factories;

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
        Arguments = references.Select(Reference).ToArray()
      });

  public void WithTypeArgumentsBad(string name, string[] references)
    => False(name + "<" + references.Joined());

  public void WithTypeArgumentsNone(string name)
    => False(name + "<>");

  public R Reference(string type)
    => _factories.Reference(AstNulls.At, type);
}
