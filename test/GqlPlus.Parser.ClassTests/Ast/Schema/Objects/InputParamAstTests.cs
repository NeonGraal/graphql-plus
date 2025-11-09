using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputParamAstTests
  : ObjFieldTypeTests<TypeInput>
{
  [Theory, RepeatData]
  public void HashCode_WithDefault(FieldInput input, string def)
      => _checks.HashCode(
        () => new InputParamAst(AstNulls.At, new ObjBaseAst(AstNulls.At, input.Type, "")) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData]
  public void String_WithDefault(FieldInput input, string def)
    => _checks.Text(
      () => new InputParamAst(AstNulls.At, new ObjBaseAst(AstNulls.At, input.Type, "")) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) },
      $"( !Pa {input.Type} =( !k '{def}' ) )");

  [Theory, RepeatData]
  public void Equality_WithDefault(FieldInput input, string def)
    => _checks.Equality(
      () => new InputParamAst(AstNulls.At, new ObjBaseAst(AstNulls.At, input.Type, "")) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData]
  public void Inequality_BetweenDefaults(FieldInput input, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new InputParamAst(AstNulls.At, new ObjBaseAst(AstNulls.At, input.Type, "")) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) },
      def1 == def2);

  private readonly InputParamAstChecks _checks = new(CreateInput, CloneInput);

  internal override IObjFieldTypeChecks<TypeInput> FieldChecks => _checks;

  private static InputParamAst CloneInput(InputParamAst original, TypeInput input)
    => original with { Type = new ObjBaseAst(AstNulls.At, input.Type, "") };
  private static InputParamAst CreateInput(TypeInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, objBase);
}

internal sealed class InputParamAstChecks(
  ObjFieldTypeChecks<TypeInput, InputParamAst>.TypeBy createType,
  BaseAstChecks<InputParamAst>.CloneBy<TypeInput> cloneInput
) : ObjFieldTypeChecks<TypeInput, InputParamAst>(createType, cloneInput)
{
  protected override InputParamAst CreateEnum(TypeInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override InputParamAst WithModifiers(InputParamAst objType)
    => objType with { Modifiers = TestMods() };
}
