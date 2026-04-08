using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class UnionEncoderGeneratorTests
  : GenerateSimpleTestsBase<IGqlpUnion>
{
  private readonly UnionEncoderGenerator _generator;

  public UnionEncoderGeneratorTests()
    => _generator = new UnionEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override GenerateForType<IGqlpUnion> TypeGenerator => _generator;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedEncoder(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedEncoder(contains);

  protected override void MakeItems(SimpleBuilder<IGqlpUnion> builder, params string[] items)
    => ((UnionBuilder)builder).WithMembers(items);
  protected override SimpleBuilder<IGqlpUnion> MakeSimple(string name)
    => new UnionBuilder(name);
}
