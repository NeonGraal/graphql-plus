using System.Diagnostics.CodeAnalysis;

using GqlPlus.Resolving;

namespace GqlPlus.Models;

public abstract record class TypeObjectModel<TObjBase, TObjField, TObjAlt>(
  TypeKindModel Kind,
  string Name,
  string Description
) : ChildTypeModel<TObjBase>(Kind, Name, Description)
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
    if (Parent?.IsTypeParam == false) {
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

public record class ObjArgModel(
  string Description
) : DescribedModel(Description)
  , IObjArgModel
{
  public bool IsTypeParam { get; set; }
}

public interface IObjArgModel
  : IDescribedModel
{
  bool IsTypeParam { get; }
}

public record class ObjBaseModel<TObjArg>(
  string Description
) : DescribedModel(Description)
  , IObjBaseModel
  where TObjArg : IObjArgModel
{
  internal TObjArg[] Args { get; set; } = [];
  public bool IsTypeParam { get; set; }
  IObjArgModel[] IObjBaseModel.Args => [.. Args.Cast<IObjArgModel>()];
}

public interface IObjBaseModel
  : IDescribedModel
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
  TObjBase? Type,
  string Description
) : AliasedModel(Name, Description)
  , IObjFieldModel
  where TObjBase : IObjBaseModel
{
  public TObjBase? Type { get; internal set; } = Type;
  public ModifierModel[] Modifiers { get; set; } = [];
  public IObjBaseModel? BaseType => Type;
}

public interface IObjFieldModel
  : IAliasedModel
{
  IObjBaseModel? BaseType { get; }
  ModifierModel[] Modifiers { get; }
}

public record class ObjAlternateModel<TObjBase>(
  TObjBase Type
  ) : ModelBase
  , IObjAlternateModel
  where TObjBase : IObjBaseModel
{
  public CollectionModel[] Collections { get; set; } = [];
  public IObjBaseModel BaseType => Type;
}

public interface IObjAlternateModel
  : IModelBase
{
  IObjBaseModel BaseType { get; }
  CollectionModel[] Collections { get; }
}
