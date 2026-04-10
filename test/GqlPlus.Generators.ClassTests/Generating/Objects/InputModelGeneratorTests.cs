using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class InputModelGeneratorTests
  : GenerateObjectTestsBase<IAstInputField>
{
  public InputModelGeneratorTests()
    : base(TypeKind.Input)
  { }

  internal override GenerateForType<IAstObject<IAstInputField>> TypeGenerator { get; }
    = new InputModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedModel("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedModel(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedModel(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedModel(contains);

  protected override ObjFieldBuilder<IAstInputField> MakeField(string name, string type)
    => new InputFieldBuilder(name, type);
}
