using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class OutputModelGeneratorParentTests
  : GenerateObjectParentTestsBase<IAstOutputField>
{
  public OutputModelGeneratorParentTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IAstObject<IAstOutputField>> TypeGenerator { get; }
    = new OutputModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedModel(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedModel(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedModel(contains);

  protected override ObjFieldBuilder<IAstOutputField> MakeField(string name, string type)
    => new OutputFieldBuilder(name, type);
}
