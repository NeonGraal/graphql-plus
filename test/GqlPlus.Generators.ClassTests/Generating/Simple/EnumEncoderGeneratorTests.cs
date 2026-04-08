using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class EnumEncoderGeneratorTests
  : GenerateSimpleTestsBase<IGqlpEnum>
{
  private readonly EnumEncoderGenerator _generator;

  public EnumEncoderGeneratorTests()
    => _generator = new EnumEncoderGenerator();

  internal override GenerateForType<IGqlpEnum> TypeGenerator => _generator;

  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("public enum " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => generatorType => r => { };

  protected override void MakeItems(SimpleBuilder<IGqlpEnum> builder, params string[] items)
    => ((EnumBuilder)builder).WithLabels(items);
  protected override SimpleBuilder<IGqlpEnum> MakeSimple(string name)
    => new EnumBuilder(name);
}
