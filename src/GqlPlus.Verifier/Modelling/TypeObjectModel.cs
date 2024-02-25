using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeObjectModel<TBase, TField>(TypeKindModel Kind, string Name)
  : ChildTypeModel<DescribedModel<TBase>>(Kind, Name)
  where TBase : ModelBase, ITypeBaseModel
{
  internal DescribedModel<NamedModel>[] TypeParameters { get; set; } = [];
  internal TField[] Fields { get; set; } = [];
  internal AlternateModel<TBase>[] Alternates { get; set; } = [];
}

internal record class AlternateModel<TBase>(RefModel<TBase> Type)
  where TBase : ITypeBaseModel
{
  internal ModifierModel[] Collections { get; set; } = [];
}

internal record class TypeBaseModel<TArg>
  : ModelBase, ITypeBaseModel
{
  internal TArg[] Arguments { get; set; } = [];
  internal string? TypeParameter { get; set; }
}

internal interface ITypeBaseModel
{
}

internal record class RefModel<TBase>
  where TBase : ITypeBaseModel
{
  internal TypeRefModel<SimpleKindModel>? TypeRef { get; private init; }

  internal TBase? BaseRef { get; private init; }
}

internal record class FieldModel<TBase>(string Name, RefModel<TBase> Type)
  : AliasedModel(Name)
  where TBase : ITypeBaseModel
{
  internal ModifierModel[] Modifiers { get; set; } = [];
}

internal abstract class ModellerObjectType<TAst, TReference, TModel, TBase>
  : ModellerType<TAst, TReference, TModel>
  where TAst : AstType<TReference>
  where TReference : IEquatable<TReference>
  where TModel : IRendering
  where TBase : ModelBase
{
  internal DescribedModel<TBase>? ParentModel(TReference? parent)
    => parent is null ? null : new DescribedModel<TBase>(BaseModel(parent));

  protected abstract TBase BaseModel(TReference reference);
}
