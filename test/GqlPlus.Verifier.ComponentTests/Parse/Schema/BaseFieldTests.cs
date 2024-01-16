using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseFieldTests
  : BaseAliasedTests<FieldInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string name, string fieldType)
  => FieldChecks.WithModifiers(name, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithModifiersBad_ReturnsFalse(string name, string fieldType)
  => FieldChecks.WithModifiersBad(name, fieldType);

  internal abstract IBaseFieldChecks FieldChecks { get; }

  internal sealed override IBaseAliasedChecks<FieldInput> AliasChecks => FieldChecks;
}

internal sealed class BaseFieldChecks<F, R>
  : BaseAliasedChecks<FieldInput, F>, IBaseFieldChecks
  where F : AstField<R> where R : AstReference<R>
{
  private readonly IFieldFactories<F, R> _factories;

  internal BaseFieldChecks(IFieldFactories<F, R> factories, Parser<F>.D parser)
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
    => _factories.Field(AstNulls.At, field, Reference(fieldType));

  internal R Reference(string type)
    => _factories.Reference(AstNulls.At, type);

  protected internal sealed override F AliasedFactory(FieldInput input)
    => Field(input.Name, input.Type);
  protected internal override string AliasesString(FieldInput input, string aliases)
    => $"{input.Name}{aliases}:{input.Type}";
}

internal interface IBaseFieldChecks
  : IBaseAliasedChecks<FieldInput>
{
  void WithMinimum(string name, string fieldType);
  void WithModifiers(string name, string fieldType);
  void WithModifiersBad(string name, string fieldType);
}

public record struct FieldInput(string Name, string Type);
