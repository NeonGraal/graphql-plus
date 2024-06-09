
namespace GqlPlus.Rendering;

internal class TypeEnumRenderer(
  IRenderer<AliasedModel> item,
  IRenderer<EnumMemberModel> all
) : ParentTypeRenderer<TypeEnumModel, AliasedModel, EnumMemberModel>(item, all)
{
  protected override Func<AliasedModel, EnumMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

internal class EnumMemberRenderer
  : AliasedRenderer<EnumMemberModel>
{
  internal override RenderStructure Render(EnumMemberModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("enum", model.OfEnum);
}

internal class TypeUnionRenderer(
  IRenderer<AliasedModel> item,
  IRenderer<UnionMemberModel> all
) : ParentTypeRenderer<TypeUnionModel, AliasedModel, UnionMemberModel>(item, all)
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
