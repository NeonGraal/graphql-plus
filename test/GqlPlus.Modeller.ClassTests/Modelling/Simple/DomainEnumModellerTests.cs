namespace GqlPlus.Modelling.Simple;

public class DomainEnumModellerTests
  : DomainModellerClassTestBase<IGqlpDomainLabel, DomainLabelModel>
{
  protected override IDomainModeller<IGqlpDomainLabel, DomainLabelModel> DomainModeller { get; }
    = new DomainEnumModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidDomain_ReturnsExpectedBaseDomainModel(
    string name,
    string parent,
    string contents,
    string[] aliases)
  {
    // Arrange
    IGqlpDomain<IGqlpDomainLabel> ast = A.Aliased<IGqlpDomain<IGqlpDomainLabel>>(name, aliases, contents);
    ast.Parent.Returns(parent);

    // Act
    BaseDomainModel<DomainLabelModel> result = Modeller.ToModel(ast, TypeKinds);

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
