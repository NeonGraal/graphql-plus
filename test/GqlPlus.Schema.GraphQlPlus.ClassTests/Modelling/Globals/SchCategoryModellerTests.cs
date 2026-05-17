namespace GqlPlus.Schema.Modelling.Globals;

public class SchCategoryModellerTests
  : SchModellerClassTestBase<IAstSchemaCategory, ISch_Category>
{
  protected override IModeller<IAstSchemaCategory, ISch_Category> Modeller { get; } = new SchCategoryModeller(new SchModifierModeller());

  [Fact]
  public void ToModel_ValidCategory_ReturnsCategoryDiscriminator()
  {
    IAstSchemaCategory ast = A.Named<IAstSchemaCategory>("Query", "category");
    IAstTypeRef output = A.Named<IAstTypeRef>("Result");
    IAstModifier[] modifiers = [A.Modifier(ModifierKind.List)];
    ast.Output.Returns(output);
    ast.CategoryOption.Returns(CategoryOption.Parallel);
    ast.Modifiers.Returns(modifiers);

    ISch_Category result = Modeller.ToModel(ast, TypeKinds);
    ISch_CategoryObject category = result.As__Category.ShouldNotBeNull();

    category.Resolution.ShouldBe(Sch_Resolution.Parallel);
  }
}
