﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Resolving;
using GqlPlus.Result;

namespace GqlPlus;

internal sealed class SchemaVerifyChecks(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IModelAndRender schemaRenderer
) : SchemaDataBase(schemaParser)
  , ISchemaVerifyChecks
{
  public Structured Verify_Model(string input)
  {
    IGqlpSchema ast = Parse(input, "Sample").Required();

    return Verify_Asts([ast]).Item1;
  }

  public Structured Verify_Model(IEnumerable<string> inputs)
  {
    IEnumerable<IGqlpSchema> asts = inputs.Select(input => Parse(input, "Sample").Required());

    return Verify_Asts(asts).Item1;
  }

  public (Structured, ITypesContext) Verify_Asts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    ITypesContext context = schemaRenderer.WithBuiltIns();

    Structured structured = schemaRenderer.RenderAst(schema, context);

    context.Errors.Add(asts.SelectMany(a => a.Errors));

    return (structured, context);
  }
}

public interface ISchemaVerifyChecks
  : ISchemaParseChecks
{
  (Structured, ITypesContext) Verify_Asts(IEnumerable<IGqlpSchema> asts);
}
