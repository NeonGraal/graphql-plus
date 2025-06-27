using GqlPlus;
using GqlPlus.Convert;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class HtmlSchemaTests(
  ILoggerFactory logger,
  ISchemaVerifyChecks checks
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

    await result.WriteHtmlFileAsync("Sample", "index", "index");
  }

  [Fact]
  public void Index_Schema()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Schema",
      ["items"] = SamplesSchemaData.Strings.Encode(),
    }.Encode("");

    result.WriteHtmlFile("Schema", "index", "index");
  }

  [Fact]
  public void Index_Spec()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["items"] = SamplesSchemaSpecificationData.Strings.Encode(),
    }.Encode("");

    result.WriteHtmlFile("Spec", "index", "index");
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => result.WriteHtmlFileAsync(new string[] { label, section }.Joined("/"), test);
}
