using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

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

internal class EnumModeller
  : ModellerType<IGqlpEnum, string, TypeEnumModel>
{
  public EnumModeller()
    : base(TypeKindModel.Enum)
  { }

  protected override TypeEnumModel ToModel(IGqlpEnum ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Enum),
      Items = [.. ast.Items.Select(ToMember)],
    };

  internal static AliasedModel ToMember(IGqlpEnumItem ast)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
    };
}
