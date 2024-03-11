using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeEnumModel(
  string Name
) : ChildTypeModel<TypeRefModel<SimpleKindModel>>(TypeKindModel.Enum, Name)
{
  public AliasedModel[] Members { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
  {
    Func<AliasedModel, EnumMemberModel> NewMember(string parent)
      => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };

    List<EnumMemberModel> all = [
      .. Members.Select(NewMember(Name))];

    if (context.TryGetType(Parent?.Name, out var parentType) && parentType is TypeEnumModel parent) {
      all.AddRange(parent.Members.Select(NewMember(Parent!.Name)));
    }

    return base.Render(context)
        .Add("members", Members.Render(context))
        .Add("allMembers", all.Render(context));
  }
}

internal record class EnumMemberModel(
  string Name,
  string OfEnum
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("enum", OfEnum);
}

internal record class EnumValueModel(
  string Name,
  string Value
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
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
    };

  internal static AliasedModel ToMember(EnumMemberAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}
