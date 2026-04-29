using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class OutputInterfaceGeneratorTests
  : GenerateObjectTestsBase<IAstOutputField>
{
  public OutputInterfaceGeneratorTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IAstObject<IAstOutputField>> TypeGenerator { get; }
    = new OutputInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
  internal override GqlpBaseType BaseType => GqlpBaseType.Interface;

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override ObjFieldBuilder<IAstOutputField> MakeField(string name, string type)
    => new OutputFieldBuilder(name, type);
}
