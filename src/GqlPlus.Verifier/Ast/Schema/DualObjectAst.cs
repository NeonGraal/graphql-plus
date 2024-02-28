using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

[ExcludeFromCodeCoverage]
internal record class DualObjectAst : AstObject<DualFieldAst, DualReferenceAst>
{
  internal override string Abbr => "D";
  public override string Label { get; }

  public DualObjectAst(TokenAt at, string label)
    : base(at, "_" + label, "")
    => Label = label;
}

[ExcludeFromCodeCoverage]
internal record class DualFieldAst(TokenAt At, string Name, string Description, DualReferenceAst Type)
  : AstField<DualReferenceAst>(At, Name, Description, Type)
{
  internal override string Abbr => "DF";
}

[ExcludeFromCodeCoverage]
internal record class DualReferenceAst(TokenAt At, string Name, string Description)
  : AstReference<DualReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "DR";
  public override string Label => "Dual";
}
