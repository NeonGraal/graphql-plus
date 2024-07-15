
namespace GqlPlus.Resolving;

internal class TypeOutputResolver(
  IResolver<TypeDualModel> dual
) : ResolverTypeObjectType<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>
{
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
    if (model.Parent?.Base?.Dual is not null) {
      if (context.TryGetType(model.Name, model.Parent.Base.Dual.Dual, out TypeDualModel? parentModel)) {
        model.ParentModel = dual.Resolve(parentModel, context);
      }
    } else {
      base.ResolveParent(model, context);
    }
  }
}
