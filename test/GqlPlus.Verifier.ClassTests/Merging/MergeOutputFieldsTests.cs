using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeOutputFieldsTests
  : TestFields<OutputFieldAst, OutputReferenceAst>
{
  private readonly MergeOutputFields _merger = new();

  protected override FieldsMerger<OutputFieldAst, OutputReferenceAst> MergerField => _merger;

  protected override OutputFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));
}
