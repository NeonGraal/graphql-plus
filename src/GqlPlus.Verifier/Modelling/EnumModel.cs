using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class EnumModel(string Name)
  : ModelAliased(Name)
{
  public string? Extends { get; set; }
  public EnumMemberModel[] Members { get; set; } = [];

  protected override string Tag => "Enum";

  internal override RenderStructure Render()
    => base.Render()
      .Add("extends", new("_TypeRef(_TypeKind.Enum)", Extends))
      .Add("members", new("", Members.Render()));
}

internal record class EnumMemberModel(string Name, string OfEnum)
  : ModelAliased(Name)
{
  protected override string Tag => "EnumMember";

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
      Extends = ast.Extends,
      Members = [.. ast.Members.Select(m => ToMember(m, ast.Name))],
    };

  internal EnumMemberModel ToMember(EnumMemberAst ast, string ofEnum)
    => new(ast.Name, ofEnum) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}
