using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class UnionGeneratorTests
  : GenerateSimpleTestsBase<IGqlpUnion>
{
  private readonly UnionInterfaceGenerator _generator;

  public UnionGeneratorTests()
    => _generator = new UnionInterfaceGenerator();

  internal override GenerateForType<IGqlpUnion> TypeGenerator => _generator;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedImplementation(string contains)
    => _ => result => { };

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
