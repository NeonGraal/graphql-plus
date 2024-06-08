using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Objects;

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

public record class ObjBaseModel<TArg>
  : ModelBase, IObjBaseModel
  where TArg : IRendering
{
  internal TArg[] TypeArguments { get; set; } = [];
  public bool IsTypeParameter { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("typeArguments", TypeArguments.Render(context));
}

public interface IObjBaseModel
  : IRendering
{
  bool IsTypeParameter { get; }
}

public record class AlternateModel<TObjBase>(
  BaseDescribedModel<TObjBase> Type
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
  TObjBase? Type
) : AliasedModel(Name)
  where TObjBase : IObjBaseModel
{
  internal ModifierModel[] Modifiers { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("modifiers", Modifiers.Render(context, flow: true))
      .Add("type", Type?.Render(context));
}

internal abstract class ModellerObject<TAst, TObjBaseAst, TObjFieldAst, TModel, TObjBase, TObjField>(
  TypeKindModel kind,
  IAlternateModeller<TObjBaseAst, TObjBase> alternate,
  IModeller<TObjFieldAst, TObjField> objField,
  IModeller<TObjBaseAst, TObjBase> objBase
) : ModellerType<TAst, TObjBaseAst, TModel>(kind)
  where TAst : IGqlpType<TObjBaseAst>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>, IEquatable<TObjBaseAst>
  where TObjFieldAst : IGqlpObjectField<TObjBaseAst>
  where TModel : BaseTypeModel
  where TObjBase : IObjBaseModel
  where TObjField : ObjFieldModel<TObjBase>
{
  internal BaseDescribedModel<TObjBase>? ParentModel(TObjBaseAst? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? null : new BaseDescribedModel<TObjBase>(BaseModel(parent, typeKinds));

  internal AlternateModel<TObjBase>[] AlternatesModels(IEnumerable<IGqlpAlternate<TObjBaseAst>> alternates, IMap<TypeKindModel> typeKinds)
    => alternate.ToModels(alternates, typeKinds);

  internal TObjField[] FieldsModels(IEnumerable<TObjFieldAst> fields, IMap<TypeKindModel> typeKinds)
    => objField.ToModels(fields, typeKinds);

  internal DescribedModel[] TypeParametersModels(IEnumerable<IGqlpTypeParameter> typeParameters)
    => [.. typeParameters.Select(p => new DescribedModel(p.Name) { Description = p.Description })];

  protected TObjBase BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => objBase.ToModel<TObjBase>(ast, typeKinds);
}

internal abstract class ModellerObjBase<TObjBaseAst, TObjBase, TArg>
  : ModellerBase<TObjBaseAst, TObjBase>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>
  where TObjBase : IObjBaseModel
  where TArg : IRendering
{
  internal TArg[] ModelArguments(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.TypeArguments.Select(a => NewArgument(a, typeKinds))];

  internal abstract TArg NewArgument(TObjBaseAst ast, IMap<TypeKindModel> typeKinds);
}

internal abstract class ModellerObjBase<TObjBaseAst, TObjBase>
  : ModellerObjBase<TObjBaseAst, TObjBase, TObjBase>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>
  where TObjBase : IObjBaseModel
{
  internal override TObjBase NewArgument(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => ToModel(ast, typeKinds);
}

internal abstract class ModellerObjField<TObjBaseAst, TObjFieldAst, TObjBase, TObjField>(
  IModifierModeller modifier,
  IModeller<TObjBaseAst, TObjBase> objBase
) : ModellerBase<TObjFieldAst, TObjField>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>
  where TObjFieldAst : IGqlpObjectField<TObjBaseAst>
  where TObjBase : IObjBaseModel
  where TObjField : ObjFieldModel<TObjBase>
{
  protected override TObjField ToModel(TObjFieldAst field, IMap<TypeKindModel> typeKinds)
    => FieldModel(field, objBase.ToModel(field.Type, typeKinds), typeKinds) with {
      Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers, typeKinds),
    };

  protected abstract TObjField FieldModel(TObjFieldAst ast, TObjBase type, IMap<TypeKindModel> typeKinds);
}

internal class AlternateModeller<TObjBaseAst, TObjBase>(
  IModeller<TObjBaseAst, TObjBase> refBase,
  IModeller<IGqlpModifier, CollectionModel> modifier
) : ModellerBase<IGqlpAlternate<TObjBaseAst>, AlternateModel<TObjBase>>
  , IAlternateModeller<TObjBaseAst, TObjBase>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>, IEquatable<TObjBaseAst>
  where TObjBase : IObjBaseModel
{
  protected override AlternateModel<TObjBase> ToModel(IGqlpAlternate<TObjBaseAst> ast, IMap<TypeKindModel> typeKinds)
    => new(new(BaseModel(ast.Type, typeKinds)) {
      Description = ast.Description
    }) {
      Collections = modifier.ToModels(ast.Modifiers, typeKinds)
    };

  private TObjBase BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => refBase.ToModel(ast, typeKinds);
}

public interface IAlternateModeller<TObjBaseAst, TObjBase>
  : IModeller<IGqlpAlternate<TObjBaseAst>, AlternateModel<TObjBase>>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>, IEquatable<TObjBaseAst>
  where TObjBase : IObjBaseModel
{ }
