﻿using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

internal class TypeInputResolver(
  IResolver<TypeDualModel> dual
) : ResolverTypeObjectType<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>
{
  protected override TResult Apply<TResult>(TResult result, ArgumentsContext arguments)
  {
    if (result is TypeDualModel dual) {
      ApplyDualModel(arguments, dual);
    }

    if (result is TypeInputModel input) {
      if (input.Parent is not null
        && GetInputArgument(input.Name, input.Parent.Base, arguments, out InputBaseModel? parentModel)) {
        input.Parent = new(parentModel, input.Parent.Description);
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
    => model.Parent?.Base.Input;

  protected override void ResolveParent(TypeInputModel model, IResolveContext context)
  {
    DualBaseModel? parentDual = model.Parent?.Base?.Dual;
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
      ObjDescribedModel<InputBaseModel>? fieldType = field.Type;
      if (fieldType is not null
        && GetInputArgument(label + " - " + field.Name, fieldType.Base, arguments, out InputBaseModel? argModel)) {
        field = field with { Type = new(argModel, fieldType.Description) };
      }

      ApplyArray(field.Modifiers, ApplyModifier(label, arguments),
        modifiers => field = field with { Modifiers = modifiers });

      return field;
    };

  private Func<InputAlternateModel, InputAlternateModel> ApplyAlternate(string label, ArgumentsContext arguments)
    => alternate => {
      ObjDescribedModel<InputBaseModel>? alternateType = alternate.Type;
      if (alternateType is not null
        && GetInputArgument(label, alternateType.Base, arguments, out InputBaseModel? argModel)) {
        alternate = alternate with { Type = new(argModel, alternateType.Description) };
      }

      ApplyArray(alternate.Collections, ApplyCollection(label, arguments),
        collections => alternate = alternate with { Collections = collections });

      return alternate;
    };

  private bool GetInputArgument(string label, InputBaseModel inputBase, ArgumentsContext arguments, [NotNullWhen(true)] out InputBaseModel? outBase)
  {
    outBase = null;
    if (inputBase?.IsTypeParam == true) {
      if (arguments.TryGetArg(label, inputBase.Input, out InputArgModel? inputArg)) {
        if (inputArg.Dual is not null) {
          if (arguments.TryGetType(label, inputArg.Dual.Dual, out DualBaseModel? dualBase, false)) {
            outBase = new("") { Dual = dualBase };
          } else {
            outBase = new("") { Dual = new(inputArg.Dual.Dual) { IsTypeParam = inputArg.Dual.IsTypeParam } };
          }
        } else if (!arguments.TryGetType(label, inputArg.Input, out outBase, false)) {
          outBase = new(inputArg.Input) { IsTypeParam = inputArg.IsTypeParam };
        }

        return true;
      }
    }

    return false;
  }
}
