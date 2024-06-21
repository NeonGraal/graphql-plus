using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Rendering;

public static class AllRenderers
{
  public static IServiceCollection AddRenderers(this IServiceCollection services)
  => services
      // Common
      .AddRenderer<AliasedModel, AliasedRenderer<AliasedModel>>()
      .AddRenderer<DescribedModel, DescribedRenderer<DescribedModel>>()
      .AddRenderer<ConstantModel, ConstantRenderer>()
      .AddRenderer<SimpleModel, SimpleRenderer>()
      .AddRenderer<CollectionModel, CollectionRenderer>()
      .AddRenderer<ModifierModel, ModifierRenderer>()
      // Schema
      .AddRenderer<SchemaModel, SchemaRenderer>()
      .AddRenderer<CategoriesModel, CategoriesRenderer>()
      .AddRenderer<CategoryModel, CategoryRenderer>()
      .AddSingleton<AndBaseTypeRenderers<CategoryModel>>()
      .AddRenderer<DirectivesModel, DirectivesRenderer>()
      .AddRenderer<DirectiveModel, DirectiveRenderer>()
      .AddSingleton<AndBaseTypeRenderers<DirectiveModel>>()
      .AddRenderer<SettingModel, SettingRenderer>()
      // Types
      .AddRenderer<BaseTypeModel, AllTypesRenderer>()
      .AddRenderer<TypeRefModel<SimpleKindModel>, TypeRefRenderer<TypeRefModel<SimpleKindModel>, SimpleKindModel>>()
      .AddRenderer<TypeRefModel<TypeKindModel>, TypeRefRenderer<TypeRefModel<TypeKindModel>, TypeKindModel>>()
      .AddTypeRenderer<SpecialTypeModel, SpecialTypeRenderer>()
      // Simple
      // Domain
      .AddDomainRenderer<DomainMemberModel, DomainMemberRenderer>()
      .AddDomainRenderer<DomainRangeModel, DomainRangeRenderer>()
      .AddDomainRenderer<DomainRegexModel, DomainRegexRenderer>()
      .AddDomainRenderer<DomainTrueFalseModel, DomainTrueFalseRenderer>()
      // Enum
      .AddTypeRenderer<TypeEnumModel, TypeEnumRenderer>()
      .AddItemRenderer<EnumMemberModel, EnumMemberRenderer>()
      .AddRenderer<EnumValueModel, EnumValueRenderer>()
      // Union
      .AddTypeRenderer<TypeUnionModel, TypeUnionRenderer>()
      .AddItemRenderer<UnionMemberModel, UnionMemberRenderer>()
      // Object
      // Dual
      .AddRenderer<DualBaseModel, DualBaseRenderer>()
      .AddBaseRenderer<DualBaseModel>()
      .AddRenderer<DualFieldModel, DualFieldRenderer>()
      .AddRenderer<DualAlternateModel, DualAlternateRenderer>()
      .AddTypeRenderer<TypeDualModel, TypeDualRenderer>()
      .AddObjectRenderers<DualBaseModel, DualFieldModel, DualAlternateModel>()
      // Input
      .AddRenderer<InputBaseModel, InputBaseRenderer>()
      .AddBaseRenderer<InputBaseModel>()
      .AddRenderer<InputFieldModel, InputFieldRenderer>()
      .AddRenderer<InputAlternateModel, InputAlternateRenderer>()
      .AddRenderer<InputParameterModel, InputParameterRenderer>()
      .AddTypeRenderer<TypeInputModel, TypeInputRenderer>()
      .AddObjectRenderers<InputBaseModel, InputFieldModel, InputAlternateModel>()
      // Output
      .AddOutputBaseRenderer()
      .AddBaseRenderer<OutputBaseModel>()
      .AddRenderer<OutputEnumModel, OutputEnumRenderer>()
      .AddRenderer<OutputFieldModel, OutputFieldRenderer>()
      .AddRenderer<OutputAlternateModel, OutputAlternateRenderer>()
      .AddTypeRenderer<TypeOutputModel, TypeOutputRenderer>()
      .AddObjectRenderers<OutputBaseModel, OutputFieldModel, OutputAlternateModel>()
    ;

  private static IServiceCollection AddRenderer<TModel, TRenderer>(this IServiceCollection services)
    where TModel : IModelBase
    where TRenderer : class, IRenderer<TModel>
    => services.AddSingleton<IRenderer<TModel>, TRenderer>();

  private static IServiceCollection AddDomainRenderer<TItem, TRenderer>(this IServiceCollection services)
    where TItem : BaseDomainItemModel
    where TRenderer : class, IRenderer<TItem>
    => services
      .AddRenderer<TItem, TRenderer>()
      .AddSingleton<ParentTypeRenderers<TItem, DomainItemModel<TItem>>>()
      .AddTypeRenderer<BaseDomainModel<TItem>, BaseDomainRenderer<TItem>>()
      .AddRenderer<DomainItemModel<TItem>, DomainItemRenderer<TItem>>();

  private static IServiceCollection AddItemRenderer<TItem, TRenderer>(this IServiceCollection services)
    where TItem : AliasedModel
    where TRenderer : class, IRenderer<TItem>
    => services
      .AddRenderer<TItem, TRenderer>()
      .AddSingleton<ParentTypeRenderers<AliasedModel, TItem>>();

  private static IServiceCollection AddTypeRenderer<TModel, TRenderer>(this IServiceCollection services)
    where TModel : IModelBase
    where TRenderer : class, IRenderer<TModel>, ITypeRenderer
    => services
      .AddSingleton<TRenderer>()
      .AddProvider<TRenderer, IRenderer<TModel>>()
      .AddProvider<TRenderer, ITypeRenderer>();

  private static IServiceCollection AddObjectRenderers<TBase, TField, TAlt>(this IServiceCollection services)
    where TBase : IObjBaseModel
    where TField : IObjFieldModel
    where TAlt : IObjAlternateModel
    => services
    .AddRenderer<ObjectForModel<TAlt>, ObjectForRenderer<TAlt>>()
    .AddRenderer<ObjectForModel<TField>, ObjectForRenderer<TField>>()
    .AddSingleton<TypeObjectRenderers<TBase, TField, TAlt>>();

  private static IServiceCollection AddBaseRenderer<TBase>(this IServiceCollection services)
    where TBase : ModelBase, IObjBaseModel
    => services
      .AddSingleton<ModifierBaseRenderers<TBase>>()
      .AddSingleton<CollectionBaseRenderers<TBase>>()
      .AddRenderer<ObjDescribedModel<TBase>, BaseDescribedRenderer<TBase>>();

  private static IServiceCollection AddOutputBaseRenderer(this IServiceCollection services)
    => services
      .AddSingleton<OutputArgumentAndBaseRenderer>()
      .AddProvider<OutputArgumentAndBaseRenderer, IRenderer<OutputArgumentModel>>()
      .AddProvider<OutputArgumentAndBaseRenderer, IRenderer<OutputBaseModel>>();
}
