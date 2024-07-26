using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

internal abstract class ResolverTypeObjectType<TModel, TObjBase, TObjField, TObjAlt>
  : ResolverChildType<TModel, ObjDescribedModel<TObjBase>>
  , ITypeResolver
  where TModel : TypeObjectModel<TObjBase, TObjField, TObjAlt>
  where TObjBase : IObjBaseModel
  where TObjField : IObjFieldModel
  where TObjAlt : IObjAlternateModel
{
  public bool ForType(BaseTypeModel model)
    => model is TModel;

  public BaseTypeModel ResolveType(BaseTypeModel model, IResolveContext context)
    => Resolve((TModel)model, context);

  public override TModel Resolve(TModel model, IResolveContext context)
  {
    model = base.Resolve(model, context);

    IEnumerable<ObjectForModel> allAlternates = ApplyMakeFor(model.Alternates, ObjectAlt(model.Name));
    IEnumerable<ObjectForModel> allFields = ApplyMakeFor(model.Fields, ObjectField(model.Name));

    model.AllAlternates = [.. ParentAlternatives(model.ParentModel), .. allAlternates];
    model.AllFields = [.. ParentFields(model.ParentModel), .. allFields];

    return model;
  }

  protected override void ResolveParent(TModel model, IResolveContext context)
  {
    if (model.Parent is null) {
      return;
    }

    TObjBase parentBase = model.Parent.Base;

    if (parentBase.IsTypeParam) {
      string paramName = '$' + ParentName(model);
      if (context.TryGetType(model.Name, paramName, out TModel? parentModel, false)) {
        model.ParentModel = Resolve(parentModel, context);
      }
    } else {
      base.ResolveParent(model, context);

      if (model.ParentModel is TModel parentModel) {
        ArgumentsContext? argsContext = MakeArgumentsContext(context, parentBase.Args, parentModel);
        if (argsContext is not null) {
          parentModel = Apply(CloneModel(parentModel), argsContext);
          model.ParentModel = Resolve(parentModel, context);
        }
      }
    }
  }

  protected ArgumentsContext? MakeArgumentsContext(IResolveContext context, IObjArgModel[] arguments, ITypeObjectModel model)
  {
    if (arguments == null || arguments.Length == 0 || model.TypeParams.Length < arguments.Length) {
      return null;
    }

    ArgumentsContext result = new(context);
    for (int i = 0; i < arguments.Length; i++) {
      result.Add("$" + model.TypeParams[i].Name, arguments[i]);
    }

    return result;
  }

  protected abstract TResult Apply<TResult>(TResult result, ArgumentsContext arguments)
    where TResult : ITypeObjectModel;

  protected delegate ObjectForModel<TFor> MakeFor<TFor>(TFor obj)
    where TFor : IModelBase;

  protected IEnumerable<ObjectForModel> ApplyMakeFor<TFor>(IEnumerable<TFor> list, MakeFor<TFor> convert)
    where TFor : IModelBase
    => list.Select(f => convert(f));

  protected abstract TModel CloneModel(TModel model);
  protected abstract MakeFor<TObjAlt> ObjectAlt(string obj);
  protected abstract MakeFor<TObjField> ObjectField(string obj);
  protected abstract IEnumerable<ObjectForModel> ParentAlternatives(IModelBase? parent);
  protected abstract IEnumerable<ObjectForModel> ParentFields(IModelBase? parent);

  protected void ApplyArray<TItem>(TItem[] list, Func<TItem, TItem> update, Action<TItem[]> apply)
  {
    TItem[] items = [.. list.Select(update)];

    if (!items.SequenceEqual(list)) {
      apply(items);
    }
  }

  protected Func<CollectionModel, CollectionModel> ApplyCollection(string context, ArgumentsContext arguments)
    => collection => {
      if (collection.ModifierKind == ModifierKind.Param
        && arguments.TryGetArg(context, collection.Key!, out DualArgModel? keyModel)) {
        return new(ModifierKind.Dict) { Key = keyModel.Dual };
      }

      return collection;
    };

  protected Func<ModifierModel, ModifierModel> ApplyModifier(string context, ArgumentsContext arguments)
    => modifier => {
      if (modifier.ModifierKind == ModifierKind.Param
        && arguments.TryGetArg(context, modifier.Key!, out DualArgModel? keyModel)) {
        return new(ModifierKind.Dict) { Key = keyModel.Dual };
      }

      return modifier;
    };

  protected bool GetDualArgument(string context, DualBaseModel dualBase, ArgumentsContext arguments, [NotNullWhen(true)] out DualBaseModel? outBase)
  {
    outBase = null;
    if (dualBase?.IsTypeParam == true) {
      if (arguments.TryGetArg(context, dualBase.Dual, out DualArgModel? dualArg)) {
        if (!arguments.TryGetType(context, dualArg.Dual, out outBase, false)) {
          outBase = new(dualArg.Dual) { IsTypeParam = dualArg.IsTypeParam };
        }

        return true;
      }
    }

    return false;
  }

  protected Func<DualAlternateModel, DualAlternateModel> ApplyDualAlternate(string context, ArgumentsContext arguments)
    => alternate => {
      ObjDescribedModel<DualBaseModel>? alternateType = alternate.Type;
      if (alternateType is not null
        && GetDualArgument(context, alternateType.Base, arguments, out DualBaseModel? argModel)) {
        alternate = alternate with { Type = new(argModel, alternateType.Description) };
      }

      ApplyArray(alternate.Collections, ApplyCollection(context, arguments),
        collections => alternate = alternate with { Collections = collections });

      return alternate;
    };

  protected Func<DualFieldModel, DualFieldModel> ApplyDualField(string context, ArgumentsContext arguments)
    => field => {
      ObjDescribedModel<DualBaseModel>? fieldType = field.Type;
      if (fieldType is not null
        && GetDualArgument(context + " - " + field.Name, fieldType.Base, arguments, out DualBaseModel? argModel)) {
        field = field with { Type = new(argModel, fieldType.Description) };
      }

      ApplyArray(field.Modifiers, ApplyModifier(context, arguments),
        modifiers => field = field with { Modifiers = modifiers });

      return field;
    };

  protected void ApplyDualModel(ArgumentsContext arguments, TypeDualModel dual)
  {
    if (dual.Parent is not null
      && GetDualArgument(dual.Name, dual.Parent.Base, arguments, out DualBaseModel? parentModel)) {
      dual.Parent = new(parentModel, dual.Parent.Description);
      dual.ParentModel = null;
    }

    ApplyArray(dual.Fields, ApplyDualField(dual.Name, arguments),
      fields => dual.Fields = fields);
    ApplyArray(dual.Alternates, ApplyDualAlternate(dual.Name, arguments),
      alternates => dual.Alternates = alternates);
  }
}
