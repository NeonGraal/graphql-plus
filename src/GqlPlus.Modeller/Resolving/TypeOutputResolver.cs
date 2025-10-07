using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

internal class TypeOutputResolver
  : ResolverTypeObjectType<TypeOutputModel, OutputFieldModel>
{
  protected override TResult Apply<TResult>(TResult result, ArgumentsContext arguments)
  {
    if (result is TypeDualModel dual) {
      ApplyDualModel(arguments, dual);
    }

    if (result is TypeOutputModel output) {
      if (output.Parent is not null
        && GetOutputArgument(output.Name, output.Parent, arguments, out ObjBaseModel? parentModel)) {
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

  protected override void ResolveParent(TypeOutputModel model, IResolveContext context) =>
    // Dual property has been removed - use base implementation
    base.ResolveParent(model, context);

  private Func<OutputFieldModel, OutputFieldModel> ApplyField(string label, ArgumentsContext arguments)
    => field => {
      ObjBaseModel? fieldType = field.Type;
      if (fieldType is not null
        && GetOutputArgument(label + " - " + field.Name, fieldType, arguments, out ObjBaseModel? argModel)) {
        field = field with { Type = argModel with { Description = fieldType.Description } };
      }

      ApplyArray(field.Modifiers, ApplyModifier(label, arguments),
        modifiers => field = field with { Modifiers = modifiers });

      return field;
    };

  private Func<ObjAlternateModel, ObjAlternateModel> ApplyAlternate(string label, ArgumentsContext arguments)
    => alternate => {
      if (alternate.Type is ObjBaseModel outputType && GetOutputArgument(label, outputType, arguments, out ObjBaseModel? argModel)) {
        alternate = new ObjAlternateModel(argModel) { Collections = alternate.Collections };
      }

      ApplyArray(alternate.Collections, ApplyCollection(label, arguments),
        collections => alternate = new ObjAlternateModel(alternate.Type) { Collections = collections });

      return alternate;
    };

  private bool GetOutputArgument(string label, ObjBaseModel outputBase, ArgumentsContext arguments, [NotNullWhen(true)] out ObjBaseModel? outBase)
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
