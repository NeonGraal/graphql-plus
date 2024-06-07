using System.Diagnostics.CodeAnalysis;

using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public abstract record class TypeObjectModel<TObjBase, TObjField>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<ObjDescribedModel<TObjBase>>(Kind, Name)
  , ITypeObjectModel
  where TObjBase : class, IObjBaseModel
  where TObjField : ObjFieldModel<TObjBase>
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
      if (base.GetParentModel(context, out model)) {
        if (Parent.Base is ObjBaseModel<TObjBase> baseParent
          && model is ITypeObjectModel objectModel
          && baseParent.TypeArguments.Length > 0
          && objectModel.TypeParameters.Length >= baseParent.TypeArguments.Length) {
          Map<IObjBaseModel> arguments = baseParent.TypeArguments
            .Select((a, i) => (objectModel.TypeParameters[i].Name, (IObjBaseModel)a))
            .ToMap();
          model = (TModel)objectModel.Apply(arguments);
        }

        return true;
      }
    }

    model = default;
    return false;
  }

  protected override string? ParentName(ObjDescribedModel<TObjBase>? parent)
    => BaseName(parent?.Base);

  protected bool GetArgument(Map<IObjBaseModel> arguments, TObjBase? type, [NotNullWhen(true)] out TObjBase? value)
  {
    ArgumentNullException.ThrowIfNull(arguments);

    value = null;

    bool applied = false;

    TObjBase ApplyArgument(TObjBase argument)
    {
      if (GetArgument(arguments, argument, out TObjBase? argumentModel)) {
        return argumentModel;
      }

      return argument;
    }

    // TObjBase[] typeArguments = [.. (TObjBase)type?.Cast<TObjBase>.TypeArguments.Select(ApplyArgument)];

    if (type?.IsTypeParameter == true) {
      string argumentName = BaseName(type);
      if (arguments.TryGetValue(argumentName, out IObjBaseModel? typeBase)
        && typeBase is TObjBase objBase
    ) {
        if (objBase?.IsTypeParameter == true
          && string.Equals(argumentName, BaseName(objBase), StringComparison.Ordinal)) {
          return false;
        }

        value = objBase;
        return true;
      }
    }

    return false;
  }

  protected bool GetArgument(
    Map<IObjBaseModel> arguments,
    string? type,
    [NotNullWhen(true)] out (string Key, bool Param)? value)
  {
    ArgumentNullException.ThrowIfNull(arguments);

    if (arguments.TryGetValue(type ?? "", out IObjBaseModel? typeBase)) {
      if (typeBase is TObjBase objBase) {
        value = (BaseName(objBase), objBase.IsTypeParameter);
        return true;
      }
    }

    value = null;
    return false;
  }

  protected TypeObjectModel<TObjBase, TObjField> Apply(Map<IObjBaseModel> arguments)
  {
    ArgumentNullException.ThrowIfNull(arguments);
    TypeObjectModel<TObjBase, TObjField> result = (TypeObjectModel<TObjBase, TObjField>)MemberwiseClone();

    if (GetArgument(arguments, Parent?.Base, out TObjBase? parentModel)
      && parentModel is not null) {
      result.Parent = new(parentModel) { Description = Parent?.Description };
    }

    result.Alternates = [.. Alternates.Select(a => ApplyAlternate(a, arguments))];

    result.Fields = [.. Fields.Select(f => ApplyField(f, arguments))];

    return result;
  }

  private AlternateModel<TObjBase> ApplyAlternate(AlternateModel<TObjBase> alternate, Map<IObjBaseModel> arguments)
  {
    bool applied = false;
    CollectionModel ApplyCollection(CollectionModel collection)
    {
      if (collection.ModifierKind == ModifierKind.Param
        && GetArgument(arguments, collection.Key, out (string Key, bool Param)? newKey)) {
        applied = true;
        return collection.MakeKey(newKey.Value);
      }

      return collection;
    }

    CollectionModel[] collections = [.. alternate.Collections.Select(ApplyCollection)];

    if (GetArgument(arguments, alternate.Type.Base, out TObjBase? typeModel)) {
      return new(new(typeModel)) { Collections = collections };
    } else {
      return applied
        ? (alternate with { Collections = collections })
        : alternate;
    }
  }

  private TObjField ApplyField(TObjField field, Map<IObjBaseModel> arguments)
  {
    bool applied = false;
    ModifierModel ApplyModifier(ModifierModel modifier)
    {
      if (modifier.ModifierKind == ModifierKind.Param
        && GetArgument(arguments, modifier.Key, out (string Key, bool Param)? newKey)) {
        applied = true;
        return modifier.MakeKey(newKey.Value);
      }

      return modifier;
    }

    ModifierModel[] modifiers = [.. field.Modifiers.Select(ApplyModifier)];

    if (GetArgument(arguments, field.Type, out TObjBase? typeModel)) {
      return NewField(field, typeModel, modifiers);
    } else {
      return applied ? NewField(field, field.Type!, modifiers) : field;
    }
  }

  protected abstract TObjField NewField(TObjField field, TObjBase typeModel, ModifierModel[] modifiers);
  protected abstract string BaseName(TObjBase? objBase);

  ITypeObjectModel ITypeObjectModel.Apply(Map<IObjBaseModel> arguments) => Apply(arguments);
  IEnumerable<ModelBase> ITypeObjectModel.AllAlternates
    => Alternates.Select(a => new ObjectForModel<AlternateModel<TObjBase>>(a, Name));
  IEnumerable<ModelBase> ITypeObjectModel.AllFields
    => Fields.Select(f => new ObjectForModel<TObjField>(f, Name));
  DescribedModel[] ITypeObjectModel.TypeParameters => TypeParameters;
}

public sealed record class ObjDescribedModel<TBase>(
  TBase Base
) : ModelBase
  where TBase : IObjBaseModel
{
  public string? Description { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => string.IsNullOrEmpty(Description)
      ? Base.Render(context)
      : base.Render(context)
        .Add("base", Base.Render(context))
        .Add("description", RenderValue.Str(Description));
}

internal interface ITypeObjectModel
  : IChildTypeModel
{
  DescribedModel[] TypeParameters { get; }
  IEnumerable<ModelBase> AllAlternates { get; }
  IEnumerable<ModelBase> AllFields { get; }

  ITypeObjectModel Apply(Map<IObjBaseModel> arguments);
}

public record class ObjBaseModel<TArg>
  : ModelBase, IObjBaseModel
  where TArg : IObjBaseModel
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
  ObjDescribedModel<TObjBase> Type
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
  internal ObjDescribedModel<TObjBase>? ParentModel(TObjBaseAst? parent, IMap<TypeKindModel> typeKinds)
    => parent is null ? null : new ObjDescribedModel<TObjBase>(BaseModel(parent, typeKinds));

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
