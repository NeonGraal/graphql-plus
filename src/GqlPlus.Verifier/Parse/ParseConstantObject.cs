using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

internal class ParseConstantObject : ValueObjectParser<ConstantAst>
{
  public ParseConstantObject(Parser<AstKeyValue<ConstantAst>>.D field)
    : base(field) { }

  public override string Label => "Constant";
}
