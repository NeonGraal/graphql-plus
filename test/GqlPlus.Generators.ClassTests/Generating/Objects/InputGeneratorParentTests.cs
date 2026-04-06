using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class InputGeneratorParentTests
  : GenerateObjectParentTestsBase<IGqlpInputField>
{
  public InputGeneratorParentTests()
    : base(TypeKind.Input)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpInputField>> TypeGenerator { get; }
    = new InputInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedImplementation(string contains)
    => _ => result => { };

  protected override ObjFieldBuilder<IGqlpInputField> MakeField(string name, string type)
    => new InputFieldBuilder(name, type);
}
