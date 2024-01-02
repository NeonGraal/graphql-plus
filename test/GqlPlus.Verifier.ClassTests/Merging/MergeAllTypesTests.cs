using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeAllTypesTests
  : TestBase<AstType>
{
  private readonly MergeAllTypes _merger;
  private readonly IMerge<EnumDeclAst> _enums;
  private readonly IMerge<InputDeclAst> _inputs;
  private readonly IMerge<OutputDeclAst> _outputs;
  private readonly IMerge<ScalarDeclAst> _scalars;

  public MergeAllTypesTests()
  {
    _enums = Merger<EnumDeclAst>();
    _inputs = Merger<InputDeclAst>();
    _outputs = Merger<OutputDeclAst>();
    _scalars = Merger<ScalarDeclAst>();

    _merger = new(_enums, _inputs, _outputs, _scalars);
  }

  protected override IMerge<AstType> MergerBase => _merger;

  protected override AstType MakeDistinct(string name)
    => new EnumDeclAst(AstNulls.At, name);
}
