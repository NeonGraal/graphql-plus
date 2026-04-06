using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class UnionModelGeneratorTests
  : GenerateSimpleTestsBase<IGqlpUnion>
{
  private readonly UnionModelGenerator _generator;

  public UnionModelGeneratorTests()
    => _generator = new UnionModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  internal override GenerateForType<IGqlpUnion> TypeGenerator => _generator;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedImplementation("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedImplementation(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedImplementation(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedImplementation(contains);

  [Theory, RepeatData]
  public void TypeMembers_WithUnionItems_ReturnsAsNamePairs(string unionName, string memberName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpUnionMember member = A.Named<IGqlpUnionMember>(memberName);
    IGqlpUnion unionType = A.Union(unionName).WithMembers(member).AsUnion;

    // Act
    MapPair<string>[] result = [.. _generator.TypeMembers(unionType, context)];

    // Assert
    result.Length.ShouldBe(1);
    result[0].Key.ShouldBe("As" + memberName);
    result[0].Value.ShouldBe(memberName);
  }

  protected override void MakeItems(SimpleBuilder<IGqlpUnion> builder, params string[] items)
    => ((UnionBuilder)builder).WithMembers(items);
  protected override SimpleBuilder<IGqlpUnion> MakeSimple(string name)
    => new UnionBuilder(name);
}
