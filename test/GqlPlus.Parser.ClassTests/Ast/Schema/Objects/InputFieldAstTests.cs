using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public partial class InputFieldAstTests
{
  [CheckTests, CheckTests(typeof(IAstNamedChecks<FieldInput>))]
  internal IAstAliasedChecks<FieldInput> AliasedChecks { get; }
    = new InputFieldAstChecks();

  [CheckTests(Inherited = true)]
  internal IObjFieldTypeChecks<FieldInput> FieldTypeChecks { get; }
    = new InputFieldAstTypeChecks();

  [CheckTests]
  internal IModifiersChecks<FieldInput> ModifiersChecks { get; }
    = new ObjFieldModifiersChecks<FieldInput, InputFieldAst>(
      CreateInput,
      ast => ast with { Modifiers = TestMods() });

  [CheckTests]
  internal ICloneChecks<FieldInput> CloneChecks { get; } = new ObjFieldCloneChecks<FieldInput, InputFieldAst>(
    CreateInput,
    (original, input) => original with { Name = input.Name });

  internal static InputFieldAst CreateInput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);
}

internal sealed class InputFieldAstChecks()
  : AstObjectFieldChecks<InputFieldAst>(InputFieldAstTests.CreateInput)
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";
}

internal sealed class InputFieldAstTypeChecks()
  : InputFieldTypeChecks<FieldInput, InputFieldAst>(InputFieldAstTests.CreateInput)
{
  protected override InputFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override string DefaultString(FieldInput input, string def)
    => $"( !IF {input.Name} : {input.Type} =( !k '{def}' ) )";
  protected override InputFieldAst WithDefault(InputFieldAst objType, string def)
    => objType with { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) };
  protected override InputFieldAst WithModifiers(InputFieldAst objType)
    => objType with { Modifiers = TestMods() };

  protected override string InputString(FieldInput input)
    => $"( !IF {input.Name} : {input.Type} )";
}
