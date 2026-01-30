using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving.Objects;

internal abstract class ResolverTypeObjectType<TModel, TObjField>
  : ResolverChildType<TModel, ObjBaseModel>
  where TModel : TypeObjectModel<TObjField>
  where TObjField : IObjFieldModel
{
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

    ObjBaseModel parentBase = model.Parent;

    if (parentBase.IsTypeParam) {
      string paramName = '$' + parentBase.Name;
      if (context.TryGetType(model.Name, paramName, out TModel? parentModel, false)) {
        model.ParentModel = Resolve(parentModel, context);
      }
    } else {
      base.ResolveParent(model, context);

      if (model.ParentModel is TModel parentModel) {
        ArgumentsContext? argsContext = MakeArgumentsContext(context, parentBase.Args, parentModel);
        if (argsContext is not null) {
          parentModel = Apply(CloneModel(parentModel), argsContext);
          model.ParentModel = Resolve(parentModel, argsContext);
        }
      }
    }
  }

  protected ArgumentsContext? MakeArgumentsContext(IResolveContext context, ITypeArgModel[] arguments, ITypeObjectModel model)
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
  protected MakeFor<AlternateModel> ObjectAlt(string obj)
    => alt => new(alt, obj);
  protected abstract MakeFor<TObjField> ObjectField(string obj);
  protected abstract IEnumerable<ObjectForModel> ParentAlternatives(IModelBase? parent);
  protected abstract IEnumerable<ObjectForModel> ParentFields(IModelBase? parent);

  protected void ApplyArray<TItem>(
    TItem[] list,
    Func<TItem, TItem> update,
    Action<TItem[]> apply
  )
  {
    TItem[] items = [.. list.Select(update)];

    if (!items.SequenceEqual(list)) {
      apply(items);
    }
  }

  protected Func<CollectionModel, CollectionModel> ApplyCollection(string label, ArgumentsContext arguments)
    => collection => {
      if (collection.ModifierKind == ModifierKind.Param
        && arguments.TryGetArg(label, collection.Key!, out TypeArgModel? keyModel)) {
        return new(ModifierKind.Dict) { Key = keyModel.Name };
      }

      return collection;
    };

  protected Func<ModifierModel, ModifierModel> ApplyModifier(string label, ArgumentsContext arguments)
    => modifier => {
      if (modifier.ModifierKind == ModifierKind.Param
        && arguments.TryGetArg(label, modifier.Key!, out TypeArgModel? keyModel)) {
        return new(ModifierKind.Dict) { Key = keyModel.Name };
      }

      return modifier;
    };

  protected bool GetDualArgument(
    string label,
    IObjBaseModel dualBase,
    ArgumentsContext arguments,
    [NotNullWhen(true)] out ObjBaseModel? outBase
  )
  {
    outBase = null;
    if (dualBase?.IsTypeParam == true) {
      if (arguments.TryGetArg(label, dualBase.Name, out TypeArgModel? dualArg)) {
        if (!arguments.TryGetType(label, dualArg.Name, out outBase, false)) {
          outBase = new(dualArg.Name, dualArg.Description) { IsTypeParam = dualArg.IsTypeParam };
        }

        return true;
      }
    }

    return false;
  }

  protected Func<AlternateModel, AlternateModel> ApplyDualAlternate(string label, ArgumentsContext arguments)
    => alternate => {
      if (alternate.Type is ObjBaseModel dualType && GetDualArgument(label, dualType, arguments, out ObjBaseModel? argModel)) {
        alternate = new AlternateModel(argModel) { Collections = alternate.Collections };
      }

      ApplyArray(alternate.Collections, ApplyCollection(label, arguments),
        collections => alternate = new AlternateModel(alternate.Type) { Collections = collections });

      return alternate;
    };

  protected Func<DualFieldModel, DualFieldModel> ApplyDualField(string label, ArgumentsContext arguments)
    => field => {
      ObjBaseModel? fieldType = field.Type;
      if (fieldType is not null
        && GetDualArgument(label + " - " + field.Name, fieldType, arguments, out ObjBaseModel? argModel)) {
        field = field with { Type = new(argModel.Name, fieldType.Description) };
      }

      ApplyArray(field.Modifiers, ApplyModifier(label, arguments),
        modifiers => field = field with { Modifiers = modifiers });

      return field;
    };

  protected void ApplyDualModel(ArgumentsContext arguments, TypeDualModel dual)
  {
    if (dual.Parent is not null
      && GetDualArgument(dual.Name, dual.Parent, arguments, out ObjBaseModel? parentModel)) {
      dual.Parent = new(parentModel.Name, dual.Parent.Description);
      dual.ParentModel = null;
    }

    ApplyArray(dual.Fields, ApplyDualField(dual.Name, arguments),
      fields => dual.Fields = fields);
    ApplyArray(dual.Alternates, ApplyDualAlternate(dual.Name, arguments),
      alternates => dual.Alternates = alternates);
  }
}
