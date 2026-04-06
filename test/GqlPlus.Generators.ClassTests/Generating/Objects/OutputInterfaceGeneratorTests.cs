using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class OutputInterfaceGeneratorTests
  : GenerateObjectTestsBase<IGqlpOutputField>
{
  public OutputInterfaceGeneratorTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpOutputField>> TypeGenerator { get; }
    = new OutputInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedImplementation(string contains)
    => _ => result => { };

  protected override ObjFieldBuilder<IGqlpOutputField> MakeField(string name, string type)
    => new OutputFieldBuilder(name, type);
}
