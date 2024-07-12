using GqlPlus.Modelling.Globals;
using GqlPlus.Modelling.Objects;
using GqlPlus.Modelling.Simple;

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
      .AddTransient<IDomainEnumModelChecks, DomainEnumModelChecks>()
      .AddTransient<IDomainNumberModelChecks, DomainNumberModelChecks>()
      .AddTransient<IDomainStringModelChecks, DomainStringModelChecks>()
      .AddTransient<IEnumModelChecks, EnumModelChecks>()
      .AddTransient<IUnionModelChecks, UnionModelChecks>()

      .AddTransient<IDualBaseModelChecks, DualBaseModelChecks>()
      .AddTransient<IDualFieldModelChecks, DualFieldModelChecks>()
      .AddTransient<IDualModelChecks, DualModelChecks>()
      .AddTransient<IInputBaseModelChecks, InputBaseModelChecks>()
      .AddTransient<IInputFieldModelChecks, InputFieldModelChecks>()
      .AddTransient<IInputModelChecks, InputModelChecks>()
      .AddTransient<ICheckDescribedModel<string, InputParameterModel>, InputParameterModelChecks>()
      .AddTransient<IOutputBaseModelChecks, OutputBaseModelChecks>()
      .AddTransient<IOutputFieldModelChecks, OutputFieldModelChecks>()
      .AddTransient<IOutputModelChecks, OutputModelChecks>()

      .AddComponentTest()
      .AddModellers()
      .AddRenderers();
}
