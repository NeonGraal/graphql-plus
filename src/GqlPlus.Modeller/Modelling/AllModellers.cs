using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
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

  internal static IModellerRepositoryBuilder AddSchemaModellers(this IModellerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Common
      .AddModeller<IAstEnumValue, EnumValueModel>(_ => new EnumValueModeller())
      .AddModeller<IAstFieldKey, SimpleModel>(r => new SimpleModeller(r))
      .AddModeller<IAstConstant, ConstantModel>(r => new ConstantModeller(r))
      .AddModifierModeller(_ => new ModifierModeller())
      .AddModeller<IAstModifier, ModifierModel>(r => r.ModifierModeller)
      .AddModeller<IAstModifier, CollectionModel>(r => r.ModifierModeller)
      // Schema
      .AddModeller<IAstSchema, SchemaModel>(r => new SchemaModeller(r))
      .AddModeller<IAstSchemaCategory, CategoryModel>(r => new CategoryModeller(r))
      .AddModeller<IAstSchemaDirective, DirectiveModel>(r => new DirectiveModeller(r))
      .AddModeller<IAstSchemaOperation, OperationModel>(r => new OperationModeller())
      .AddModeller<IAstSchemaSetting, SettingModel>(r => new SettingModeller(r))
      // Types
      .AddTypesModeller(r => new TypesModeller(r))
      .AddModeller<IAstType, BaseTypeModel>(r => r.TypesModeller)
      .AddTypeModeller<IAstTypeSpecial, SpecialTypeModel>(_ => new SpecialTypeModeller())
      // Simple - Domain
      .AddTypeModeller<IAstDomain<IAstDomainLabel>, BaseDomainModel<DomainLabelModel>>(_ => new DomainEnumModeller())
      .AddTypeModeller<IAstDomain<IAstDomainRange>, BaseDomainModel<DomainRangeModel>>(_ => new DomainNumberModeller())
      .AddTypeModeller<IAstDomain<IAstDomainRegex>, BaseDomainModel<DomainRegexModel>>(_ => new DomainStringModeller())
      .AddTypeModeller<IAstDomain<IAstDomainTrueFalse>, BaseDomainModel<DomainTrueFalseModel>>(_ => new DomainBooleanModeller())
      .AddTypeModeller<IAstEnum, TypeEnumModel>(_ => new EnumModeller())
      .AddTypeModeller<IAstUnion, TypeUnionModel>(_ => new UnionModeller())
      // Object
      .AddModeller<IAstTypeParam, TypeParamModel>(_ => new TypeParamModeller())
      .AddModeller<IAstTypeArg, TypeArgModel>(r => new TypeArgModeller(r))
      .AddModeller<IAstObjBase, ObjBaseModel>(r => new ObjBaseModeller(r))
      .AddModeller<IAstAlternate, AlternateModel>(r => new AlternateModeller(r))
      // Dual
      .AddModeller<IAstDualField, DualFieldModel>(r => new DualFieldModeller(r))
      .AddTypeModeller<IAstObject<IAstDualField>, TypeDualModel>(r => new DualModeller(r))
      // Input
      .AddModeller<IAstInputField, InputFieldModel>(r => new InputFieldModeller(r))
      .AddTypeModeller<IAstObject<IAstInputField>, TypeInputModel>(r => new InputModeller(r))
      .AddModeller<IAstInputParam, InputParamModel>(r => new InputParamModeller(r))
      // Output
      .AddModeller<IAstOutputField, OutputFieldModel>(r => new OutputFieldModeller(r))
      .AddTypeModeller<IAstObject<IAstOutputField>, TypeOutputModel>(r => new OutputModeller(r));
}
