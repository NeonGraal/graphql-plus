﻿namespace GqlPlus.Models;

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
  public TypeParamModel[] TypeParams { get; set; } = [];
  public TObjField[] Fields { get; set; } = [];
  public TObjAlt[] Alternates { get; set; } = [];

  public ObjectForModel[] AllFields { get; set; } = [];
  public ObjectForModel[] AllAlternates { get; set; } = [];
}

public interface ITypeObjectModel
{
  TypeParamModel[] TypeParams { get; }
  ObjectForModel[] AllFields { get; }
  ObjectForModel[] AllAlternates { get; }
}

public record class ObjTypeArgModel(
  TypeKindModel Kind,
  string Name,
  string Description
) : TypeRefModel<TypeKindModel>(Kind, Name, Description)
  , IObjTypeArgModel
{
  public bool IsTypeParam { get; set; }
}

public interface IObjTypeArgModel
  : INamedModel
{
  bool IsTypeParam { get; }
}

public record class TypeParamModel(
  string Name,
  string Description,
  TypeRefModel<TypeKindModel> Constraint
) : NamedModel(Name, Description)
  , ITypeParamModel
{ }

public interface ITypeParamModel
  : INamedModel
{
  TypeRefModel<TypeKindModel> Constraint { get; }
}

public record class ObjBaseModel<TObjArg>(
  string Name,
  string Description
) : NamedModel(Name, Description)
  , IObjBaseModel
where TObjArg : IObjTypeArgModel
{
  public bool IsTypeParam { get; set; }
  public TObjArg[] Args { get; set; } = [];
  IObjTypeArgModel[] IObjBaseModel.Args => [.. Args.Cast<IObjTypeArgModel>()];
}

public interface IObjBaseModel
  : INamedModel
{
  bool IsTypeParam { get; set; }
  IObjTypeArgModel[] Args { get; }
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
