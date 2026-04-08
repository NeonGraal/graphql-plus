using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class UnionDecoderGeneratorTests
  : GenerateSimpleTestsBase<IGqlpUnion>
{
  private readonly UnionDecoderGenerator _generator;

  public UnionDecoderGeneratorTests()
    => _generator = new UnionDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override GenerateForType<IGqlpUnion> TypeGenerator => _generator;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedDecoder("internal class " + TestPrefix + name + "Decoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override void MakeItems(SimpleBuilder<IGqlpUnion> builder, params string[] items)
    => ((UnionBuilder)builder).WithMembers(items);
  protected override SimpleBuilder<IGqlpUnion> MakeSimple(string name)
    => new UnionBuilder(name);
}
