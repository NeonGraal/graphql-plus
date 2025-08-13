using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class TestObjectField<TObjField>(
  ICheckObjectField<TObjField> fieldChecks
) : BaseAliasedTests<FieldInput, TObjField>(fieldChecks)
  where TObjField : IGqlpObjField
{
  [Theory]
  [RepeatInlineData(Repeats, "Boolean")]
  [RepeatInlineData(Repeats, "Number")]
  [RepeatInlineData(Repeats, "String")]
  [RepeatInlineData(Repeats, "^")]
  [RepeatInlineData(Repeats, "0")]
  [RepeatInlineData(Repeats, "*")]
  public void WithSimple_ReturnsCorrectAst(string fieldType, string name)
  => fieldChecks.WithMinimum(name, fieldType);

  [Theory, RepeatData]
  public void WithModifiers_ReturnsCorrectAst(string name, string fieldType)
  => fieldChecks.WithModifiers(name, fieldType);

  [Theory, RepeatData]
  public void WithModifiersBad_ReturnsFalse(string name, string fieldType)
  => fieldChecks.WithModifiersBad(name, fieldType);
}

internal class CheckObjectField<TObjField, TObjFieldAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  : BaseAliasedChecks<FieldInput, TObjFieldAst, TObjField>
  , ICheckObjectField<TObjField>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
{
  private readonly IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst> _factories;

  internal CheckObjectField(IObjectFieldFactories<TObjFieldAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst> factories, Parser<TObjField>.D parser)
    : base(parser)
    => _factories = factories;

  public void WithMinimum(string name, string fieldType)
    => TrueExpected(name + ":" + fieldType, Field(name, fieldType));

  public void WithModifiers(string name, string fieldType)
    => TrueExpected(
      name + ":" + fieldType + "[]?",
      Field(name, fieldType) with { Modifiers = TestMods() });

  public void WithModifiersBad(string name, string fieldType)
    => FalseExpected(name + ":" + fieldType + "[?");

  internal TObjFieldAst Field(string field, string fieldType)
    => _factories.ObjField(AstNulls.At, field, ObjBase(fieldType));

  internal TObjBase ObjBase(string type)
    => _factories.ObjBase(AstNulls.At, type);

  protected internal sealed override TObjFieldAst NamedFactory(FieldInput input)
    => Field(input.Name, input.Type);
  protected internal override string AliasesString(FieldInput input, string aliases)
    => $"{input.Name}{aliases}:{input.Type}";
}

public interface ICheckObjectField<TObjField>
  : IBaseAliasedChecks<FieldInput, TObjField>
  where TObjField : IGqlpObjField
{
  void WithMinimum(string name, string fieldType);
  void WithModifiers(string name, string fieldType);
  void WithModifiersBad(string name, string fieldType);
}
