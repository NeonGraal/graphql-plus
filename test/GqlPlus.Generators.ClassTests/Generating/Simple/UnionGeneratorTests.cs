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
    IGqlpUnion unionType = A.Named<IGqlpUnion>(unionName);
    IGqlpUnionMember item = A.Named<IGqlpUnionMember>(memberName);
    unionType.Items.Returns([item]);

    // Act
    MapPair<string>[] result = [.. _generator.TypeMembers(unionType, context)];

    // Assert
    result.Length.ShouldBe(1);
    result[0].Key.ShouldBe("As" + memberName);
    result[0].Value.ShouldBe(memberName);
  }
}
