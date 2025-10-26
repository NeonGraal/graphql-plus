using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

internal class TypeInputResolver
  : ResolverTypeObjectType<TypeInputModel, InputFieldModel>
{
  protected override TResult Apply<TResult>(TResult result, ArgumentsContext arguments)
  {
    if (result is TypeDualModel dual) {
      ApplyDualModel(arguments, dual);
    }

    if (result is TypeInputModel input) {
      if (input.Parent is not null
        && GetInputArgument(input.Name, input.Parent, arguments, out ObjBaseModel? parentModel)) {
        input.Parent = new(parentModel.Name, input.Parent.Description);
        input.ParentModel = null;
      }

      ApplyArray(input.Fields, ApplyField(input.Name, arguments),
        fields => input.Fields = fields);
      ApplyArray(input.Alternates, ApplyAlternate(input.Name, arguments),
        alternates => input.Alternates = alternates);
    }

    return result;
  }

  protected override TypeInputModel CloneModel(TypeInputModel model)
    => model with { };
  protected override MakeFor<InputFieldModel> ObjectField(string obj)
    => fld => new(fld, obj);

  protected override IEnumerable<ObjectForModel> ParentAlternatives(IModelBase? parent)
    => parent switch {
      TypeDualModel dual => dual.AllAlternates,
      TypeInputModel input => input.AllAlternates,
      _ => []
    };

  protected override IEnumerable<ObjectForModel> ParentFields(IModelBase? parent)
    => parent switch {
      TypeDualModel dual => dual.AllFields,
      TypeInputModel input => input.AllFields,
      _ => []
    };

  protected override string? ParentName(TypeInputModel model)
    => model.Parent?.Name;

  protected override void ResolveParent(TypeInputModel model, IResolveContext context) =>
    // Dual property has been removed - use base implementation
    base.ResolveParent(model, context);

  private Func<InputFieldModel, InputFieldModel> ApplyField(string label, ArgumentsContext arguments)
    => field => {
      ObjBaseModel? fieldType = field.Type;
      if (fieldType is not null
        && GetInputArgument(label + " - " + field.Name, fieldType, arguments, out ObjBaseModel? argModel)) {
        field = field with { Type = argModel with { Description = fieldType.Description } };
      }

      ApplyArray(field.Modifiers, ApplyModifier(label, arguments),
        modifiers => field = field with { Modifiers = modifiers });

      return field;
    };

  private Func<AlternateModel, AlternateModel> ApplyAlternate(string label, ArgumentsContext arguments)
    => alternate => {
      if (alternate.Type is ObjBaseModel inputType && GetInputArgument(label, inputType, arguments, out ObjBaseModel? argModel)) {
        alternate = new AlternateModel(argModel) { Collections = alternate.Collections };
      }

      ApplyArray(alternate.Collections, ApplyCollection(label, arguments),
        collections => alternate = new AlternateModel(alternate.Type) { Collections = collections });

      return alternate;
    };

  private bool GetInputArgument(string label, ObjBaseModel inputBase, ArgumentsContext arguments, [NotNullWhen(true)] out ObjBaseModel? outBase)
  {
    outBase = null;
    if (inputBase?.IsTypeParam == true) {
      if (arguments.TryGetArg(label, inputBase.Name, out TypeArgModel? inputArg)) {
        if (!arguments.TryGetType(label, inputArg.Name, out outBase, false)) {
          outBase = new(inputArg.Name, inputArg.Description) { IsTypeParam = inputArg.IsTypeParam };
        }

        return true;
      }
    }

    return false;
  }
}
