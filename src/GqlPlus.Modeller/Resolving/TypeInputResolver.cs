namespace GqlPlus.Resolving;

internal class TypeInputResolver(
  IResolver<TypeDualModel> dual
) : ResolverTypeObjectType<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>
{
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
    if (model.Parent?.Base?.Dual is not null) {
      if (context.TryGetType(model.Name, model.Parent.Base.Dual.Dual, out TypeDualModel? parentModel)) {
        model.ParentModel = dual.Resolve(parentModel, context);
      }
    } else {
      base.ResolveParent(model, context);
    }
  }
}
