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
      .AddModeller<IAstFieldKey, SimpleModel>(r => new SimpleModeller(r.ModellerFor<IAstEnumValue, EnumValueModel>()))
      .AddModeller<IAstConstant, ConstantModel>(r => new ConstantModeller(r.ModellerFor<IAstFieldKey, SimpleModel>()))
      .AddModifierModeller(_ => new ModifierModeller())
      .AddModeller<IAstModifier, ModifierModel>(r => r.ModifierModeller)
      .AddModeller<IAstModifier, CollectionModel>(r => r.ModifierModeller)
      // Schema
      .AddModeller<IAstSchema, SchemaModel>(r => new SchemaModeller(
        r.ModellerFor<IAstSchemaCategory, CategoryModel>(),
        r.ModellerFor<IAstSchemaDirective, DirectiveModel>(),
        r.ModellerFor<IAstSchemaSetting, SettingModel>(),
        r.TypesModeller))
      .AddModeller<IAstSchemaCategory, CategoryModel>(r => new CategoryModeller(
        r.ModellerFor<IAstModifier, ModifierModel>()))
      .AddModeller<IAstSchemaDirective, DirectiveModel>(r => new DirectiveModeller(
        r.ModellerFor<IAstInputParam, InputParamModel>()))
      .AddModeller<IAstSchemaSetting, SettingModel>(r => new SettingModeller(
        r.ModellerFor<IAstConstant, ConstantModel>()))
      // Types
      .AddTypesModeller(r => new TypesModeller(r.TypeModellers))
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
      .AddModeller<IAstTypeArg, TypeArgModel>(r => new TypeArgModeller(r.ModellerFor<IAstEnumValue, EnumValueModel>()))
      .AddModeller<IAstObjBase, ObjBaseModel>(r => new ObjBaseModeller(r.ModellerFor<IAstTypeArg, TypeArgModel>()))
      .AddModeller<IAstAlternate, AlternateModel>(r => new AlternateModeller(
        r.ModellerFor<IAstModifier, CollectionModel>(),
        r.ModellerFor<IAstObjBase, ObjBaseModel>()))
      // Dual
      .AddModeller<IAstDualField, DualFieldModel>(r => new DualFieldModeller(
        r.ModifierModeller,
        r.ModellerFor<IAstObjBase, ObjBaseModel>()))
      .AddTypeModeller<IAstObject<IAstDualField>, TypeDualModel>(r => new DualModeller(
        new ObjectModellers<IAstDualField, DualFieldModel>(
          r.ModellerFor<IAstTypeParam, TypeParamModel>(),
          r.ModellerFor<IAstAlternate, AlternateModel>(),
          r.ModellerFor<IAstDualField, DualFieldModel>(),
          r.ModellerFor<IAstObjBase, ObjBaseModel>())))
      // Input
      .AddModeller<IAstInputField, InputFieldModel>(r => new InputFieldModeller(
        r.ModifierModeller,
        r.ModellerFor<IAstObjBase, ObjBaseModel>(),
        r.ModellerFor<IAstConstant, ConstantModel>()))
      .AddTypeModeller<IAstObject<IAstInputField>, TypeInputModel>(r => new InputModeller(
        new ObjectModellers<IAstInputField, InputFieldModel>(
          r.ModellerFor<IAstTypeParam, TypeParamModel>(),
          r.ModellerFor<IAstAlternate, AlternateModel>(),
          r.ModellerFor<IAstInputField, InputFieldModel>(),
          r.ModellerFor<IAstObjBase, ObjBaseModel>())))
      .AddModeller<IAstInputParam, InputParamModel>(r => new InputParamModeller(
        r.ModifierModeller,
        r.ModellerFor<IAstConstant, ConstantModel>()))
      // Output
      .AddModeller<IAstOutputField, OutputFieldModel>(r => new OutputFieldModeller(
        r.ModifierModeller,
        r.ModellerFor<IAstInputParam, InputParamModel>(),
        r.ModellerFor<IAstObjBase, ObjBaseModel>()))
      .AddTypeModeller<IAstObject<IAstOutputField>, TypeOutputModel>(r => new OutputModeller(
        new ObjectModellers<IAstOutputField, OutputFieldModel>(
          r.ModellerFor<IAstTypeParam, TypeParamModel>(),
          r.ModellerFor<IAstAlternate, AlternateModel>(),
          r.ModellerFor<IAstOutputField, OutputFieldModel>(),
          r.ModellerFor<IAstObjBase, ObjBaseModel>())));
}
