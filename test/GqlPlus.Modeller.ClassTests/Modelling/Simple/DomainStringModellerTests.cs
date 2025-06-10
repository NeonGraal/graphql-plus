namespace GqlPlus.Modelling.Simple;

public class DomainStringModellerTests
  : DomainModellerClassTestBase<IGqlpDomainRegex, DomainRegexModel>
{
  protected override IDomainModeller<IGqlpDomainRegex, DomainRegexModel> DomainModeller { get; }
    = new DomainStringModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidDomain_ReturnsExpectedBaseDomainModel(
    string name,
    string parent,
    string contents,
    string[] aliases)
  {
    // Arrange
    IGqlpDomain<IGqlpDomainRegex> ast = A.Domain<IGqlpDomainRegex>(name, aliases, parent, contents, DomainKind.String);

    // Act
    BaseDomainModel<DomainRegexModel> result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.DomainKind.ShouldBe(DomainKindModel.String),
        r => r.Description.ShouldBe(contents),
        r => r.Aliases.ShouldBe(aliases),
        r => r.Parent.ShouldNotBeNull()
          .TypeName.ShouldBe(parent)
      );
  }
}
