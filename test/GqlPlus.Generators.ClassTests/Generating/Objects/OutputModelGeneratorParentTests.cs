using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class OutputModelGeneratorParentTests
  : GenerateObjectParentTestsBase<IGqlpOutputField>
{
  public OutputModelGeneratorParentTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpOutputField>> TypeGenerator { get; }
    = new OutputModelGenerator();
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

  protected override ObjFieldBuilder<IGqlpOutputField> MakeField(string name, string type)
    => new OutputFieldBuilder(name, type);
}
