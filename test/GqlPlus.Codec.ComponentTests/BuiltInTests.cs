﻿using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Convert;
using GqlPlus.Resolving;

namespace GqlPlus;

public class BuiltInTests(IModelAndEncode encoder)
{
  [Theory]
  [ClassData(typeof(BuiltInBasicData))]
  public void HtmlBasicTypes(string type)
    => RenderTypeHtml("Basic", BuiltInData.BasicMap[type], []);

  [Theory]
  [ClassData(typeof(BuiltInInternalData))]
  public void HtmlInternalTypes(string type)
    => RenderTypeHtml("Internal", BuiltInData.InternalMap[type], BuiltIn.Internal);

  [Fact]
  public void HtmlAllBasicTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Basic
    };

    RenderSchemaHtml(schema, "!Basic");
  }

  [Fact]
  public void HtmlAllInternalTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Internal
    };

    RenderSchemaHtml(schema, "!Internal");
  }

  private readonly string[] _sections = ["!Basic", "!Internal"];

  [Fact]
  public void Html_Index()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "BuiltIn",
      ["items"] = _sections.Encode(),
      ["groups"] = new Map<Structured>() {
        ["Basic"] = BuiltIn.Basic.Encode(t => t.Name),
        ["Internal"] = BuiltIn.Internal.Encode(t => t.Name),
      }.Encode(),
    }.Encode("");

    result.WriteHtmlFile("BuiltIn", "index", "index");
  }

  [Theory]
  [ClassData(typeof(BuiltInBasicData))]
  public void ModelBasicTypes(string type)
    => ModelType(BuiltInData.BasicMap[type], []);

  [Theory]
  [ClassData(typeof(BuiltInInternalData))]
  public void ModelInternalTypes(string type)
    => ModelType(BuiltInData.InternalMap[type], BuiltIn.Internal);

  [Fact]
  public void ModelAllBasicTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Basic
    };

    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(schema, context);

    context.Errors.ShouldBeEmpty();
  }

  [Fact]
  public void ModelAllInternalTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Internal
    };

    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(schema, context);

    context.Errors.ShouldBeEmpty();
  }

  [Fact]
  public void ModelsFluidFiles()
    => RenderFluid.CheckFluidFiles();

  private void ModelType(IGqlpType type, IGqlpType[] extras)
  {
    Assert.SkipWhen(type is null, "type is null");

    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    SchemaAst extrasSchema = new(AstNulls.At) {
      Declarations = [.. extras.Where(e => e != type)]
    };

    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(schema, context, extrasSchema);

    context.Errors.ShouldBeEmpty(type?.Label);
  }

  private void RenderTypeHtml(string section, IGqlpType type, IGqlpType[] extras)
  {
    Assert.SkipWhen(type is null, "type is null");

    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    SchemaAst extrasSchema = new(AstNulls.At) {
      Declarations = [.. extras.Where(e => e != type)]
    };

    RenderSchemaHtml(schema, type.Name, section, extrasSchema);
  }

  private void RenderSchemaHtml(SchemaAst schema, string filename, string section = "", SchemaAst? extras = null)
  {
    Structured result = encoder.EncodeAst(schema, encoder.Context(), extras);

    result.WriteHtmlFile("BuiltIn" + section.Prefixed("/"), filename);
  }
}
