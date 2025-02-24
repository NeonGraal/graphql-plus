using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling.Globals;
using GqlPlus.Modelling.Objects;
using GqlPlus.Modelling.Simple;
using GqlPlus.Rendering;
using GqlPlus.Resolving;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Modelling;

public static class Startup
{

  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddTransient<ISchemaModelChecks, SchemaModelChecks>()

      .AddTransient<ICheckModelBase<ModifierInput, CollectionModel>, CollectionModelChecks>()
      .AddTransient<IConstantModelChecks, ConstantModelChecks>()
      .AddTransient<ICheckModelBase<ModifierInput, ModifierModel>, ModifierModelChecks>()
      .AddTransient<ISimpleModelChecks, SimpleModelChecks>()

      .AddTransient<ICategoriesModelChecks, CategoriesModelChecks>()
      .AddTransient<ICategoryModelChecks, CategoryModelChecks>()
      .AddTransient<IDirectivesModelChecks, DirectivesModelChecks>()
      .AddTransient<IDirectiveModelChecks, DirectiveModelChecks>()
      .AddTransient<ICheckDescribedModel<SettingInput, SettingModel>, SettingModelChecks>()

      .AddTransient<IDomainBooleanModelChecks, DomainBooleanModelChecks>()
      .AddDomainTypeInputs<IGqlpDomainTrueFalse, DomainTrueFalseModel>()
      .AddTransient<IDomainEnumModelChecks, DomainEnumModelChecks>()
      .AddDomainTypeInputs<IGqlpDomainMember, DomainMemberModel>()
      .AddTransient<IDomainNumberModelChecks, DomainNumberModelChecks>()
      .AddDomainTypeInputs<IGqlpDomainRange, DomainRangeModel>()
      .AddTransient<IDomainStringModelChecks, DomainStringModelChecks>()
      .AddDomainTypeInputs<IGqlpDomainRegex, DomainRegexModel>()

      .AddTransient<IEnumModelChecks, EnumModelChecks>()
      .AddTypeInputs<IGqlpEnum, TypeEnumModel>()
      .AddTransient<IUnionModelChecks, UnionModelChecks>()
      .AddTypeInputs<IGqlpUnion, TypeUnionModel>()

      .AddTransient<IDualBaseModelChecks, DualBaseModelChecks>()
      .AddTransient<IDualFieldModelChecks, DualFieldModelChecks>()
      .AddTransient<IDualModelChecks, DualModelChecks>()
      .AddTypeInputs<IGqlpDualObject, TypeDualModel>()

      .AddTransient<IInputBaseModelChecks, InputBaseModelChecks>()
      .AddTransient<IInputFieldModelChecks, InputFieldModelChecks>()
      .AddTransient<IInputModelChecks, InputModelChecks>()
      .AddTypeInputs<IGqlpInputObject, TypeInputModel>()
      .AddTransient<ICheckDescribedModel<string, InputParamModel>, InputParamModelChecks>()

      .AddTransient<IOutputBaseModelChecks, OutputBaseModelChecks>()
      .AddTransient<IOutputFieldModelChecks, OutputFieldModelChecks>()
      .AddTransient<IOutputModelChecks, OutputModelChecks>()
      .AddTypeInputs<IGqlpOutputObject, TypeOutputModel>()

      .AddComponentTest()
      .AddModellers()
      .AddResolvers()
      .AddRenderers()
    ;

  public static IServiceCollection AddTypeInputs<TAst, TModel>(this IServiceCollection services)
    where TAst : IGqlpError
    where TModel : IModelBase
    => services.AddSingleton<CheckTypeInputs<TAst, TModel>>();

  public static IServiceCollection AddDomainTypeInputs<TItem, TItemModel>(this IServiceCollection services)
  where TItem : IGqlpDomainItem
  where TItemModel : BaseDomainItemModel
    => services.AddSingleton<CheckDomainInputs<TItem, TItemModel>>();
}
