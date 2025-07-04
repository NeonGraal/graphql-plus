using System.Diagnostics.CodeAnalysis;
using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Merging;
using GqlPlus.Modelling;
using GqlPlus.Resolving;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class DocumentSchemaTests(
  ILoggerFactory logger,
  ISchemaVerifyChecks checks,
  IRenderer<BaseTypeModel> types
) : TestSchemaVerify(logger, checks)
{
  [Fact]
  public async Task Index_Samples()
  {
    string[] all = ["!ALL", "+Globals", "+Merges", "+Objects", "+Simple"];

    IEnumerable<string> merges = await ReplaceSchemaKeys("Merges");
    IEnumerable<string> objects = await ReplaceSchemaKeys("Objects");
    Structured result = new Map<Structured>() {
      ["title"] = "Samples",
      ["items"] = all.Render(),
      ["groups"] = new Map<Structured>() {
        ["Globals"] = SamplesSchemaGlobalsData.Strings.Render(),
        ["Merges"] = merges.Render(),
        ["Objects"] = objects.Render(),
        ["Simple"] = SamplesSchemaSimpleData.Strings.Render(),
      }.Render()
    }.Render();

    await result.WriteHtmlFileAsync("Doc/Sample", "index", "index");
  }

  [Fact]
  public async Task Index_Schema()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Schema",
      ["items"] = SamplesSchemaData.Strings.Render(),
    }.Render("");

    await result.WriteHtmlFileAsync("Doc/Schema", "index", "index");
  }

  [Fact]
  public async Task Index_Spec()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["items"] = SamplesSchemaSpecificationData.Strings.Render(),
    }.Render("");

    await result.WriteHtmlFileAsync("Doc/Spec", "index", "index");
  }

  protected override async Task RenderModel([NotNull] SchemaModel model, IModelsContext context, string test, string label, string[] dirs, string section)
  {
    IMap<BaseTypeModel> domains = Just<ITypeDomainModel>();
    IMap<BaseTypeModel> enums = Just<TypeEnumModel>();
    IMap<BaseTypeModel> unions = Just<TypeUnionModel>();

    IMap<BaseTypeModel> duals = Just<TypeDualModel>();
    IMap<BaseTypeModel> inputs = Just<TypeInputModel>();
    IMap<BaseTypeModel> outputs = Just<TypeOutputModel>();

    Structured groups = new Structured("")
      .AddMap("Domain", domains, types, "_Type")
      .AddMap("Enum", enums, types, "_Type")
      .AddMap("Union", unions, types, "_Type")
      .AddMap("Dual", duals, types, "_Type")
      .AddMap("Input", inputs, types, "_Type")
      .AddMap("Output", outputs, types, "_Type");

    Structured result = checks.Render_Model(model with { Types = new Map<BaseTypeModel>() }, context)
      .Add("groups", groups);

    await result.WriteHtmlFileAsync(new string[] { "Doc", label, section }.Joined("/"), test);

    IMap<BaseTypeModel> Just<T>()
      => model.Types.Values.Where(d => d is T).ToMap(d => d.Name);
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Task.CompletedTask;  // No verification needed for this test}
}
