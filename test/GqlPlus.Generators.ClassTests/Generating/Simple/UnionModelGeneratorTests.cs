using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class UnionModelGeneratorTests
  : GenerateSimpleTestsBase<IAstUnion>
{
  private readonly UnionModelGenerator _generator;

  public UnionModelGeneratorTests()
    => _generator = new UnionModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override GenerateForType<IAstUnion> TypeGenerator => _generator;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedModel("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedModel(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedModel(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedModel(contains);

  [Theory, RepeatData]
  public void TypeMembers_WithUnionItems_ReturnsAsNamePairs(string unionName, string memberName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IAstUnionMember member = A.Named<IAstUnionMember>(memberName);
    IAstUnion unionType = A.Union(unionName).WithMembers(member).AsUnion;

    // Act
    MapPair<string>[] result = [.. _generator.TypeMembers(unionType, context)];

    // Assert
    result.Length.ShouldBe(1);
    result[0].Key.ShouldBe("As" + memberName);
    result[0].Value.ShouldBe(memberName);
  }

  protected override void MakeItems(SimpleBuilder<IAstUnion> builder, params string[] items)
    => ((UnionBuilder)builder).WithMembers(items);
  protected override SimpleBuilder<IAstUnion> MakeSimple(string name)
    => new UnionBuilder(name);
}
