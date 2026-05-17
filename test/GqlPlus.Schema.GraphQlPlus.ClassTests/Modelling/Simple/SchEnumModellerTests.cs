namespace GqlPlus.Schema.Modelling.Simple;

public class SchEnumModellerTests
  : SchModellerClassTestBase<IAstEnum, ISch_Type>
{
  protected override IModeller<IAstEnum, ISch_Type> Modeller { get; } = new SchEnumModeller();

  [Fact]
  public void ToModel_ValidEnum_ReturnsEnumDiscriminator()
  {
    IAstEnum ast = A.Enum("Status", ["Open", "Closed"]);

    ISch_Type result = Modeller.ToModel(ast, TypeKinds);

    result.As_TypeKindEnum.ShouldNotBeNull();
  }
}
