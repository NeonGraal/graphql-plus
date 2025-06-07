namespace GqlPlus.Modelling.Simple;

public class DomainBooleanModellerTests
  : DomainModellerClassTestBase<IGqlpDomainTrueFalse, DomainTrueFalseModel>
{
  protected override IDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel> DomainModeller { get; }
    = new DomainBooleanModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidDomain_ReturnsExpectedBaseDomainModel(
    string name,
    string parent,
    string contents,
    string[] aliases)
  {
    // Arrange
    IGqlpDomain<IGqlpDomainTrueFalse> ast = A.Aliased<IGqlpDomain<IGqlpDomainTrueFalse>>(name, aliases, contents);
    ast.Parent.Returns(parent);

    // Act
    BaseDomainModel<DomainTrueFalseModel> result = Modeller.ToModel(ast, TypeKinds);

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
