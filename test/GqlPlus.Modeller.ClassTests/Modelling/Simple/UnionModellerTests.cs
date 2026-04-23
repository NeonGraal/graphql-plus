using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class UnionModellerTests
  : TypeModellerTests<IAstUnion, TypeUnionModel>
{
  public UnionModellerTests()
    : base(TypeKindModel.Union)
  { }

  protected override IModeller<IAstUnion, TypeUnionModel> Modeller { get; } = new UnionModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidUnion_ReturnsExpectedTypeUnionModel(
    string name,
    string memberName,
    string contents)
  {
    // Arrange
    IAstUnionMember member = A.Named<IAstUnionMember>(memberName, contents);
    IAstUnion ast = A.Union(name).WithMembers(member).AsUnion;

    // Act
    TypeUnionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Items.ShouldHaveSingleItem()
          .ShouldSatisfyAllConditions(
            m => m.Name.ShouldBe(memberName),
            m => m.Description.ShouldBe(contents)));
  }
}
