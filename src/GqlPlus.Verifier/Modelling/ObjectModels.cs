﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeObjectModel<TBase, TField>(TypeKindModel Kind, string Name)
  : ChildTypeModel<DescribedModel<TBase>>(Kind, Name)
  where TBase : IObjBaseModel
  where TField : ModelBase
{
  internal DescribedModel<NamedModel>[] TypeParameters { get; set; } = [];
  internal TField[] Fields { get; set; } = [];
  internal AlternateModel<TBase>[] Alternates { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("parameters", TypeParameters.Render())
      .Add("fields", Fields.Render())
      .Add("alternates", Alternates.Render());
}

internal record class ObjRefModel<TBase>
  : ModelBase
  where TBase : IObjBaseModel
{
  internal TypeRefModel<SimpleKindModel>? TypeRef { get; private init; }

  internal TBase? BaseRef { get; private init; }

  public ObjRefModel(TypeRefModel<SimpleKindModel> typeRef)
    => TypeRef = typeRef;
  public ObjRefModel(TBase baseRef)
    => BaseRef = baseRef;

  internal override RenderStructure Render()
    => TypeRef is not null ? TypeRef.Render()
      : BaseRef is not null ? BaseRef.Render()
      : new("");
}

internal record class ObjBaseModel<TArg>
  : ModelBase, IObjBaseModel
{
  internal TArg[] Arguments { get; set; } = [];
  internal string? TypeParameter { get; set; }
}

internal interface IObjBaseModel : IRendering
{ }

internal record class AlternateModel<TBase>(DescribedModel<ObjRefModel<TBase>> Type)
  : ModelBase
  where TBase : IObjBaseModel
{
  internal CollectionModel[] Collections { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("type", Type.Render())
      .Add("collections", Collections.Render());
}

internal record class FieldModel<TBase>(string Name, ObjRefModel<TBase> Type)
  : AliasedModel(Name)
  where TBase : IObjBaseModel
{
  internal ModifierModel[] Modifiers { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("type", Type.Render());
}

internal record class ParameterModel(DescribedModel<ObjRefModel<InputBaseModel>> Type)
  : AlternateModel<InputBaseModel>(Type)
{
  public ConstantModel? Default { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("default", Default?.Render());
}

internal abstract class ModellerObject<TAst, TRefAst, TFieldAst, TModel, TBase, TField>(
  IModeller<AstAlternate<TRefAst>> alternate,
  IModeller<ModifierAst> modifier,
  IModeller<TRefAst> reference
) : ModellerType<TAst, TRefAst, TModel>
  where TAst : AstType<TRefAst>
  where TRefAst : AstReference<TRefAst>
  where TFieldAst : AstField<TRefAst>
  where TModel : IRendering
  where TBase : IObjBaseModel
  where TField : IRendering
{
  internal DescribedModel<TBase>? ParentModel(TRefAst? parent)
    => parent is null ? null : new DescribedModel<TBase>(BaseModel(parent));

  internal AlternateModel<TBase>[] AlternatesModels(AstAlternate<TRefAst>[] alternates)
    => alternate.ToModels<AlternateModel<TBase>>(alternates);

  internal TField[] FieldsModels(TFieldAst[] fields)
    => [.. fields.Select(FieldModel)];

  internal ModifierModel[] ModifiersModels(ModifierAst[] modifiers)
    => modifier.ToModels<ModifierModel>(modifiers);

  protected TBase BaseModel(TRefAst ast)
    => reference.ToModel<TBase>(ast);

  protected abstract TField FieldModel(TFieldAst field);
}

internal class AlternateModeller<TRefAst, TBase>(
  IModeller<TRefAst> refBase,
  IModeller<ModifierAst> modifier
) : ModellerBase<AstAlternate<TRefAst>, AlternateModel<TBase>>
  where TRefAst : AstReference<TRefAst>
  where TBase : IObjBaseModel
{
  internal override AlternateModel<TBase> ToModel(AstAlternate<TRefAst> ast)
    => new(new(new(BaseModel(ast.Type))) { Description = ast.Description }) { Collections = modifier.ToModels<CollectionModel>(ast.Modifiers) };

  private TBase BaseModel(TRefAst ast)
    => refBase.ToModel<TBase>(ast);
}

internal class ParameterModeller(
  IModeller<AstAlternate<InputReferenceAst>> alternate,
  IModeller<ConstantAst> constant
) : ModellerBase<ParameterAst, ParameterModel>
{
  internal override ParameterModel ToModel(ParameterAst ast)
  {
    var altModel = alternate.ToModel<AlternateModel<InputBaseModel>>(ast);
    return new(altModel.Type) {
      Collections = altModel.Collections,
      Default = constant.TryModel<ConstantModel>(ast.Default),
    };
  }
}
