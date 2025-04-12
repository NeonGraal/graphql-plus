using GqlPlus;
using GqlPlus.Convert;

namespace GqlPlus.Sample;

public class HtmlSchemaTests(
    ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  [Fact]
  public async Task Index_Samples()
  {
    string[] all = ["!ALL", "!Globals", "!Merges", "!Objects", "!Simple"];

    IEnumerable<string> merges = await ReplaceSchemaKeys("Merges");
    IEnumerable<string> objects = await ReplaceSchemaKeys("Objects");
    Structured result = new Map<Structured>() {
      ["title"] = "Samples",
      ["groups"] = new Map<Structured>() {
        ["All"] = all.Render(),
        ["Globals"] = SamplesSchemaGlobalsData.Strings.Render(),
        ["Merges"] = merges.Render(),
        ["Objects"] = objects.Render(),
        ["Simple"] = SamplesSchemaSimpleData.Strings.Render(),
      }.Render()
    }.Render();

    await result.WriteHtmlFileAsync("Sample", "index", "index");
  }

  [Fact]
  public void Index_Schema()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Schema",
      ["items"] = SamplesSchemaData.Strings.Render(),
    }.Render("");

    result.WriteHtmlFile("Schema", "index", "index");
  }

  [Fact]
  public void Index_Spec()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["items"] = SamplesSchemaSpecificationData.Strings.Render(),
    }.Render("");

    result.WriteHtmlFile("Spec", "index", "index");
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => result.WriteHtmlFileAsync(new string[] { label, section }.Joined("/"), test);
}
