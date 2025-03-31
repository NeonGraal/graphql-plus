using System.Diagnostics.CodeAnalysis;

using GqlPlus.Resolving;

namespace GqlPlus.Models;

public abstract record class TypeObjectModel<TObjBase, TObjField, TObjAlt>(
  TypeKindModel Kind,
  string Name,
  string Description
) : ChildTypeModel<ObjDescribedModel<TObjBase>>(Kind, Name, Description)
  , ITypeObjectModel
  where TObjBase : IObjBaseModel
  where TObjField : IObjFieldModel
  where TObjAlt : IObjAlternateModel
{
  public NamedModel[] TypeParams { get; set; } = [];
  internal TObjField[] Fields { get; set; } = [];
  internal TObjAlt[] Alternates { get; set; } = [];

  public ObjectForModel[] AllFields { get; set; } = [];
  public ObjectForModel[] AllAlternates { get; set; } = [];

  internal override bool GetParentModel<TResult>(IResolveContext context, [NotNullWhen(true)] out TResult? model)
    where TResult : default
  {
    if (Parent?.Base.IsTypeParam == false) {
      return base.GetParentModel(context, out model);
    }

    model = default;
    return false;
  }
}

public interface ITypeObjectModel
{
  NamedModel[] TypeParams { get; }
  ObjectForModel[] AllFields { get; }
  ObjectForModel[] AllAlternates { get; }
}

public record class ObjArgModel
  : ModelBase
  , IObjArgModel
{
  public bool IsTypeParam { get; set; }
}

public interface IObjArgModel
  : IModelBase
{
  bool IsTypeParam { get; }
}

public record class ObjBaseModel<TArg>
  : ModelBase
  , IObjBaseModel
  where TArg : IObjArgModel
{
  internal TArg[] Args { get; set; } = [];
  public bool IsTypeParam { get; set; }
  IObjArgModel[] IObjBaseModel.Args => [.. Args.Cast<IObjArgModel>()];
}

public interface IObjBaseModel
  : IModelBase
{
  IObjArgModel[] Args { get; }

  bool IsTypeParam { get; }
}

public record class ObjectForModel(
  string Obj
) : ModelBase
{ }

public record class ObjectForModel<TFor>(
  TFor For,
  string Obj
) : ObjectForModel(Obj)
  where TFor : IModelBase
{ }

public record class ObjFieldModel<TObjBase>(
  string Name,
  ObjDescribedModel<TObjBase>? Type,
  string Description
) : AliasedModel(Name, Description)
  , IObjFieldModel
  where TObjBase : IObjBaseModel
{
  public ObjDescribedModel<TObjBase>? Type { get; internal set; } = Type;
  public ModifierModel[] Modifiers { get; set; } = [];
  public ObjDescribedModel<IObjBaseModel>? BaseType
    => Type?.BaseAs<IObjBaseModel>();
}

public interface IObjFieldModel
  : IAliasedModel
{
  ObjDescribedModel<IObjBaseModel>? BaseType { get; }
  ModifierModel[] Modifiers { get; }
}

public record class ObjAlternateModel<TObjBase>(
  ObjDescribedModel<TObjBase> Type
) : ModelBase, IObjAlternateModel
  where TObjBase : IObjBaseModel
{
  public CollectionModel[] Collections { get; set; } = [];
  public ObjDescribedModel<IObjBaseModel>? BaseType
    => Type?.BaseAs<IObjBaseModel>();
}

public interface IObjAlternateModel
  : IModelBase
{
  ObjDescribedModel<IObjBaseModel>? BaseType { get; }
  CollectionModel[] Collections { get; }
}

public record class ObjDescribedModel<TDescribed>(
  TDescribed Base,
  string? Description
) : ModelBase
  where TDescribed : IModelBase
{
  public ObjDescribedModel<TBase>? BaseAs<TBase>()
    where TBase : IModelBase
    => Base is TBase newBase
    ? new(newBase, Description) :
    null;

  public ObjDescribedModel<TBase> BaseFor<TBase>(Func<TDescribed, TBase> convert)
    where TBase : IModelBase
    => new(convert.ThrowIfNull().Invoke(Base), Description);
}
