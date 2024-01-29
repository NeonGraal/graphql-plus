using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class EnumModel(string Name)
  : ModelBaseType(TypeKindModel.Enum, Name)
{
  public TypeRefModel<SimpleKindModel>? Parent { get; set; }
  public EnumMemberModel[] Members { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("parent", Parent?.Render())
      .Add("members", new("", Members.Render()));
}

internal record class EnumMemberModel(string Name, string OfEnum)
  : ModelAliased(Name)
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("enum", new("", OfEnum));
}

internal class EnumModeller
  : ModellerBase<EnumDeclAst, EnumModel>
{
  internal override EnumModel ToModel(EnumDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Enum),
      Members = [.. ast.Members.Select(m => ToMember(m, ast.Name))],
    };

  internal EnumMemberModel ToMember(EnumMemberAst ast, string ofEnum)
    => new(ast.Name, ofEnum) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}
