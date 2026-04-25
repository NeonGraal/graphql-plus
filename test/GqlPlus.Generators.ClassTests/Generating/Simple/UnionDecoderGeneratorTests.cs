using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class UnionDecoderGeneratorTests
  : GenerateSimpleTestsBase<IAstUnion>
{
  private readonly UnionDecoderGenerator _generator;

  public UnionDecoderGeneratorTests()
    => _generator = new UnionDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override GenerateForType<IAstUnion> TypeGenerator => _generator;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedDecoder("internal class " + TestPrefix + name + "Decoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  protected override void MakeItems(SimpleBuilder<IAstUnion> builder, params string[] items)
    => ((UnionBuilder)builder).WithMembers(items);
  protected override SimpleBuilder<IAstUnion> MakeSimple(string name)
    => new UnionBuilder(name);

  internal override ForType ForGeneratedItem(string name, string item)
    => ForGeneratedDecoder(item);
}
