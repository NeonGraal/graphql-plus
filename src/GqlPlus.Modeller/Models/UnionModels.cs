namespace GqlPlus.Models;

public record class TypeUnionModel(
  string Name
) : ParentTypeModel<AliasedModel, UnionMemberModel>(TypeKindModel.Union, Name)
{
  protected override Func<AliasedModel, UnionMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

public record class UnionMemberModel(
  string Name,
  string OfUnion
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("union", OfUnion);
}
