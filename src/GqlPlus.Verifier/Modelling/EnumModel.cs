using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class EnumModel(string Name)
  : ChildTypeModel<TypeRefModel<SimpleKindModel>>(TypeKindModel.Enum, Name)
{
  public EnumMemberModel[] Members { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("members", new("", Members.Render()))
      .Add("allMembers", new("", Members.Render()));
}

internal record class EnumMemberModel(string Name, string OfEnum)
  : AliasedModel(Name)
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("enum", new("", OfEnum));
}

internal class EnumModeller
  : ModellerType<EnumDeclAst, string, EnumModel>
{
  internal override EnumModel ToModel(EnumDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Enum),
      Members = [.. ast.Members.Select(ToMember(ast.Name))],
      // Todo: AllMembers from Enum Parent
    };

  internal static Func<EnumMemberAst, EnumMemberModel> ToMember(string ofEnum)
    => ast => new(ast.Name, ofEnum) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}

internal record class EnumValueModel(string Name, string Value)
  : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("value", new("", Value));
}
