﻿using GqlPlus;
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
      ["items"] = all.Render(),
      ["groups"] = new Map<Structured>() {
        ["Globals"] = SamplesSchemaGlobalsData.Strings.Render(),
        ["Merges"] = merges.Render(),
        ["Objects"] = objects.Render(),
        ["Simple"] = SamplesSchemaSimpleData.Strings.Render(),
      }.Render()
    }.Render();

    await result.WriteHtmlFileAsync("Sample", "index", "index");
  }

  [Fact]
  public async Task Index_Schema()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Schema",
      ["items"] = SamplesSchemaData.Strings.Render(),
    }.Render("");

    await result.WriteHtmlFileAsync("Schema", "index", "index");
  }

  [Fact]
  public async Task Index_Spec()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "Specification",
      ["items"] = SamplesSchemaSpecificationData.Strings.Render(),
    }.Render("");

    await result.WriteHtmlFileAsync("Spec", "index", "index");
  }

  [Fact]
  public async Task Index_DI()
  {
    string[] files = ["Parser", "Modeller", "Verifier"];

    Structured result = new Map<Structured>() {
      ["title"] = "Dependency Injection",
      ["groups"] = new Map<Structured>() {
        ["Table"] = files.Render(),
        ["Diagram"] = files.Render(),
        ["Force-3D"] = files.Render(),
      }.Render()
    }.Render("");

    await result.WriteHtmlFileAsync("DI", "index", "index");
  }

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => result.WriteHtmlFileAsync(new string[] { label, section }.Joined("/"), test);
}
