using GqlPlus;
using GqlPlus.Ast.Schema;
using GqlPlus.Convert;
using GqlPlus.Resolving;

namespace GqlPlus;

[Trait("Generate", "Html")]
public class HtmlBuiltInTests(IModelAndEncode encoder)
{
  [Theory]
  [ClassData(typeof(BuiltInBasicData))]
  public async Task HtmlBasicTypes(string type)
    => await RenderTypeHtml("Basic", BuiltInData.BasicMap[type], []);

  [Theory]
  [ClassData(typeof(BuiltInInternalData))]
  public async Task HtmlInternalTypes(string type)
    => await RenderTypeHtml("Internal", BuiltInData.InternalMap[type], BuiltIn.Internal);

  private readonly IAstSchema _basicSchema = BuiltIn.Basic.Schema();

  [Fact]
  public async Task HtmlAllBasicTypes()
    => await RenderSchemaHtml(_basicSchema, "!Basic");

  private readonly IAstSchema _internalSchema = BuiltIn.Internal.Schema();

  [Fact]
  public async Task HtmlAllInternalTypes()
    => await RenderSchemaHtml(_internalSchema, "!Internal", extras: _basicSchema);

  private readonly string[] _sections = ["Basic", "Internal"];

  [Fact]
  public async Task Html_Index()
  {
    Map<IEnumerable<string>> groups = new() {
      ["Basic"] = BuiltIn.Basic.Select(t => t.Name),
      ["Internal"] = BuiltIn.Internal.Select(t => t.Name),
    };

    Structured result = new Map<Structured>() {
      ["title"] = "BuiltIn".Encode(),
      ["items"] = _sections.Links("!"),
      ["groups"] = groups.Links().Encode(),
    }.Encode("");

    await result.WriteHtmlFileAsync("BuiltIn", "index", "index");
  }

  [Theory]
  [ClassData(typeof(BuiltInBasicData))]
  public void ModelBasicTypes_GivenType_SucceedsWithoutErrors(string type)
    => ModelType(BuiltInData.BasicMap[type], []);

  [Theory]
  [ClassData(typeof(BuiltInInternalData))]
  public void ModelInternalTypes_GivenType_SucceedsWithoutErrors(string type)
    => ModelType(BuiltInData.InternalMap[type], BuiltIn.Internal);

  [Fact]
  public void ModelAllBasicTypes_Default_SucceedsWithoutErrors()
  {
    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(_basicSchema, context);

    context.Errors.ShouldBeEmpty();
  }

  [Fact]
  public void ModelAllInternalTypes_Default_SucceedsWithoutErrors()
  {
    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(_internalSchema, context, _basicSchema);

    context.Errors.ShouldBeEmpty();
  }

  [Fact]
  public void ModelsFluidFiles_WhenChecked_AreValid()
    => RenderFluid.CheckFluidFiles();

  private void ModelType(IAstType type, IAstType[] extras)
  {
    Assert.SkipWhen(type is null, "type is null");

    IAstSchema schema = type.Schema();

    IAstSchema extrasSchema = extras.Where(e => e != type).Schema();

    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(schema, context, extrasSchema);

    context.Errors.ShouldBeEmpty(type?.Label);
  }

  private async Task RenderTypeHtml(string section, IAstType type, IAstType[] extras)
  {
    Assert.SkipWhen(type is null, "type is null");

    IAstSchema schema = type.Schema();

    IAstSchema extrasSchema = extras.Where(e => e != type).Schema();

    await RenderSchemaHtml(schema, type.Name, section, extrasSchema);
  }

  private async Task RenderSchemaHtml(IAstSchema schema, string filename, string section = "", IAstSchema? extras = null)
  {
    Structured result = encoder.EncodeAst(schema, encoder.Context(), extras);

    await result.ThrowIfNull().Add("title", filename.Encode()).WriteHtmlFileAsync("BuiltIn" + section.Prefixed("/"), filename);
  }
}
