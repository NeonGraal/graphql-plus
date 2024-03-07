using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeEnumModel(
  string Name
) : ChildTypeModel<TypeRefModel<SimpleKindModel>>(TypeKindModel.Enum, Name)
{
  public AliasedModel[] Members { get; set; } = [];
  public EnumMemberModel[] AllMembers { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("members", Members.Render())
      .Add("allMembers", AllMembers.Render());
}

internal record class EnumMemberModel(
  string Name,
  string OfEnum
) : AliasedModel(Name)
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("enum", OfEnum);
}

internal record class EnumValueModel(
  string Name,
  string Value
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("value", Value);
}

internal class EnumModeller
  : ModellerType<EnumDeclAst, string, TypeEnumModel>
{
  internal override TypeEnumModel ToModel(EnumDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Enum),
      Members = [.. ast.Members.Select(ToMember)],
      AllMembers = [.. ast.Members.Select(ToEnumMember(ast.Name))],
    };

  internal static AliasedModel ToMember(EnumMemberAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };

  internal static Func<EnumMemberAst, EnumMemberModel> ToEnumMember(string ofEnum)
    => ast => new(ast.Name, ofEnum) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}
