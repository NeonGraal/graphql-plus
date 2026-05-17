namespace GqlPlus.Schema.Modelling.Globals;

public class SchDirectiveModellerTests
  : SchModellerClassTestBase<IAstSchemaDirective, ISch_Directive>
{
  protected override IModeller<IAstSchemaDirective, ISch_Directive> Modeller { get; } = new SchDirectiveModeller();

  [Fact]
  public void ToModel_ValidDirective_ReturnsDirectiveDiscriminator()
  {
    IAstSchemaDirective ast = A.Named<IAstSchemaDirective>("auth", "directive");
    IAstInputParam parameter = A.InputParam("InputType").AsInputParam;
    ast.Parameter.Returns(parameter);
    ast.DirectiveOption.Returns(DirectiveOption.Repeatable);
    ast.Locations.Returns(DirectiveLocation.Operation | DirectiveLocation.Field);

    ISch_Directive result = Modeller.ToModel(ast, TypeKinds);
    ISch_DirectiveObject directive = result.As__Directive.ShouldNotBeNull();

    directive.Parameter.ShouldNotBeNull();
    directive.Repeatable.ShouldBeTrue();
  }
}
