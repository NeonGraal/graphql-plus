using GqlPlus.Abstractions.Schema;
using Microsoft.AspNetCore.Components.Forms;

namespace GqlPlus.Ast.Schema.Objects;

public class InputFieldAstTests
  : AstObjectFieldTests
{
  [Theory, RepeatData]
  public void HashCode_WithDefault(FieldInput input, string def)
      => _checks.HashCode(
        () => new InputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData]
  public void String_WithDefault(FieldInput input, string def)
    => _checks.Text(
      () => new InputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) },
      $"( !IF {input.Name} : {input.Type} =( !k '{def}' ) )");

  [Theory, RepeatData]
  public void Equality_WithDefault(FieldInput input, string def)
    => _checks.Equality(
      () => new InputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData]
  public void Inequality_BetweenDefaults(FieldInput input, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new InputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) },
      def1 == def2);

  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<InputFieldAst> _checks = new(CreateInput, CloneInput);

  private static InputFieldAst CloneInput(InputFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static InputFieldAst CreateInput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IAstObjectFieldChecks FieldChecks => _checks;
}

public class InputFieldTypeTests
    : ObjFieldTypeTests<FieldInput>
{
  private readonly InputFieldTypeChecks _checks = new(CreateInput, CloneInput);

  private static InputFieldAst CloneInput(InputFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static InputFieldAst CreateInput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IObjFieldTypeChecks<FieldInput> FieldChecks => _checks;

  protected override string InputString(FieldInput input)
    => $"( !IF {input.Name} : {input.Type} )";
}


internal sealed class InputFieldTypeChecks(
  ObjFieldTypeChecks<FieldInput, InputFieldAst>.TypeBy createType,
  BaseAstChecks<InputFieldAst>.CloneBy<FieldInput> cloneInput
) : ObjFieldTypeChecks<FieldInput, InputFieldAst>(createType, cloneInput)
{
  protected override InputFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override InputFieldAst WithModifiers(InputFieldAst objType)
    => objType with { Modifiers = TestMods() };
}
