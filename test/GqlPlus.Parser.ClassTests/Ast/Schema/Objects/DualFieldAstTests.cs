using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public partial class DualFieldAstTests
{
  [CheckTests, CheckTests(typeof(IAstNamedChecks<FieldInput>))]
  internal IAstAliasedChecks<FieldInput> FieldChecks { get; }
    = new DualFieldAstChecks();

  [CheckTests(Inherited = true)]
  internal IObjFieldTypeChecks<FieldInput> FieldTypeChecks { get; }
    = new DualFieldAstTypeChecks();

  [CheckTests]
  internal IModifiersChecks<FieldInput> ModifiersChecks { get; }
    = new ObjFieldModifiersChecks<FieldInput, DualFieldAst>(
      CreateDual,
      ast => ast with { Modifiers = TestMods() });

  [CheckTests]
  internal ICloneChecks<FieldInput> CloneChecks { get; } = new ObjFieldCloneChecks<FieldInput, DualFieldAst>(
    CreateDual,
    (original, input) => original with { Name = input.Name });

  internal static DualFieldAst CreateDual(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);
}

internal sealed class DualFieldAstChecks()
  : AstObjectFieldChecks<DualFieldAst>(DualFieldAstTests.CreateDual)
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";
}

internal sealed class DualFieldAstTypeChecks()
  : ObjFieldTypeChecks<FieldInput, DualFieldAst>(DualFieldAstTests.CreateDual)
{
  protected override DualFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override string InputString(FieldInput input)
    => $"( !DF {input.Name} : {input.Type} )";
  protected override DualFieldAst WithModifiers(DualFieldAst objType)
    => objType with { Modifiers = TestMods() };
}
