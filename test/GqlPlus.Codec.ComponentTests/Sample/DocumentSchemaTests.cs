using System.Diagnostics.CodeAnalysis;
using GqlPlus;
using GqlPlus.Convert;
using GqlPlus.Resolving;

namespace GqlPlus.Sample;

[Trait("Generate", "Html")]
public class DocumentSchemaTests(
  ISchemaVerifyChecks checks,
  IEncoder<BaseTypeModel> types
) : TestSchemaVerify(checks)
{
  [Fact]
  public async Task Index_Schema()
  {
    string[] all = ["!ALL", "+Global", "+Merge", "+Object", "+Simple"];

    Map<IEnumerable<string>> mostGroups = new() {
      ["Globals"] = SamplesSchemaGlobalsData.Strings,
      ["Merges"] = await ReplaceSchemaKeys("Merges"),
      ["Objects"] = await ReplaceSchemaKeys("Objects"),
      ["Simple"] = SamplesSchemaSimpleData.Strings,
    };

    Map<Structured> groups = mostGroups.Links();
    groups["All"] = all.Links(v => v[1..]);

    Structured result = new Map<Structured>() {
      ["title"] = "Schema",
      ["items"] = SamplesSchemaData.Strings.Links(),
      ["groups"] = groups.Encode()
    }.Encode();

    await result.WriteHtmlFileAsync("Doc/Schema", "index", "index");
  }

  [Fact]
  public async Task Index_Spec()
  {
    Map<IEnumerable<string>> groups = new() {
      ["Introspection"] = SamplesSpecificationIntrospectionData.Strings,
      ["Request"] = SamplesSpecificationRequestData.Strings,
    };

    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["items"] = SamplesSpecificationData.Strings.Links(),
      ["groups"] = groups.Links().Encode()
    }.Encode();

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
      .Add("groups", groups)
      .Add("title", new(test));

    await result.WriteHtmlFileAsync(new string[] { "Doc", label, section }.Joined("/"), test);

    IMap<BaseTypeModel> Just<T>()
      => model.GetTypes(null).Values.Where(d => d is T).ToMap(d => d.Name);
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Task.CompletedTask;  // No verification needed for this test}
}
