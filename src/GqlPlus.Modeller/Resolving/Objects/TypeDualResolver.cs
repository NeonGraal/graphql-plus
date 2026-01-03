namespace GqlPlus.Resolving.Objects;

internal class TypeDualResolver
    : ResolverTypeObjectType<TypeDualModel, DualFieldModel>
{
  protected override TResult Apply<TResult>(TResult result, ArgumentsContext arguments)
  {
    if (result is TypeDualModel dual) {
      ApplyDualModel(arguments, dual);
    }

    return result;
  }

  protected override TypeDualModel CloneModel(TypeDualModel model)
    => model with { };
  protected override MakeFor<DualFieldModel> ObjectField(string obj)
    => fld => new(fld, obj);
  protected override IEnumerable<ObjectForModel> ParentAlternatives(IModelBase? parent)
    => parent is TypeDualModel dual ? dual.AllAlternates : [];
  protected override IEnumerable<ObjectForModel> ParentFields(IModelBase? parent)
    => parent is TypeDualModel dual ? dual.AllFields : [];
  protected override string? ParentName(TypeDualModel model)
    => model.Parent?.Name;
}
