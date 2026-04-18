using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class EnumEncoderGeneratorTests
  : GenerateSimpleTestsBase<IAstEnum>
{
  private readonly EnumEncoderGenerator _generator;

  public EnumEncoderGeneratorTests()
    => _generator = new EnumEncoderGenerator();

  internal override GenerateForType<IAstEnum> TypeGenerator => _generator;

  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("internal class " + TestPrefix + name + "Encoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  protected override void MakeItems(SimpleBuilder<IAstEnum> builder, params string[] items)
    => ((EnumBuilder)builder).WithLabels(items);
  protected override SimpleBuilder<IAstEnum> MakeSimple(string name)
    => new EnumBuilder(name);

  internal override ForType ForGeneratedItem(string name, string item)
    => ForGeneratedEncoder("input.ToString()");
}
