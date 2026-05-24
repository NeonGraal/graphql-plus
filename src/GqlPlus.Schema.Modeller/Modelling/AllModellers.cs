using GqlPlus.Modelling.Globals;
using GqlPlus.Modelling.Objects;
using GqlPlus.Modelling.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Modelling;

public static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services, Action<IModellerRepositoryBuilder> config)
    => services
      .AddSingleton(new ModellerRepositoryBuilder().FluentInterface(config))
      .AddSingleton<IModellerRepository, ModellerRepository>();

  internal static IModellerRepositoryBuilder AddSchemaModellers(this IModellerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .CommonModellers()
      .SchemaModellers()
      .TypesModellers()
      .SimpleModellers()
      .ObjectModellers()
      .DualModellers()
      .InputModellers()
      .OutputModellers();

  private static IModellerRepositoryBuilder CommonModellers(this IModellerRepositoryBuilder builder)
    => builder
      .AddModeller(EnumValueModeller.Factory)
      .AddModeller(SimpleModeller.Factory)
      .AddModeller(ConstantModeller.Factory)
      .AddModifierModeller(ModifierModeller.Factory)
      .AddModeller<IAstModifier, ModifierModel>(ModifierModeller.Existing)
      .AddModeller<IAstModifier, CollectionModel>(ModifierModeller.Existing);

  private static IModellerRepositoryBuilder SchemaModellers(this IModellerRepositoryBuilder builder)
    => builder
      .AddModeller(SchemaModeller.Factory)
      .AddModeller(CategoryModeller.Factory)
      .AddModeller(DirectiveModeller.Factory)
      .AddModeller(SettingModeller.Factory);

  private static IModellerRepositoryBuilder TypesModellers(this IModellerRepositoryBuilder builder)
    => builder
      .AddTypesModeller(TypesModeller.Factory)
      .AddModeller(r => ((DeferOne<ITypesModeller>)r.TypesModeller()).I)
      .AddTypeModeller(SpecialTypeModeller.Factory);

  private static IModellerRepositoryBuilder SimpleModellers(this IModellerRepositoryBuilder builder)
    => builder
      .AddTypeModeller(DomainEnumModeller.Factory)
      .AddTypeModeller(DomainNumberModeller.Factory)
      .AddTypeModeller(DomainStringModeller.Factory)
      .AddTypeModeller(DomainBooleanModeller.Factory)
      .AddTypeModeller(EnumModeller.Factory)
      .AddTypeModeller(UnionModeller.Factory);

  private static IModellerRepositoryBuilder ObjectModellers(this IModellerRepositoryBuilder builder)
    => builder
      .AddModeller(TypeParamModeller.Factory)
      .AddModeller(TypeArgModeller.Factory)
      .AddModeller(ObjBaseModeller.Factory)
      .AddModeller(AlternateModeller.Factory);

  private static IModellerRepositoryBuilder DualModellers(this IModellerRepositoryBuilder builder)
    => builder
      .AddModeller(DualFieldModeller.Factory)
      .AddTypeModeller(DualModeller.Factory);

  private static IModellerRepositoryBuilder InputModellers(this IModellerRepositoryBuilder builder)
    => builder
      .AddModeller(InputFieldModeller.Factory)
      .AddTypeModeller(InputModeller.Factory)
      .AddModeller(InputParamModeller.Factory);

  private static IModellerRepositoryBuilder OutputModellers(this IModellerRepositoryBuilder builder)
    => builder
      .AddModeller(OutputFieldModeller.Factory)
      .AddTypeModeller(OutputModeller.Factory);
}
