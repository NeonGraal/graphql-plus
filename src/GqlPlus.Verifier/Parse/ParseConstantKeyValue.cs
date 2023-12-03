using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

internal class ParseConstantKeyValue : ValueKeyValueParser<ConstantAst>
{
  public ParseConstantKeyValue(
    Parser<FieldKeyAst>.D key,
    Parser<ConstantAst>.D value
  ) : base(key, value) { }

  public override string Label => "Constant";
}
