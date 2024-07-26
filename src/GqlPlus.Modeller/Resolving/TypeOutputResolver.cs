
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
        && GetOutputArgument(output.Name, output.Parent.Base, arguments, out OutputBaseModel? parentModel)) {
        output.Parent = new(parentModel, output.Parent.Description);
        output.ParentModel = null;
      }

      ApplyArray(output.Fields, ApplyField(output.Name, arguments),
        fields => output.Fields = fields);
      ApplyArray(output.Alternates, ApplyAlternate(output.Name, arguments),
        alternates => output.Alternates = alternates);
    }

    return result;
  }

  private Func<OutputFieldModel, OutputFieldModel> ApplyField(string context, ArgumentsContext arguments)
    => field => {
      ObjDescribedModel<OutputBaseModel>? fieldType = field.Type;
      if (fieldType is not null
        && GetOutputArgument(context + " - " + field.Name, fieldType.Base, arguments, out OutputBaseModel? argModel)) {
        field = field with { Type = new(argModel, fieldType.Description) };
      }

      ApplyArray(field.Modifiers, ApplyModifier(context, arguments),
        modifiers => field = field with { Modifiers = modifiers });

      return field;
    };

  private Func<OutputAlternateModel, OutputAlternateModel> ApplyAlternate(string context, ArgumentsContext arguments)
    => alternate => {
      ObjDescribedModel<OutputBaseModel>? alternateType = alternate.Type;
      if (alternateType is not null
        && GetOutputArgument(context, alternateType.Base, arguments, out OutputBaseModel? argModel)) {
        alternate = alternate with { Type = new(argModel, alternateType.Description) };
      }

      ApplyArray(alternate.Collections, ApplyCollection(context, arguments),
        collections => alternate = alternate with { Collections = collections });

      return alternate;
    };

  private bool GetOutputArgument(string context, OutputBaseModel outputBase, ArgumentsContext arguments, [NotNullWhen(true)] out OutputBaseModel? outBase)
  {
    outBase = null;
    if (outputBase?.IsTypeParam == true) {
      if (arguments.TryGetArg(context, outputBase.Output, out OutputArgModel? outputArg)) {
        if (!arguments.TryGetType(context, outputArg.Output, out outBase, false)) {
          outBase = new(outputArg.Output!) { IsTypeParam = outputArg.IsTypeParam };
        }

        return true;
      }
    }

    return false;
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
    => model.Parent?.Base.Output;

  protected override void ResolveParent(TypeOutputModel model, IResolveContext context)
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
}
