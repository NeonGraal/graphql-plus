using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

internal class TypeOutputResolver(
  IResolver<TypeDualModel> dual
) : ResolverTypeObjectType<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>
{
  protected override TResult Apply<TResult>(TResult result, ArgumentsContext arguments)
  {
    if (result is TypeDualModel dual) {
      ApplyDualModel(arguments, dual);
    }

    if (result is TypeOutputModel output) {
      if (output.Parent is not null
        && GetOutputArgument(output.Name, output.Parent, arguments, out OutputBaseModel? parentModel)) {
        output.Parent = new(parentModel.Name, output.Parent.Description);
        output.ParentModel = null;
      }

      ApplyArray(output.Fields, ApplyField(output.Name, arguments),
        fields => output.Fields = fields);
      ApplyArray(output.Alternates, ApplyAlternate(output.Name, arguments),
        alternates => output.Alternates = alternates);
    }

    return result;
  }

  protected override TypeOutputModel CloneModel(TypeOutputModel model)
    => model with { };
  protected override MakeFor<OutputAlternateModel> ObjectAlt(string obj)
    => alt => new(alt, obj);
  protected override MakeFor<OutputFieldModel> ObjectField(string obj)
    => fld => new(fld, obj);

  protected override IEnumerable<ObjectForModel> ParentAlternatives(IModelBase? parent)
    => parent switch {
      TypeDualModel dual => dual.AllAlternates,
      TypeOutputModel output => output.AllAlternates,
      _ => []
    };

  protected override IEnumerable<ObjectForModel> ParentFields(IModelBase? parent)
    => parent switch {
      TypeDualModel dual => dual.AllFields,
      TypeOutputModel output => output.AllFields,
      _ => []
    };

  protected override string? ParentName(TypeOutputModel model)
    => model.Parent?.Name;

  protected override void ResolveParent(TypeOutputModel model, IResolveContext context)
  {
    DualBaseModel? parentDual = model.Parent?.Dual;
    if (parentDual is not null) {
      if (context.TryGetType(model.Name, parentDual.Name, out TypeDualModel? parentModel)) {
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

  private Func<OutputFieldModel, OutputFieldModel> ApplyField(string label, ArgumentsContext arguments)
    => field => {
      OutputBaseModel? fieldType = field.Type;
      if (fieldType is not null
        && GetOutputArgument(label + " - " + field.Name, fieldType, arguments, out OutputBaseModel? argModel)) {
        field = field with { Type = argModel with { Description = fieldType.Description } };
      }

      ApplyArray(field.Modifiers, ApplyModifier(label, arguments),
        modifiers => field = field with { Modifiers = modifiers });

      return field;
    };

  private Func<OutputAlternateModel, OutputAlternateModel> ApplyAlternate(string label, ArgumentsContext arguments)
    => alternate => {
      if (GetOutputArgument(label, alternate.Type, arguments, out OutputBaseModel? argModel)) {
        alternate = alternate with { Type = argModel };
      }

      ApplyArray(alternate.Collections, ApplyCollection(label, arguments),
        collections => alternate = alternate with { Collections = collections });

      return alternate;
    };

  private bool GetOutputArgument(string label, OutputBaseModel outputBase, ArgumentsContext arguments, [NotNullWhen(true)] out OutputBaseModel? outBase)
  {
    outBase = null;
    if (outputBase?.IsTypeParam == true) {
      if (arguments.TryGetArg(label, outputBase.Name, out ObjTypeArgModel? outputArg)) {
        if (!arguments.TryGetType(label, outputArg.Name, out outBase, false)) {
          outBase = new(outputArg.Name!, outputArg.Description) { IsTypeParam = outputArg.IsTypeParam };
        }

        return true;
      }
    }

    return false;
  }
}
