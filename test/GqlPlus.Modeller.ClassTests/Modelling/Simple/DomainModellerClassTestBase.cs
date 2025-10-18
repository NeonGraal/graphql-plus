
namespace GqlPlus.Modelling.Simple;

public abstract class DomainModellerClassTestBase<TItemAst, TItemModel>
  : TypeModellerTests<IGqlpDomain<TItemAst>, BaseDomainModel<TItemModel>>
  where TItemAst : class, IGqlpDomainItem
  where TItemModel : BaseDomainItemModel
{
  protected DomainModellerClassTestBase()
    : base(TypeKindModel.Domain)
  { }

  [Theory, RepeatData]
  public void ToModel_WithValidDomain_ReturnsExpectedBaseDomainModel(
    string name,
    string parent,
    string contents,
    string[] aliases)
  {
    // Arrange
    TItemAst item = A.Error<TItemAst>();
    IGqlpDomain<TItemAst> ast = A.Domain(name, aliases, contents, Kind, item);
    A.SetParent(ast, parent);

    // Act
    BaseDomainModel<TItemModel> result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.DomainKind.ShouldBe(KindModel),
        r => r.Description.ShouldBe(contents),
        r => r.Aliases.ShouldBe(aliases),
        r => r.Parent.ShouldNotBeNull()
          .Name.ShouldBe(parent),
        r => r.Items.ShouldNotBeEmpty(),
        r => r.AllItems.ShouldNotBeEmpty());
  }

  [Theory, RepeatData]
  public void ToModel_WithNullParent_ReturnsBaseDomainModelWithNullParent(string name)
  {
    // Arrange
    IGqlpDomain<TItemAst> ast = A.Domain<TItemAst>(name, Kind);

    // Act
    BaseDomainModel<TItemModel> result = DomainModeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Parent.ShouldBeNull());
  }

  protected abstract DomainKind Kind { get; }
  protected abstract DomainKindModel KindModel { get; }
  protected abstract IDomainModeller<TItemAst, TItemModel> DomainModeller { get; }
  protected sealed override IModeller<IGqlpDomain<TItemAst>, BaseDomainModel<TItemModel>> Modeller => DomainModeller;
}
