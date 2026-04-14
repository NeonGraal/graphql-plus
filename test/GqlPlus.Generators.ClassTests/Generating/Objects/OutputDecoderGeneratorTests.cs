using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class OutputDecoderGeneratorTests
  : GenerateObjectTestsBase<IAstOutputField>
{
  public OutputDecoderGeneratorTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IAstObject<IAstOutputField>> TypeGenerator { get; }
    = new OutputDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => _ => result => result.ShouldBeNullOrWhiteSpace();

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => result => result.ShouldBeNullOrWhiteSpace();

  internal override ForType ForGeneratedBoth(string contains)
    => _ => result => result.ShouldBeNullOrWhiteSpace();

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => result.ShouldBeNullOrWhiteSpace();

  protected override ObjFieldBuilder<IAstOutputField> MakeField(string name, string type)
    => new OutputFieldBuilder(name, type);
}
