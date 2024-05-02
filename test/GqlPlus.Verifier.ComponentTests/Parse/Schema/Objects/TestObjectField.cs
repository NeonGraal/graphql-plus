using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public abstract class TestObjectField
  : TestAliased<FieldInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string name, string fieldType)
  => FieldChecks.WithModifiers(name, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithModifiersBad_ReturnsFalse(string name, string fieldType)
  => FieldChecks.WithModifiersBad(name, fieldType);

  internal abstract ICheckObjectField FieldChecks { get; }

  internal sealed override ICheckAliased<FieldInput> AliasChecks => FieldChecks;
}

internal sealed class CheckObjectField<TField, TRef>
  : CheckAliased<FieldInput, TField>, ICheckObjectField
  where TField : AstObjectField<TRef> where TRef : AstReference<TRef>
{
  private readonly IObjectFieldFactories<TField, TRef> _factories;

  internal CheckObjectField(IObjectFieldFactories<TField, TRef> factories, Parser<TField>.D parser)
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

  internal TField Field(string field, string fieldType)
    => _factories.Field(AstNulls.At, field, Reference(fieldType));

  internal TRef Reference(string type)
    => _factories.Reference(AstNulls.At, type);

  protected internal sealed override TField NamedFactory(FieldInput input)
    => Field(input.Name, input.Type);
  protected internal override string AliasesString(FieldInput input, string aliases)
    => $"{input.Name}{aliases}:{input.Type}";
}

internal interface ICheckObjectField
  : ICheckAliased<FieldInput>
{
  void WithMinimum(string name, string fieldType);
  void WithModifiers(string name, string fieldType);
  void WithModifiersBad(string name, string fieldType);
}
