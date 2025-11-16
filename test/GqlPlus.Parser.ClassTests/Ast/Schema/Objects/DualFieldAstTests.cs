using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualFieldAstTests
  : AstObjFieldBaseTests
{
  internal override IAstObjectFieldChecks FieldChecks { get; }
    = new DualFieldAstChecks();
}

internal sealed class DualFieldAstChecks()
  : AstObjectFieldChecks<DualFieldAst>(DualFieldFactory.Create)
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";
}

public class DualFieldAstTypeTests
    : ObjFieldTypeBaseTests<FieldInput>
{
  internal override IObjFieldTypeChecks<FieldInput> FieldChecks { get; }
    = new DualFieldAstTypeChecks();
}

internal sealed class DualFieldAstTypeChecks()
  : ObjFieldTypeChecks<FieldInput, DualFieldAst>(DualFieldFactory.Create)
{
  protected override DualFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override string InputString(FieldInput input)
    => $"( !DF {input.Name} : {input.Type} )";
  protected override DualFieldAst WithModifiers(DualFieldAst objType)
    => objType with { Modifiers = TestMods() };
}

internal static class DualFieldFactory
{
  internal static DualFieldAst Clone(DualFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  internal static DualFieldAst Create(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);
}
