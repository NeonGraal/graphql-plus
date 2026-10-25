using System.Diagnostics.CodeAnalysis;
using GqlPlus;
using GqlPlus.Resolving;

namespace GqlPlus.Sample;

[Trait("Generate", "Html")]
public class HtmlSchemaTests(ComponentFixture<SchemaCodecTestServices> fixture)
  : TestSchemaVerify(fixture.GetService<ISchemaVerifyChecks>()), IClassFixture<ComponentFixture<SchemaCodecTestServices>>
{
  private readonly ISchemaVerifyChecks checks = fixture.GetService<ISchemaVerifyChecks>();

  [Fact]
  public async Task Index_Schema()
  {
    Map<IEnumerable<string>> mostGroups = new() {
      ["Globals"] = SamplesSchemaGlobalsData.Strings,
      ["Merges"] = await ReplaceSchemaKeys("Merges"),
      ["Objects"] = await ReplaceSchemaKeys("Objects"),
      ["Simple"] = SamplesSchemaSimpleData.Strings,
    };

    Map<IGqlpValue> groups = mostGroups.Links();
    groups["All"] = SchemaValidData.AllGroups.Links(v => v[1..]);

    IGqlpValue result = new Map<IGqlpValue>() {
      ["title"] = "Schema".Encode(),
      ["items"] = SamplesSchemaData.Strings.Links(),
      ["groups"] = groups.Encode()
    }.Encode();

    await result.WriteHtmlFileAsync("Schema", "index", "index");
  }

  [Fact]
  public async Task Index_Spec()
  {
    Map<IEnumerable<string>> groups = new() {
      ["Introspection"] = SamplesSpecificationIntrospectionData.Strings,
      ["Request"] = SamplesSpecificationRequestData.Strings,
    };

    IGqlpValue result = new Map<IGqlpValue>() {
      ["title"] = "Specification".Encode(),
      ["items"] = SamplesSpecificationData.Strings.Links(),
      ["groups"] = groups.Links().Encode()
    }.Encode();

    await result.WriteHtmlFileAsync("Spec", "index", "index");
  }

  [Fact]
  public async Task Index_DI()
  {
    Map<IEnumerable<string>> groups = new() {
      ["Table"] = DiFluid.KnownTrees,
      ["Diagram"] = DiFluid.KnownTrees,
      ["Force-3D"] = DiFluid.KnownTrees,
    };

    IGqlpValue result = new Map<IGqlpValue>() {
      ["title"] = "Dependency Injection".Encode(),
      ["groups"] = groups.Links().Encode()
    }.Encode("");

    await result.WriteHtmlFileAsync("DI", "index", "index");
  }

  protected override async Task EncodeModel([NotNull] SchemaModel model, IModelsContext context, string test, string label, string[] dirs, string section)
  {
    IGqlpValue result = checks.Encode_Model(model, context);
    await result.ThrowIfNull()
      .Add("title", label.Encode())
      .WriteHtmlFileAsync(new string[] { label, section }.Joined("/"), test);
  }
  public override string ResultGroup => "Html";
  protected override Task VerifyResult(string target, VerifySettings settings)
    => throw new NotImplementedException();
  public override string EncodeResult(IGqlpValue result, string section)
    => throw new NotImplementedException();
}
