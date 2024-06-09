
namespace GqlPlus.Rendering;

internal class TypeUnionRenderer
  : ParentTypeRenderer<TypeUnionModel, AliasedModel, UnionMemberModel>
{
  protected override Func<AliasedModel, UnionMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

internal class UnionMemberRenderer
  : AliasedRenderer<UnionMemberModel>
{
  internal override RenderStructure Render(UnionMemberModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("union", model.OfUnion);
}
