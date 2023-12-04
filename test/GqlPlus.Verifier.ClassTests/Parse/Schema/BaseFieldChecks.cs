using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class BaseFieldParserChecks<F, R>
  : BaseAliasedParserChecks<FieldInput, F>, IBaseFieldChecks
  where F : AstField<R> where R : AstReference<R>
{
  private readonly IFieldFactories<F, R> _factories;

  internal BaseFieldParserChecks(IFieldFactories<F, R> factories, Parser<F>.D parser)
    : base(parser)
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

  internal R Reference(string type)
    => _factories.Reference(AstNulls.At, type);

  protected internal override F AliasedFactory(FieldInput input)
    => Field(input.Name, input.Type);
  protected internal override string AliasesString(FieldInput input, string aliases)
    => $"{input.Name}{aliases}:{input.Type}";
}
