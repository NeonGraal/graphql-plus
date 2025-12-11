using GqlPlus;
using GqlPlus.Convert;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

[Trait("Generate", "Html")]
public class HtmlSchemaTests(
  ISchemaVerifyChecks checks
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

    await result.WriteHtmlFileAsync("Schema", "index", "index");
  }

  [Fact]
  public async Task Index_Spec()
  {
    Map<IEnumerable<string>> groups = new() {
      ["Introspection"] = SamplesSpecificationIntrospectionData.Strings,
    };

    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["items"] = SamplesSpecificationData.Strings.Links(),
      ["groups"] = groups.Links().Encode()
    }.Encode();

    await result.WriteHtmlFileAsync("Spec", "index", "index");
  }

  [Fact]
  public async Task Index_DI()
  {
    string[] files = ["Codec", "Generator", "Modeller", "Parser", "Verifier"];

    Map<IEnumerable<string>> groups = new() {
      ["Table"] = files,
      ["Diagram"] = files,
      ["Force-3D"] = files,
    };

    Structured result = new Map<Structured>() {
      ["title"] = "Dependency Injection",
      ["groups"] = groups.Links().Encode()
    }.Encode("");

    await result.WriteHtmlFileAsync("DI", "index", "index");
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => result.ThrowIfNull().Add("title", new(label)).WriteHtmlFileAsync(new string[] { label, section }.Joined("/"), test);
}
