namespace GqlPlus.Schema.Modelling;

public class SchSchemaModellerTests
  : SchModellerClassTestBase<IAstSchema, ISch_SchemaObject>
{
  protected override IModeller<IAstSchema, ISch_SchemaObject> Modeller { get; }
    = AllSchModellers.CreateDefaultRepository().ModellerFor<IAstSchema, ISch_SchemaObject>()();

  [Fact]
  public void ToModel_ValidSchema_ReturnsSchemaData()
  {
    IAstSchemaCategory category = A.Named<IAstSchemaCategory>("Query", "category");
    IAstTypeRef outputRef = A.Named<IAstTypeRef>("Result");
    category.Output.Returns(outputRef);
    category.CategoryOption.Returns(CategoryOption.Parallel);
    category.Modifiers.Returns([]);

    IAstSchemaDirective directive = A.Named<IAstSchemaDirective>("auth", "directive");
    IAstInputParam parameter = A.InputParam("InputType").AsInputParam;
    directive.Parameter.Returns(parameter);
    directive.DirectiveOption.Returns(DirectiveOption.Repeatable);
    directive.Locations.Returns(DirectiveLocation.Operation);

    IAstSchemaSetting setting = A.Named<IAstSchemaSetting>("setting", "value");
    IAstConstant value = A.Constant("value");
    setting.Value.Returns(value);

    IAstSchemaOption option = A.Named<IAstSchemaOption>("SchemaName", string.Empty);
    IAstSchemaSetting[] settings = [setting];
    option.Settings.Returns(settings);

    IAstObject<IAstOutputField> output = A.OutputObj("Result").AsObject;
    IAstObject<IAstInputField> input = A.InputObj("InputType").AsObject;
    IAstDeclaration[] declarations = [category, directive, option, output, input];
    IAstSchema schema = A.Error<IAstSchema>();
    schema.Declarations.Returns(declarations);
    schema.Errors.Returns(Messages.Empty);

    ISch_SchemaObject result = Modeller.ToModel(schema, TypeKinds);

    result.Types().ShouldNotBeNull();
    result.Categories().ShouldNotBeNull();
    result.Directives().ShouldNotBeNull();
    result.Settings().ShouldNotBeNull();
    result.Name.Value.ShouldBe("SchemaName");
  }
}
