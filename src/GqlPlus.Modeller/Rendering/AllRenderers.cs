﻿using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Rendering;

public static class AllRenderers
{
  public static IServiceCollection AddRenderers(this IServiceCollection services)
  => services
      // Common
      .AddRenderer<AliasedModel, AliasedRenderer<AliasedModel>>()
      .AddRenderer<ConstantModel, ConstantRenderer>()
      .AddRenderer<SimpleModel, SimpleRenderer>()
      .AddRenderer<CollectionModel, CollectionRenderer>()
      .AddRenderer<ModifierModel, ModifierRenderer>()
      // Schema
      .AddRenderer<SchemaModel, SchemaRenderer>()
      .AddRenderer<CategoriesModel, CategoriesRenderer>()
      .AddRenderer<CategoryModel, CategoryRenderer>()
      .AddRenderer<DirectivesModel, DirectivesRenderer>()
      .AddRenderer<DirectiveModel, DirectiveRenderer>()
      .AddRenderer<SettingModel, SettingRenderer>()
      // Types
      .AddRenderer<BaseTypeModel, AllTypesRenderer>()
      .AddDefaultRenderer<SpecialTypeModel>()
      // Simple
      .AddDomainRenderer<DomainMemberModel, DomainMemberRenderer>()
      .AddDomainRenderer<DomainRangeModel, DomainRangeRenderer>()
      .AddDomainRenderer<DomainRegexModel, DomainRegexRenderer>()
      .AddDomainRenderer<DomainTrueFalseModel, DomainTrueFalseRenderer>()
      .AddTypeRenderer<TypeEnumModel, TypeEnumRenderer>()
      .AddRenderer<EnumMemberModel, EnumMemberRenderer>()
      .AddTypeRenderer<TypeUnionModel, TypeUnionRenderer>()
      .AddRenderer<UnionMemberModel, UnionMemberRenderer>()
      // Object
      .AddDefaultRenderer<DualBaseModel>()
      .AddDefaultRenderer<InputBaseModel>()
      .AddDefaultRenderer<OutputBaseModel>()
      .AddDefaultRenderer<DualBaseModel>()
      .AddDefaultRenderer<DualFieldModel>()
      .AddDefaultRenderer<InputBaseModel>()
      .AddDefaultRenderer<InputFieldModel>()
      .AddDefaultRenderer<InputParameterModel>()
      .AddDefaultRenderer<OutputBaseModel>()
      .AddDefaultRenderer<OutputFieldModel>()
      .AddDefaultRenderer<TypeDualModel>()
      .AddDefaultRenderer<TypeInputModel>()
      .AddDefaultRenderer<TypeOutputModel>()
    ;

  private static IServiceCollection AddRenderer<TModel, TRenderer>(this IServiceCollection services)
    where TRenderer : class, IRenderer<TModel>
    => services.AddSingleton<IRenderer<TModel>, TRenderer>();

  private static IServiceCollection AddDomainRenderer<TItem, TRenderer>(this IServiceCollection services)
    where TItem : BaseDomainItemModel
    where TRenderer : class, IRenderer<TItem>
    => services
      .AddRenderer<TItem, TRenderer>()
      .AddTypeRenderer<BaseDomainModel<TItem>, BaseDomainRenderer<TItem>>()
      .AddRenderer<DomainItemModel<TItem>, DomainItemRenderer<TItem>>();

  private static IServiceCollection AddTypeRenderer<TModel, TRenderer>(this IServiceCollection services)
    where TRenderer : class, IRenderer<TModel>, ITypeRenderer
    => services
      .AddSingleton<TRenderer>()
      .AddProvider<TRenderer, IRenderer<TModel>>()
      .AddProvider<TRenderer, ITypeRenderer>();

  private static IServiceCollection AddDefaultRenderer<TModel>(this IServiceCollection services)
    where TModel : IRendering
    => services.AddSingleton<IRenderer<TModel>, DefaultRenderer<TModel>>();
}
