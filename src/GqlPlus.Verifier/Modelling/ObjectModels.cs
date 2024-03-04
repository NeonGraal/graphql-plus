using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class TypeObjectModel<TBase, TField>(TypeKindModel Kind, string Name)
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

public record class ObjRefModel<TBase>
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

public record class ObjBaseModel<TArg>
  : ModelBase, IObjBaseModel
{
  internal TArg[] Arguments { get; set; } = [];
  internal string? TypeParameter { get; set; }
}

public interface IObjBaseModel : IRendering
{ }

public record class AlternateModel<TBase>(DescribedModel<ObjRefModel<TBase>> Type)
  : ModelBase
  where TBase : IObjBaseModel
{
  internal CollectionModel[] Collections { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("type", Type.Render())
      .Add("collections", Collections.Render());
}

public record class FieldModel<TBase>(string Name, ObjRefModel<TBase> Type)
  : AliasedModel(Name)
  where TBase : IObjBaseModel
{
  internal ModifierModel[] Modifiers { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("type", Type.Render());
}

public record class ParameterModel(DescribedModel<ObjRefModel<InputBaseModel>> Type)
  : AlternateModel<InputBaseModel>(Type)
{
  public ConstantModel? Default { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("default", Default?.Render());
}

internal abstract class ModellerObject<TAst, TRefAst, TFieldAst, TModel, TBase, TField>(
  IModeller<AstAlternate<TRefAst>, AlternateModel<TBase>> alternate,
  IModeller<ModifierAst, ModifierModel> modifier,
  IModeller<TRefAst, TBase> reference
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
    => alternate.ToModels(alternates);

  internal TField[] FieldsModels(TFieldAst[] fields)
    => [.. fields.Select(FieldModel)];

  internal ModifierModel[] ModifiersModels(ModifierAst[] modifiers)
    => modifier.ToModels(modifiers);

  protected TBase BaseModel(TRefAst ast)
    => reference.ToModel<TBase>(ast);

  protected abstract TField FieldModel(TFieldAst field);
}

internal class AlternateModeller<TRefAst, TBase>(
  IModeller<TRefAst, TBase> refBase,
  IModeller<ModifierAst, CollectionModel> modifier
) : ModellerBase<AstAlternate<TRefAst>, AlternateModel<TBase>>
  where TRefAst : AstReference<TRefAst>
  where TBase : IObjBaseModel
{
  internal override AlternateModel<TBase> ToModel(AstAlternate<TRefAst> ast)
    => new(new(new(BaseModel(ast.Type))) { Description = ast.Description }) { Collections = modifier.ToModels(ast.Modifiers) };

  private TBase BaseModel(TRefAst ast)
    => refBase.ToModel(ast);
}

internal class ParameterModeller(
  IModeller<AstAlternate<InputReferenceAst>, AlternateModel<InputBaseModel>> alternate,
  IModeller<ConstantAst, ConstantModel> constant
) : ModellerBase<ParameterAst, ParameterModel>
{
  internal override ParameterModel ToModel(ParameterAst ast)
  {
    var altModel = alternate.ToModel(ast);
    return new(altModel.Type) {
      Collections = altModel.Collections,
      Default = constant.TryModel(ast.Default),
    };
  }
}
