﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeOutputObjectsTests
  : TestObjects<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  private readonly MergeOutputObjects _merger;

  public MergeOutputObjectsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), Fields, TypeParameters, Alternates);

  internal override AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputReferenceAst> MergerObject => _merger;

  protected override OutputDeclAst MakeObject(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override OutputFieldAst[] MakeFields(FieldInput[] fields)
    => fields.OutputFields();
  protected override OutputReferenceAst MakeReference(string type)
    => new(AstNulls.At, type);
}
