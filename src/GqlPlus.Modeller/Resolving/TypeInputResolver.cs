using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

internal class TypeInputResolver(
  IResolver<TypeDualModel> dual
) : ResolverTypeObjectType<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel, InputArgModel>
{
  protected override TResult Apply<TResult>(TResult result, ArgumentsContext arguments)
  {
    if (result is TypeDualModel dual) {
      ApplyDualModel(arguments, dual);
    }

    if (result is TypeInputModel input) {
      if (input.Parent is not null
        && GetInputArgument(input.Name, input.Parent, arguments, out InputBaseModel? parentModel)) {
        input.Parent = new(parentModel.Input, input.Parent.Description);
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
  protected override string GetArgKey(InputArgModel argument)
    => argument.Input;
  protected override MakeFor<InputAlternateModel> ObjectAlt(string obj)
    => alt => new(alt, obj);
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
    => model.Parent?.Input;

  protected override void ResolveParent(TypeInputModel model, IResolveContext context)
  {
    DualBaseModel? parentDual = model.Parent?.Dual;
    if (parentDual is not null) {
      if (context.TryGetType(model.Name, parentDual.Dual, out TypeDualModel? parentModel)) {
        parentModel = dual.Resolve(parentModel, context);
        ArgumentsContext? argsContext = MakeArgumentsContext(context, parentDual.Args, parentModel);
        if (argsContext is not null) {
          parentModel = Apply(parentModel with { }, argsContext);
          parentModel = dual.Resolve(parentModel, context);
        }

        model.ParentModel = parentModel;
      }
    } else {
      base.ResolveParent(model, context);
    }
  }

  private Func<InputFieldModel, InputFieldModel> ApplyField(string label, ArgumentsContext arguments)
    => field => {
      InputBaseModel? fieldType = field.Type;
      if (fieldType is not null
        && GetInputArgument(label + " - " + field.Name, fieldType, arguments, out InputBaseModel? argModel)) {
        field = field with { Type = argModel with { Description = fieldType.Description } };
      }

      ApplyArray(field.Modifiers, ApplyModifier(label, arguments),
        modifiers => field = field with { Modifiers = modifiers });

      return field;
    };

  private Func<InputAlternateModel, InputAlternateModel> ApplyAlternate(string label, ArgumentsContext arguments)
    => alternate => {
      if (GetInputArgument(label, alternate, arguments, out InputBaseModel? argModel)) {
        if (argModel.Dual is null) {
          alternate = new(argModel.Input, argModel.Description) {
            Collections = alternate.Collections
          };
        } else {
          alternate = new("", argModel.Description) {
            Dual = new(argModel.Dual.Dual, argModel.Description) {
              Collections = alternate.Collections
            }
          };
        }
      }

      ApplyArray(alternate.Collections, ApplyCollection(label, arguments),
        collections => alternate = alternate with { Collections = collections });

      return alternate;
    };

  private bool GetInputArgument(string label, IInputModel inputBase, ArgumentsContext arguments, [NotNullWhen(true)] out InputBaseModel? outBase)
  {
    outBase = null;
    if (inputBase?.IsTypeParam == true) {
      if (arguments.TryGetArg(label, inputBase.Input, out InputArgModel? inputArg)) {
        if (inputArg.Dual is not null) {
          if (arguments.TryGetType(label, inputArg.Dual.Dual, out DualBaseModel? dualBase, false)) {
            outBase = new("", inputArg.Description) { Dual = dualBase };
          } else {
            outBase = new("", inputArg.Description) { Dual = new(inputArg.Dual.Dual, inputArg.Description) { IsTypeParam = inputArg.Dual.IsTypeParam } };
          }
        } else if (!arguments.TryGetType(label, inputArg.Input, out outBase, false)) {
          outBase = new(inputArg.Input, inputArg.Description) { IsTypeParam = inputArg.IsTypeParam };
        }

        return true;
      }
    }

    return false;
  }
}
