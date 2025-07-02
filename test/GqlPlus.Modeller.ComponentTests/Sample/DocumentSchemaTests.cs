using System.Diagnostics.CodeAnalysis;
using GqlPlus;
using GqlPlus.Convert;
using GqlPlus.Resolving;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class DocumentSchemaTests(
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

  protected override Task RenderModel([NotNull] SchemaModel model, IModelsContext context, string test, string label, string[] dirs, string section)
  {
    return base.RenderModel(model, context, test, label, dirs, section);
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => result.WriteHtmlFileAsync(new string[] { "Doc", label, section }.Joined("/"), test);
}
