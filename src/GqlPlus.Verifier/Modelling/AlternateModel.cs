using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class AlternateModel<TBase>(RefModel<TBase> Type)
  : ModelBase
  where TBase : ITypeBaseModel
{
  internal ModifierModel[] Collections { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("type", Type.Render())
      .Add("collections", Collections.Render());
}

internal class AlternateModeller<TRefAst, TBase>(
  IModeller<TRefAst> refBase,
  IModeller<ModifierAst> modifier
) : ModellerBase<AstAlternate<TRefAst>, AlternateModel<TBase>>
  where TRefAst : AstReference<TRefAst>
  where TBase : ITypeBaseModel
{
  internal override AlternateModel<TBase> ToModel(AstAlternate<TRefAst> ast)
    => new(new(BaseModel(ast.Type))) { Collections = ModifiersModels(ast.Modifiers) };

  private TBase BaseModel(TRefAst ast)
    => refBase.ToModel<TBase>(ast) ?? throw new ModelTypeException<TBase>(ast);

  internal ModifierModel[] ModifiersModels(ModifierAst[] modifiers)
    => [.. modifiers.Select(modifier.ToModel<ModifierModel>).Where(m => m is not null)];
}
