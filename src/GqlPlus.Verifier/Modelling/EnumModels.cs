﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeEnumModel(
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
      Items = [.. ast.Members.Select(ToMember)],
    };

  internal static AliasedModel ToMember(EnumMemberAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}
