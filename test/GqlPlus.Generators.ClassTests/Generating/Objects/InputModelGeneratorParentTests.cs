using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class InputModelGeneratorParentTests
  : GenerateObjectParentTestsBase<IGqlpInputField>
{
  public InputModelGeneratorParentTests()
    : base(TypeKind.Input)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpInputField>> TypeGenerator { get; }
    = new InputModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedImplementation("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedImplementation(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedImplementation(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedImplementation(contains);

  protected override ObjFieldBuilder<IGqlpInputField> MakeField(string name, string type)
    => new InputFieldBuilder(name, type);
}
