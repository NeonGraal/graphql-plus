using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Parse.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class BaseFieldChecks<F, R>
  : BaseAliasedChecks<FieldInput, F>, IBaseFieldChecks
  where F : AstField<R> where R : AstReference<R>
{
  private readonly IFieldFactories<F, R> _factories;

  internal BaseFieldChecks(IFieldFactories<F, R> factories,
    One one, [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(one, oneExpression)
    => _factories = factories;

  public void WithMinimum(string name, string fieldType)
    => TrueExpected(name + ":" + fieldType, Field(name, fieldType));

  public void WithModifiers(string name, string fieldType)
    => TrueExpected(
      name + ":" + fieldType + "[]?",
      Field(name, fieldType) with { Modifiers = TestMods() });

  public void WithModifiersBad(string name, string fieldType)
    => False(name + ":" + fieldType + "[?");

  internal F Field(string field, string fieldType)
    => _factories.Field(AstNulls.At, field, "", Reference(fieldType));

  internal F Field(string field, R fieldType)
    => _factories.Field(AstNulls.At, field, "", fieldType);

  internal R Reference(string type)
    => _factories.Reference(AstNulls.At, type);

  internal R Reference(string type, string subType)
    => Reference(type) with { Arguments = new[] { Reference(subType) } };

  protected internal override F AliasedFactory(FieldInput input)
    => Field(input.Name, input.Type);
  protected internal override string AliasesString(FieldInput input, string aliases)
    => $"{input.Name}{aliases}:{input.Type}";
}
