using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class EnumDecoderGeneratorTests
  : GenerateSimpleTestsBase<IAstEnum, EnumLabelInput>
{
  private readonly EnumDecoderGenerator _generator;

  public EnumDecoderGeneratorTests()
    => _generator = new EnumDecoderGenerator();

  internal override GenerateForType<IAstEnum> TypeGenerator => _generator;

  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  protected override void MakeItems(SimpleBuilder<IAstEnum> builder, params EnumLabelInput[] items)
    => ((EnumBuilder)builder).WithLabels([.. items.Select(i => i.Label)]);
  protected override SimpleBuilder<IAstEnum> MakeSimple(string name)
    => new EnumBuilder(name);

  internal override ForType ForGeneratedItem(string name, EnumLabelInput item)
    => ForGeneratedDecoder($"=> input.DecodeEnum(\"{name}\", out output);");
}
