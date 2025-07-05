using System.Diagnostics.CodeAnalysis;
using GqlPlus;
using GqlPlus.Abstractions;
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
  IEncoder<BaseTypeModel> types
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
      ["items"] = all.Encode(),
      ["groups"] = new Map<Structured>() {
        ["Globals"] = SamplesSchemaGlobalsData.Strings.Encode(),
        ["Merges"] = merges.Encode(),
        ["Objects"] = objects.Encode(),
        ["Simple"] = SamplesSchemaSimpleData.Strings.Encode(),
      }.Encode()
    }.Encode();

    await result.WriteHtmlFileAsync("Doc/Sample", "index", "index");
  }

  [Fact]
  public async Task Index_Schema()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Schema",
      ["items"] = SamplesSchemaData.Strings.Encode(),
    }.Encode("");

    await result.WriteHtmlFileAsync("Doc/Schema", "index", "index");
  }

  [Fact]
  public async Task Index_Spec()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["items"] = SamplesSchemaSpecificationData.Strings.Encode(),
    }.Encode("");

    await result.WriteHtmlFileAsync("Doc/Spec", "index", "index");
  }

  protected override async Task EncodeModel([NotNull] SchemaModel model, IModelsContext context, string test, string label, string[] dirs, string section)
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

    IEnumerable<CategoryModel> categories = model.GetCategories(null).Values.Select(c => c.And).Where(c => c is not null).Cast<CategoryModel>();
    IEnumerable<DirectiveModel> directives = model.GetDirectives(null).Values.Select(c => c.And).Where(c => c is not null).Cast<DirectiveModel>();
    ICollection<SettingModel> settings = model.GetSettings(null).Values;
    SchemaModel newModel = new(model.Name, categories, directives, settings, [], model.Errors);
    Structured result = checks.Encode_Model(newModel, context)
      .Add("groups", groups);

    await result.WriteHtmlFileAsync(new string[] { "Doc", label, section }.Joined("/"), test);

    IMap<BaseTypeModel> Just<T>()
      => model.GetTypes(null).Values.Where(d => d is T).ToMap(d => d.Name);
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Task.CompletedTask;  // No verification needed for this test}
}
