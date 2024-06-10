using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Models;

public abstract record class TypeObjectModel<TObjBase, TObjField>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<ObjDescribedModel<TObjBase>>(Kind, Name)
  , ITypeObjectModel
  where TObjBase : IObjBaseModel
  where TObjField : ModelBase
{
  internal DescribedModel[] TypeParameters { get; set; } = [];
  internal TObjField[] Fields { get; set; } = [];
  internal AlternateModel<TObjBase>[] Alternates { get; set; } = [];

  internal override bool GetParentModel<TResult>(IRenderContext context, [NotNullWhen(true)] out TResult? model)
    where TResult : default
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
}

public record class ObjectForModel<TFor>(
  TFor For,
  string Obj
) : ModelBase
  where TFor : IRendering
{ }

public record class ObjFieldModel<TObjBase>(
  string Name,
  ObjDescribedModel<TObjBase>? Type
) : AliasedModel(Name)
  where TObjBase : IObjBaseModel
{
  internal ModifierModel[] Modifiers { get; set; } = [];
}

public record class ObjDescribedModel<TDescribed>(
  TDescribed Base,
  string? Description
) : ModelBase
  where TDescribed : IRendering
{ }
