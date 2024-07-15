using System.Diagnostics.CodeAnalysis;

using GqlPlus.Resolving;

namespace GqlPlus.Models;

public abstract record class TypeObjectModel<TObjBase, TObjField, TObjAlt>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<ObjDescribedModel<TObjBase>>(Kind, Name)
  where TObjBase : IObjBaseModel
  where TObjField : IObjFieldModel
  where TObjAlt : IObjAlternateModel
{
  internal DescribedModel[] TypeParams { get; set; } = [];
  internal TObjField[] Fields { get; set; } = [];
  internal TObjAlt[] Alternates { get; set; } = [];

  internal ObjectForModel[] AllFields { get; set; } = [];
  internal ObjectForModel[] AllAlternates { get; set; } = [];

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

public record class ObjArgModel
  : ModelBase, IObjArgModel
{
  public bool IsTypeParam { get; set; }
}

public interface IObjArgModel
  : IModelBase
{
  bool IsTypeParam { get; }
}

public record class ObjBaseModel<TArg>
  : ModelBase, IObjBaseModel
  where TArg : IObjArgModel
{
  internal TArg[] Args { get; set; } = [];
  public bool IsTypeParam { get; set; }
}

public interface IObjBaseModel
  : IModelBase
{
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
  ObjDescribedModel<TObjBase>? Type
) : AliasedModel(Name)
  , IObjFieldModel
  where TObjBase : IObjBaseModel
{
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
