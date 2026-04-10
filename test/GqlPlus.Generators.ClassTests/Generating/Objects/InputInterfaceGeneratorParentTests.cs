using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class InputInterfaceGeneratorParentTests
  : GenerateObjectParentTestsBase<IAstInputField>
{
  public InputInterfaceGeneratorParentTests()
    : base(TypeKind.Input)
  { }

  internal override GenerateForType<IAstObject<IAstInputField>> TypeGenerator { get; }
    = new InputInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
  internal override GqlpBaseType BaseType => GqlpBaseType.Interface;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override ObjFieldBuilder<IAstInputField> MakeField(string name, string type)
    => new InputFieldBuilder(name, type);
}
