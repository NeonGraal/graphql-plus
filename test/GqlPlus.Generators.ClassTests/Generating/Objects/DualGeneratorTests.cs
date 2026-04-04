
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class DualGeneratorTests
  : GenerateObjectTestsBase<IGqlpDualField>
{
  public DualGeneratorTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpDualField>> TypeGenerator { get; }
    = new DualInterfaceGenerator();

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedImplementation(string contains)
    => _ => result => { };

  protected override ObjFieldBuilder<IGqlpDualField> MakeField(string name, string type)
    => new DualFieldBuilder(name, type);
}
