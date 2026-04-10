using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class UnionEncoderGeneratorTests
  : GenerateSimpleTestsBase<IAstUnion>
{
  private readonly UnionEncoderGenerator _generator;

  public UnionEncoderGeneratorTests()
    => _generator = new UnionEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override GenerateForType<IAstUnion> TypeGenerator => _generator;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("internal class " + TestPrefix + name + "Encoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => _ => _ => { };

  internal override ForType ForGeneratedInterface(string contains)
    => _ => _ => { };

  protected override void MakeItems(SimpleBuilder<IAstUnion> builder, params string[] items)
    => ((UnionBuilder)builder).WithMembers(items);
  protected override SimpleBuilder<IAstUnion> MakeSimple(string name)
    => new UnionBuilder(name);
}
