namespace GqlPlus.Schema.Modelling.Simple;

public class SchUnionModellerTests
  : SchModellerClassTestBase<IAstUnion, ISch_Type>
{
  protected override IModeller<IAstUnion, ISch_Type> Modeller { get; } = new SchUnionModeller();

  [Fact]
  public void ToModel_ValidUnion_ReturnsUnionDiscriminator()
  {
    IAstUnion ast = A.Union("SearchResult").AsUnion;

    ISch_Type result = Modeller.ToModel(ast, TypeKinds);

    result.As_TypeKindUnion.ShouldNotBeNull();
  }
}
