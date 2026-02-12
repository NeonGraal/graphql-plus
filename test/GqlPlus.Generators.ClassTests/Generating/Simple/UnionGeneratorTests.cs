using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class UnionGeneratorTests
  : GenerateSimpleTestsBase<IGqlpUnion>
{
  private readonly UnionGenerator _generator;

  public UnionGeneratorTests()
    => _generator = new UnionGenerator();

  internal override GenerateForType<IGqlpUnion> TypeGenerator => _generator;

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
}
