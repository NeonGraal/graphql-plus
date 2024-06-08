namespace GqlPlus.Models;

public record class TypeEnumModel(
  string Name
) : ParentTypeModel<AliasedModel, EnumMemberModel>(TypeKindModel.Enum, Name)
{
  protected override Func<AliasedModel, EnumMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

public record class EnumMemberModel(
  string Name,
  string OfEnum
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("enum", OfEnum);
}

public record class EnumValueModel(
  string Name,
  string Member
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("member", Member);
}
