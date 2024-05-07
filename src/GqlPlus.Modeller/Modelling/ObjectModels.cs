using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public abstract record class TypeObjectModel<TObjBase, TObjField>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<BaseDescribedModel<TObjBase>>(Kind, Name)
  , ITypeObjectModel
  where TObjBase : IObjBaseModel
  where TObjField : ModelBase
{
  internal DescribedModel[] TypeParameters { get; set; } = [];
  internal TObjField[] Fields { get; set; } = [];
  internal AlternateModel<TObjBase>[] Alternates { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
  {
    List<ModelBase> allAlternates = [];
    List<ModelBase> allFields = [];

    void AddMembers(ITypeObjectModel model)
    {
      allAlternates.AddRange(model.AllAlternates);
      allFields.AddRange(model.AllFields);
    }

    ForParent<ITypeObjectModel>(context, AddMembers);
    AddMembers(this);

    return base.Render(context)
        .Add("typeParameters", TypeParameters.Render(context))
        .Add("fields", Fields.Render(context))
        .Add("allFields", allFields.Render(context))
        .Add("alternates", Alternates.Render(context))
        .Add("allAlternates", allAlternates.Render(context));
  }

  internal override bool GetParentModel<TModel>(IRenderContext context, [NotNullWhen(true)] out TModel? model)
    where TModel : default
  {
    if (Parent?.Base.IsTypeParameter == false) {
      return base.GetParentModel(context, out model);
    }

    model = default;
    return false;
  }

  IEnumerable<ModelBase> ITypeObjectModel.AllAlternates
    => Alternates.Select(a => new ObjectForModel<AlternateModel<TObjBase>>(a, Name));
  IEnumerable<ModelBase> ITypeObjectModel.AllFields
    => Fields.Select(f => new ObjectForModel<TObjField>(f, Name));
}

internal interface ITypeObjectModel
  : IChildTypeModel
{
  IEnumerable<ModelBase> AllAlternates { get; }
  IEnumerable<ModelBase> AllFields { get; }
}

public record class ObjRefModel<TObjBase>
  : ModelBase
  where TObjBase : IObjBaseModel
{
  internal TypeRefModel<SimpleKindModel>? TypeRef { get; private init; }

  internal TObjBase? BaseRef { get; private init; }

  public ObjRefModel(TypeRefModel<SimpleKindModel> typeRef)
    => TypeRef = typeRef;
  public ObjRefModel(TObjBase baseRef)
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

public interface IObjBaseModel
  : IRendering
{
  bool IsTypeParameter { get; }
}

public record class AlternateModel<TObjBase>(
  BaseDescribedModel<ObjRefModel<TObjBase>> Type
) : ModelBase
  where TObjBase : IObjBaseModel
{
  internal CollectionModel[] Collections { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("type", Type.Render(context))
      .Add("collections", Collections.Render(context));
}

public record class ObjectForModel<TFor>(
  TFor For,
  string Obj
) : ModelBase
  where TFor : IRendering
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add(For, context)
      .Add("object", Obj);
}

public record class ObjFieldModel<TObjBase>(
  string Name,
  ObjRefModel<TObjBase>? Type
) : AliasedModel(Name)
  where TObjBase : IObjBaseModel
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
  public ConstantModel? DefaultValue { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("default", DefaultValue?.Render(context));
}

internal abstract class ModellerObject<TAst, TObjBaseAst, TObjFieldAst, TModel, TObjBase, TObjField>(
  TypeKindModel kind,
  IAlternateModeller<TObjBaseAst, TObjBase> alternate,
  IModeller<TObjFieldAst, TObjField> objField,
  IModeller<TObjBaseAst, TObjBase> objBase
) : ModellerType<TAst, TObjBaseAst, TModel>(kind)
  where TAst : AstType<TObjBaseAst>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>
  where TObjFieldAst : AstObjectField<TObjBaseAst>
  where TModel : BaseTypeModel
  where TObjBase : IObjBaseModel
  where TObjField : ObjFieldModel<TObjBase>
{
  internal BaseDescribedModel<TObjBase>? ParentModel(TObjBaseAst? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? null : new BaseDescribedModel<TObjBase>(BaseModel(parent, typeKinds));

  internal AlternateModel<TObjBase>[] AlternatesModels(AstAlternate<TObjBaseAst>[] alternates, IMap<TypeKindModel> typeKinds)
    => alternate.ToModels(alternates, typeKinds);

  internal TObjField[] FieldsModels(TObjFieldAst[] fields, IMap<TypeKindModel> typeKinds)
    => objField.ToModels(fields, typeKinds);

  internal DescribedModel[] TypeParametersModels(TypeParameterAst[] typeParameters)
    => [.. typeParameters.Select(p => new DescribedModel(p.Name) { Description = p.Description })];

  protected TObjBase BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => objBase.ToModel<TObjBase>(ast, typeKinds);
}

internal abstract class ModellerObjBase<TObjBaseAst, TObjBase, TArg>
  : ModellerBase<TObjBaseAst, TObjBase>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>
  where TObjBase : IObjBaseModel
  where TArg : IRendering
{
  internal TArg[] ModelArguments(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Arguments.Select(a => NewArgument(a, typeKinds))];

  internal abstract TArg NewArgument(TObjBaseAst ast, IMap<TypeKindModel> typeKinds);
}

internal abstract class ModellerObjBase<TObjBaseAst, TObjBase>
  : ModellerObjBase<TObjBaseAst, TObjBase, ObjRefModel<TObjBase>>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>
  where TObjBase : IObjBaseModel
{
  internal override ObjRefModel<TObjBase> NewArgument(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => new(ToModel(ast, typeKinds));
}

internal abstract class ModellerObjField<TObjBaseAst, TObjFieldAst, TObjBase, TObjField>(
  IModifierModeller modifier,
  IModeller<TObjBaseAst, TObjBase> refBase
) : ModellerBase<TObjFieldAst, TObjField>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>
  where TObjFieldAst : AstObjectField<TObjBaseAst>
  where TObjBase : IObjBaseModel
  where TObjField : ObjFieldModel<TObjBase>
{
  protected override TObjField ToModel(TObjFieldAst field, IMap<TypeKindModel> typeKinds)
    => FieldModel(field, new(refBase.ToModel(field.Type, typeKinds)), typeKinds) with {
      Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers, typeKinds),
    };

  protected abstract TObjField FieldModel(TObjFieldAst ast, ObjRefModel<TObjBase> type, IMap<TypeKindModel> typeKinds);
}

internal class AlternateModeller<TObjBaseAst, TObjBase>(
  IModeller<TObjBaseAst, TObjBase> refBase,
  IModeller<IGqlpModifier, CollectionModel> modifier
) : ModellerBase<AstAlternate<TObjBaseAst>, AlternateModel<TObjBase>>
  , IAlternateModeller<TObjBaseAst, TObjBase>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>
  where TObjBase : IObjBaseModel
{
  protected override AlternateModel<TObjBase> ToModel(AstAlternate<TObjBaseAst> ast, IMap<TypeKindModel> typeKinds)
    => new(new(new(BaseModel(ast.Type, typeKinds))) {
      Description = ast.Description
    }) {
      Collections = modifier.ToModels(ast.Modifiers, typeKinds)
    };

  private TObjBase BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => refBase.ToModel(ast, typeKinds);
}

public interface IAlternateModeller<TObjBaseAst, TObjBase>
  : IModeller<AstAlternate<TObjBaseAst>, AlternateModel<TObjBase>>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>
  where TObjBase : IObjBaseModel
{ }

internal class ParameterModeller(
  IAlternateModeller<InputBaseAst, InputBaseModel> alternate,
  IModeller<ConstantAst, ConstantModel> constant
) : ModellerBase<ParameterAst, ParameterModel>
{
  protected override ParameterModel ToModel(ParameterAst ast, IMap<TypeKindModel> typeKinds)
  {
    AlternateModel<InputBaseModel> altModel = alternate.ToModel(ast, typeKinds);
    return new(altModel.Type) {
      Collections = altModel.Collections,
      DefaultValue = constant.TryModel(ast.DefaultValue, typeKinds),
    };
  }
}
