﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class OutputModel(string Name)
  : TypeObjectModel<OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, Name)
{
}

internal class OutputModeller(
  IModeller<AstAlternate<OutputReferenceAst>> alternate,
  IModeller<ModifierAst> modifier,
  IModeller<OutputReferenceAst> reference
) : ModellerObjectType<OutputDeclAst, OutputReferenceAst, OutputFieldAst, OutputModel, OutputBaseModel, OutputFieldModel>(alternate, modifier, reference)
{
  protected override OutputFieldModel FieldModel(OutputFieldAst field)
    => new(field.Name, new(BaseModel(field.Type))) {
      Modifiers = ModifiersModels(field.Modifiers),
    };

  internal override OutputModel ToModel(OutputDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent),
      Fields = FieldsModels(ast.Fields),
      Alternates = AlternatesModels(ast.Alternates),
    };
}

internal record class OutputBaseModel(string Output)
  : TypeBaseModel<RefModel<OutputArgumentModel>>
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("output", Output);
}

internal class OutputReferenceModeller
  : ModellerBase<OutputReferenceAst, OutputBaseModel>
{
  internal override OutputBaseModel ToModel(OutputReferenceAst ast)
    => new(ast.Name);
}

internal record class OutputFieldModel(string Name, RefModel<OutputBaseModel> Type)
  : FieldModel<OutputBaseModel>(Name, Type)
{
  internal ParameterModel[] Parameters { get; set; } = [];
  internal OutputEnumModel? Enum { get; set; }
}

internal record class OutputArgumentModel(string Name)
  : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name), ITypeBaseModel
{
  internal string? EnumValue { get; set; }
  internal RefModel<OutputBaseModel>? Ref { get; set; }
}

internal record class OutputEnumModel(string Name, string Field, string Value)
  : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{ }
