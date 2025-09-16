namespace GqlPlus.Models;

public abstract record class TypeObjectModel<TObjField>(
  TypeKindModel Kind,
  string Name,
  string Description
) : ChildTypeModel<ObjBaseModel>(Kind, Name, Description)
  , ITypeObjectModel
  where TObjField : IObjFieldModel
{
  public TypeParamModel[] TypeParams { get; set; } = [];
  public TObjField[] Fields { get; set; } = [];
  public ObjAlternateModel[] Alternates { get; set; } = [];

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
  public string? EnumLabel { get; set; }
}

public interface IObjTypeArgModel
  : INamedModel
{
  bool IsTypeParam { get; }
  string? EnumLabel { get; }
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

public record class ObjBaseModel(
  string Name,
  string Description
) : NamedModel(Name, Description)
  , IObjBaseModel
{
  public bool IsTypeParam { get; set; }
  public ObjTypeArgModel[] Args { get; set; } = [];
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

public record class ObjFieldModel(
  string Name,
  ObjBaseModel? Type,
  string Description
) : AliasedModel(Name, Description)
  , IObjFieldModel
{
  public ObjBaseModel? Type { get; internal set; } = Type;
  public ModifierModel[] Modifiers { get; set; } = [];
  public IObjBaseModel? BaseType => Type;
}

public interface IObjFieldModel
  : IAliasedModel
{
  IObjBaseModel? BaseType { get; }
  ModifierModel[] Modifiers { get; }
}

public record class ObjAlternateModel(
  ObjBaseModel Type
  ) : ModelBase
  , IObjAlternateModel
{
  public CollectionModel[] Collections { get; set; } = [];
  public IObjBaseModel BaseType => Type;
}

public interface IObjAlternateModel
  : IModelBase
{
  IObjBaseModel BaseType { get; }
  CollectionModel[] Collections { get; set; }
}
