using System.Diagnostics.CodeAnalysis;
using GqlPlus.Modelling.Globals;
using GqlPlus.Modelling.Objects;
using GqlPlus.Modelling.Simple;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Modelling;

public static class AllModellers
{
  public static IServiceCollection AddModellers(this IServiceCollection services)
  {
    ModellerRepositoryBuilder builder = new();
    builder.AddSchemaModellers();
    services.AddSingleton(builder);
    services.TryAddSingleton<IModellerRepository, ModellerRepository>();
    return services;
  }

  [ExcludeFromCodeCoverage]
  internal static IModellerRepositoryBuilder AddSchemaModellers(this IModellerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Common
      .AddModeller(EnumValueModeller.Factory)
      .AddModeller(SimpleModeller.Factory)
      .AddModeller(ConstantModeller.Factory)
      .AddModifierModeller(ModifierModeller.Factory)
      .AddModeller<IAstModifier, ModifierModel>(r => r.ModifierModeller)
      .AddModeller<IAstModifier, CollectionModel>(r => r.ModifierModeller)
      // Schema
      .AddModeller(SchemaModeller.Factory)
      .AddModeller(CategoryModeller.Factory)
      .AddModeller(DirectiveModeller.Factory)
      .AddModeller(OperationModeller.Factory)
      .AddModeller(SettingModeller.Factory)
      // Types
      .AddTypesModeller(TypesModeller.Factory)
      .AddModeller(r => r.TypesModeller)
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
