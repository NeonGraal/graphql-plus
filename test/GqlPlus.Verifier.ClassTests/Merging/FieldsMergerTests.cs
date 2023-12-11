using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class FieldsMergerTests
  : TestFields<InputFieldAst, InputReferenceAst>
{
  private readonly FieldsMerger<InputFieldAst, InputReferenceAst> _merger = new();

  protected override FieldsMerger<InputFieldAst, InputReferenceAst> MergerField => _merger;

  protected override InputFieldAst MakeField(string name, string type, string description = "")
    => new(AstNulls.At, name, description, new(AstNulls.At, type));
}
