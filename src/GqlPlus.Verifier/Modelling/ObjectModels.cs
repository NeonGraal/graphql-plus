using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class TypeObjectModel<TBase, TField>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<BaseDescribedModel<TBase>>(Kind, Name)
  where TBase : IObjBaseModel
  where TField : ModelBase
{
  internal DescribedModel[] TypeParameters { get; set; } = [];
  internal TField[] Fields { get; set; } = [];
  internal AlternateModel<TBase>[] Alternates { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("parameters", TypeParameters.Render(context))
      .Add("fields", Fields.Render(context))
      .Add("alternates", Alternates.Render(context));
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

  internal override RenderStructure Render(IRenderContext context)
    => TypeRef is not null ? TypeRef.Render(context)
      : BaseRef is not null ? BaseRef.Render(context)
      : new("");
}

public record class ObjBaseModel<TArg>
  : ModelBase, IObjBaseModel
  where TArg : IRendering
{
  internal TArg[] Arguments { get; set; } = [];
  public bool IsTypeParameter { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("arguments", Arguments.Render(context));
}

public interface IObjBaseModel : IRendering
{ }

public record class AlternateModel<TBase>(
  BaseDescribedModel<ObjRefModel<TBase>> Type
) : ModelBase
  where TBase : IObjBaseModel
{
  internal CollectionModel[] Collections { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("type", Type.Render(context))
      .Add("collections", Collections.Render(context));
}

public record class FieldModel<TBase>(
  string Name,
  ObjRefModel<TBase>? Type
) : AliasedModel(Name)
  where TBase : IObjBaseModel
{
  internal ModifierModel[] Modifiers { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("modifiers", Modifiers.Render(context, flow: true))
      .Add("type", Type?.Render(context));
}

public record class ParameterModel(
  BaseDescribedModel<ObjRefModel<InputBaseModel>> Type
) : AlternateModel<InputBaseModel>(Type)
{
  public ConstantModel? Default { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("default", Default?.Render(context));
}

internal abstract class ModellerObject<TAst, TRefAst, TFieldAst, TModel, TBase, TField>(
  TypeKindModel kind,
  IAlternateModeller<TRefAst, TBase> alternate,
  IModeller<TFieldAst, TField> field,
  IModeller<TRefAst, TBase> reference
) : ModellerType<TAst, TRefAst, TModel>(kind)
  where TAst : AstType<TRefAst>
  where TRefAst : AstReference<TRefAst>
  where TFieldAst : AstField<TRefAst>
  where TModel : BaseTypeModel
  where TBase : IObjBaseModel
  where TField : IRendering
{
  internal BaseDescribedModel<TBase>? ParentModel(TRefAst? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? null : new BaseDescribedModel<TBase>(BaseModel(parent, typeKinds));

  internal AlternateModel<TBase>[] AlternatesModels(AstAlternate<TRefAst>[] alternates, IMap<TypeKindModel> typeKinds)
    => alternate.ToModels(alternates, typeKinds);

  internal TField[] FieldsModels(TFieldAst[] fields, IMap<TypeKindModel> typeKinds)
    => field.ToModels(fields, typeKinds);

  protected TBase BaseModel(TRefAst ast, IMap<TypeKindModel> typeKinds)
    => reference.ToModel<TBase>(ast, typeKinds);
}

internal abstract class ModellerReference<TRefAst, TBase, TArg>
  : ModellerBase<TRefAst, TBase>
  where TRefAst : AstReference<TRefAst>
  where TBase : IObjBaseModel
  where TArg : IRendering
{
  internal TArg[] ModelArguments(TRefAst ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Arguments.Select(a => NewArgument(a, typeKinds))];

  internal abstract TArg NewArgument(TRefAst ast, IMap<TypeKindModel> typeKinds);
}

internal abstract class ModellerReference<TRefAst, TBase>
  : ModellerReference<TRefAst, TBase, ObjRefModel<TBase>>
  where TRefAst : AstReference<TRefAst>
  where TBase : IObjBaseModel
{
  internal override ObjRefModel<TBase> NewArgument(TRefAst ast, IMap<TypeKindModel> typeKinds)
    => new(ToModel(ast, typeKinds));
}

internal class AlternateModeller<TRefAst, TBase>(
  IModeller<TRefAst, TBase> refBase,
  IModeller<ModifierAst, CollectionModel> modifier
) : ModellerBase<AstAlternate<TRefAst>, AlternateModel<TBase>>, IAlternateModeller<TRefAst, TBase>
  where TRefAst : AstReference<TRefAst>
  where TBase : IObjBaseModel
{
  internal override AlternateModel<TBase> ToModel(AstAlternate<TRefAst> ast, IMap<TypeKindModel> typeKinds)
    => new(new(new(BaseModel(ast.Type, typeKinds))) {
      Description = ast.Description
    }) {
      Collections = modifier.ToModels(ast.Modifiers, typeKinds)
    };

  private TBase BaseModel(TRefAst ast, IMap<TypeKindModel> typeKinds)
    => refBase.ToModel(ast, typeKinds);
}

public interface IAlternateModeller<TRefAst, TBase>
  : IModeller<AstAlternate<TRefAst>, AlternateModel<TBase>>
  where TRefAst : AstReference<TRefAst>
  where TBase : IObjBaseModel
{ }

internal class ParameterModeller(
  IAlternateModeller<InputReferenceAst, InputBaseModel> alternate,
  IModeller<ConstantAst, ConstantModel> constant
) : ModellerBase<ParameterAst, ParameterModel>
{
  internal override ParameterModel ToModel(ParameterAst ast, IMap<TypeKindModel> typeKinds)
  {
    var altModel = alternate.ToModel(ast, typeKinds);
    return new(altModel.Type) {
      Collections = altModel.Collections,
      Default = constant.TryModel(ast.Default, typeKinds),
    };
  }
}
