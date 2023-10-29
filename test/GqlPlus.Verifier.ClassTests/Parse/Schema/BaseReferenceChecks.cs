using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier.ClassTests.Parse.Schema;

internal sealed class BaseReferenceChecks<R>
  : OneChecks<SchemaParser, R>, IBaseReferenceChecks
  where R : AstReference<R>
{
  private readonly IReferenceFactories<R> _factories;

  internal BaseReferenceChecks(IReferenceFactories<R> factories,
    One one, [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(tokens => new SchemaParser(tokens), one, oneExpression)
    => _factories = factories;

  public void WithMinimum(string name)
    => TrueExpected(name, Reference(name));

  public void WithTypeParameter(string name)
    => TrueExpected("$" + name, Reference(name) with { IsTypeParameter = true });

  public void WithTypeArguments(string name, string[] references)
    => TrueExpected(
      name + "<" + references.Joined() + ">",
      Reference(name) with {
        Arguments = references.Select(Reference).ToArray()
      });

  public R Reference(string type)
    => _factories.Reference(AstNulls.At, type);

  public R Reference(string type, string subType)
    => Reference(type) with { Arguments = new[] { Reference(subType) } };
}
