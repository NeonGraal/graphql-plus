using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier.ClassTests.Parse.Schema;

internal sealed class BaseFieldChecks<F, R>
  : OneChecks<SchemaParser, F>, IBaseFieldChecks
  where F : AstField<R> where R : AstReference<R>
{
  private readonly IFieldFactories<F, R> _factories;

  internal BaseFieldChecks(IFieldFactories<F, R> factories,
    One one, [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(tokens => new SchemaParser(tokens), one, oneExpression)
    => _factories = factories;

  public void WithMinimum(string name, string fieldType)
    => TrueExpected(name + ":" + fieldType, Field(name, fieldType));

  public void WithAliases(string name, string fieldType, string[] aliases)
    => TrueExpected(
      name + "[" + aliases.Joined() + "]:" + fieldType,
      Field(name, fieldType) with { Aliases = aliases });

  public void WithModifiers(string name, string fieldType)
    => TrueExpected(
      name + ":" + fieldType + "[]?",
      Field(name, fieldType) with { Modifiers = TestMods() });

  internal F Field(string field, string fieldType)
    => _factories.Field(AstNulls.At, field, "", Reference(fieldType));

  internal F Field(string field, R fieldType)
    => _factories.Field(AstNulls.At, field, "", fieldType);

  internal R Reference(string type)
    => _factories.Reference(AstNulls.At, type);

  internal R Reference(string type, string subType)
    => Reference(type) with { Arguments = new[] { Reference(subType) } };
}
