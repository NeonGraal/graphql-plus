using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class EnumDecoderGeneratorTests
  : GenerateSimpleTestsBase<IGqlpEnum>
{
  private readonly EnumDecoderGenerator _generator;

  public EnumDecoderGeneratorTests()
    => _generator = new EnumDecoderGenerator();

  internal override GenerateForType<IGqlpEnum> TypeGenerator => _generator;

  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedDecoder("internal class " + TestPrefix + name + "Decoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  protected override void MakeItems(SimpleBuilder<IGqlpEnum> builder, params string[] items)
    => ((EnumBuilder)builder).WithLabels(items);
  protected override SimpleBuilder<IGqlpEnum> MakeSimple(string name)
    => new EnumBuilder(name);
}
