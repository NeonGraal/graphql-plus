namespace GqlPlus.Modelling.Simple;

public class DomainNumberModellerTests
  : DomainModellerClassTestBase<IGqlpDomainRange, DomainRangeModel>
{
  protected override IDomainModeller<IGqlpDomainRange, DomainRangeModel> DomainModeller { get; }

  public DomainNumberModellerTests()
    => DomainModeller = new DomainNumberModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidDomain_ReturnsExpectedBaseDomainModel(
    string name,
    string parent,
    string contents,
    string[] aliases)
  {
    // Arrange
    IGqlpDomain<IGqlpDomainRange> ast = For<IGqlpDomain<IGqlpDomainRange>>();
    ast.Name.Returns(name);
    ast.Description.Returns(contents);
    ast.Aliases.Returns(aliases);
    ast.Parent.Returns(parent);

    // Act
    BaseDomainModel<DomainRangeModel> result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Aliases.ShouldBe(aliases),
        r => r.Parent.ShouldNotBeNull()
          .TypeName.ShouldBe(parent));
  }
}
