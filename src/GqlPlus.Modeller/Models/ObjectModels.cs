using System.Diagnostics.CodeAnalysis;
using GqlPlus.Resolving;

namespace GqlPlus.Models;

public abstract record class TypeObjectModel<TObjBase, TObjField, TObjAlt>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<ObjDescribedModel<TObjBase>>(Kind, Name)
  , ITypeObjectModel
  where TObjBase : IObjBaseModel
  where TObjField : IObjFieldModel
  where TObjAlt : IObjAlternateModel
{
  internal DescribedModel[] TypeParameters { get; set; } = [];
  internal TObjField[] Fields { get; set; } = [];
  internal TObjAlt[] Alternates { get; set; } = [];

  internal override bool GetParentModel<TResult>(IResolveContext context, [NotNullWhen(true)] out TResult? model)
    where TResult : default
  {
    if (Parent?.Base.IsTypeParameter == false) {
      return base.GetParentModel(context, out model);
    }

    model = default;
    return false;
  }

  IEnumerable<ModelBase> ITypeObjectModel.AllAlternates
    => Alternates.Select(a => new ObjectForModel<TObjAlt>(a, Name));
  IEnumerable<ModelBase> ITypeObjectModel.AllFields
    => Fields.Select(f => new ObjectForModel<TObjField>(f, Name));
}

public interface ITypeObjectModel
  : IChildTypeModel
{
  IEnumerable<ModelBase> AllAlternates { get; }
  IEnumerable<ModelBase> AllFields { get; }
}

public record class ObjArgumentModel
  : ModelBase, IObjArgumentModel
{
  public bool IsTypeParameter { get; set; }
}

public interface IObjArgumentModel
  : IModelBase
{
  bool IsTypeParameter { get; }
}

public record class ObjBaseModel<TArg>
  : ModelBase, IObjBaseModel
  where TArg : IObjArgumentModel
{
  internal TArg[] Arguments { get; set; } = [];
  public bool IsTypeParameter { get; set; }
}

public interface IObjBaseModel
  : IModelBase
{
  bool IsTypeParameter { get; }
}

public record class ObjectForModel<TFor>(
  TFor For,
  string Obj
) : ModelBase
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
}
