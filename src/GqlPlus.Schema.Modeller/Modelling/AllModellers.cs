using System.Diagnostics.CodeAnalysis;
using GqlPlus.Modelling.Globals;
using GqlPlus.Modelling.Objects;
using GqlPlus.Modelling.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Modelling;

public static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services, Action<IModellerRepositoryBuilder> config)
    => services
      .AddSingleton(new ModellerRepositoryBuilder().FluentAction(b => config(b)))
      .AddSingleton<IModellerRepository, ModellerRepository>();

  [ExcludeFromCodeCoverage]
  public static IModellerRepositoryBuilder AddSchemaModellers(this IModellerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Common
      .AddModeller(EnumValueModeller.Factory)
      .AddModeller(SimpleModeller.Factory)
      .AddModeller(ConstantModeller.Factory)
      .AddModifierModeller(ModifierModeller.Factory)
      .AddModeller<IAstModifier, ModifierModel>(ModifierModeller.Existing)
      .AddModeller<IAstModifier, CollectionModel>(ModifierModeller.Existing)
      // Schema
      .AddModeller(SchemaModeller.Factory)
      .AddModeller(CategoryModeller.Factory)
      .AddModeller(DirectiveModeller.Factory)
      .AddModeller(SettingModeller.Factory)
      // Types
      .AddTypesModeller(TypesModeller.Factory)
      .AddModeller(TypesModeller.Existing)
      .AddTypeModeller(SpecialTypeModeller.Factory)
      // Simple - Domain
      .AddTypeModeller(DomainEnumModeller.Factory)
      .AddTypeModeller(DomainNumberModeller.Factory)
      .AddTypeModeller(DomainStringModeller.Factory)
      .AddTypeModeller(DomainBooleanModeller.Factory)
      .AddTypeModeller(EnumModeller.Factory)
      .AddTypeModeller(UnionModeller.Factory)
      // Object
      .AddModeller(TypeParamModeller.Factory)
      .AddModeller(TypeArgModeller.Factory)
      .AddModeller(ObjBaseModeller.Factory)
      .AddModeller(AlternateModeller.Factory)
      // Dual
      .AddModeller(DualFieldModeller.Factory)
      .AddTypeModeller(DualModeller.Factory)
      // Input
      .AddModeller(InputFieldModeller.Factory)
      .AddTypeModeller(InputModeller.Factory)
      .AddModeller(InputParamModeller.Factory)
      // Output
      .AddModeller(OutputFieldModeller.Factory)
      .AddTypeModeller(OutputModeller.Factory);
}
