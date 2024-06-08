using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class TestObjectField
  : BaseAliasedTests<FieldInput>
{
  [Theory]
  [RepeatInlineData(Repeats, "Boolean")]
  [RepeatInlineData(Repeats, "Number")]
  [RepeatInlineData(Repeats, "String")]
  [RepeatInlineData(Repeats, "^")]
  [RepeatInlineData(Repeats, "0")]
  [RepeatInlineData(Repeats, "*")]
  public void WithSimple_ReturnsCorrectAst(string fieldType, string name)
  => FieldChecks.WithMinimum(name, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string name, string fieldType)
  => FieldChecks.WithModifiers(name, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithModifiersBad_ReturnsFalse(string name, string fieldType)
  => FieldChecks.WithModifiersBad(name, fieldType);

  internal abstract ICheckObjectField FieldChecks { get; }

  internal sealed override IBaseAliasedChecks<FieldInput> AliasChecks => FieldChecks;
}

internal sealed class CheckObjectField<TObjField, TObjBase, TObjBaseAst>
  : BaseAliasedChecks<FieldInput, TObjField>
  , ICheckObjectField
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>, TObjBase
{
  private readonly IObjectFieldFactories<TObjField, TObjBase, TObjBaseAst> _factories;

  internal CheckObjectField(IObjectFieldFactories<TObjField, TObjBase, TObjBaseAst> factories, Parser<TObjField>.D parser)
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

  internal TObjField Field(string field, string fieldType)
    => _factories.ObjField(AstNulls.At, field, ObjBase(fieldType));

  internal TObjBase ObjBase(string type)
    => _factories.ObjBase(AstNulls.At, type);

  protected internal sealed override TObjField NamedFactory(FieldInput input)
    => Field(input.Name, input.Type);
  protected internal override string AliasesString(FieldInput input, string aliases)
    => $"{input.Name}{aliases}:{input.Type}";
}

internal interface ICheckObjectField
  : IBaseAliasedChecks<FieldInput>
{
  void WithMinimum(string name, string fieldType);
  void WithModifiers(string name, string fieldType);
  void WithModifiersBad(string name, string fieldType);
}
