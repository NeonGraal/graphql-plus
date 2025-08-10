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
    string[] all = ["!ALL", "+Global", "+Merge", "+Object", "+Simple"];

    IEnumerable<string> merges = await ReplaceSchemaKeys("Merge");
    IEnumerable<string> objects = await ReplaceSchemaKeys("Object");
    Structured result = new Map<Structured>() {
      ["title"] = "Samples",
      ["items"] = all.Encode(),
      ["groups"] = new Map<Structured>() {
        ["Global"] = SamplesSchemaGlobalData.Strings.Encode(),
        ["Merge"] = merges.Encode(),
        ["Object"] = objects.Encode(),
        ["Simple"] = SamplesSchemaSimpleData.Strings.Encode(),
      }.Encode()
    }.Encode();

    await result.WriteHtmlFileAsync("Sample", "index", "index");
  }

  [Fact]
  public async Task Index_Schema()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Schema",
      ["items"] = SamplesSchemaData.Strings.Encode(),
    }.Encode("");

    await result.WriteHtmlFileAsync("Schema", "index", "index");
  }

  [Fact]
  public async Task Index_Spec()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["items"] = SamplesSchemaSpecificationData.Strings.Encode(),
    }.Encode("");

    await result.WriteHtmlFileAsync("Spec", "index", "index");
  }

  [Fact]
  public async Task Index_DI()
  {
    string[] files = ["Codec", "Parser", "Modeller", "Verifier"];

    Structured result = new Map<Structured>() {
      ["title"] = "Dependency Injection",
      ["groups"] = new Map<Structured>() {
        ["Table"] = files.Encode(),
        ["Diagram"] = files.Encode(),
        ["Force-3D"] = files.Encode(),
      }.Encode()
    }.Encode("");

    await result.WriteHtmlFileAsync("DI", "index", "index");
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => result.WriteHtmlFileAsync(new string[] { label, section }.Joined("/"), test);
}
