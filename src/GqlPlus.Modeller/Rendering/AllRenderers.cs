using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Rendering;

public static class AllRenderers
{
  public static IServiceCollection AddRenderers(this IServiceCollection services)
  => services
      // Common
      .AddRenderer<AliasedModel, AliasedRenderer<AliasedModel>>()
      .AddRenderer<DescribedModel, DescribedRenderer<DescribedModel>>()
      .AddRenderer<NamedModel, NamedRenderer<NamedModel>>()
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
      .AddDomainRenderer<DomainLabelModel, DomainLabelRenderer>()
      .AddDomainRenderer<DomainRangeModel, DomainRangeRenderer>()
      .AddDomainRenderer<DomainRegexModel, DomainRegexRenderer>()
      .AddDomainRenderer<DomainTrueFalseModel, DomainTrueFalseRenderer>()
      // Enum
      .AddTypeRenderer<TypeEnumModel, TypeEnumRenderer>()
      .AddItemRenderer<EnumLabelModel, EnumLabelRenderer>()
      .AddRenderer<EnumValueModel, EnumValueRenderer>()
      // Union
      .AddTypeRenderer<TypeUnionModel, TypeUnionRenderer>()
      .AddItemRenderer<UnionMemberModel, UnionMemberRenderer>()
      // Object
      .AddRenderer<TypeParamModel, TypeParamRenderer>()
      // Dual
      .AddRenderer<DualArgModel, DualArgRenderer>()
      .AddRenderer<DualBaseModel, DualBaseRenderer>()
      .AddBaseRenderer<DualBaseModel>()
      .AddRenderer<DualFieldModel, DualFieldRenderer>()
      .AddTypeRenderer<TypeDualModel, TypeDualRenderer>()
      .AddObjectRenderers<DualBaseModel, DualFieldModel, DualAlternateModel>()
      // Input
      .AddRenderer<InputArgModel, InputArgRenderer>()
      .AddRenderer<InputBaseModel, InputBaseRenderer>()
      .AddBaseRenderer<InputBaseModel>()
      .AddRenderer<InputFieldModel, InputFieldRenderer>()
      .AddRenderer<InputParamModel, InputParamRenderer>()
      .AddTypeRenderer<TypeInputModel, TypeInputRenderer>()
      .AddObjectRenderers<InputBaseModel, InputFieldModel, InputAlternateModel>()
      // Output
      .AddRenderer<OutputArgModel, OutputArgRenderer>()
      .AddRenderer<OutputBaseModel, OutputBaseRenderer>()
      .AddBaseRenderer<OutputBaseModel>()
      .AddRenderer<OutputEnumModel, OutputEnumRenderer>()
      .AddRenderer<OutputFieldModel, OutputFieldRenderer>()
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
    where TAlt : ObjAlternateModel<TBase>
    => services
      .AddRenderer<ObjectForModel<TAlt>, ObjectForRenderer<TAlt>>()
      .AddRenderer<ObjectForModel<TField>, ObjectForRenderer<TField>>()
      .AddRenderer<TAlt, ObjectAlternateRenderer<TAlt, TBase>>()
      .AddSingleton<TypeObjectRenderers<TBase, TField, TAlt>>();

  private static IServiceCollection AddBaseRenderer<TBase>(this IServiceCollection services)
    where TBase : ModelBase, IObjBaseModel
    where TArg : IObjTypeArgModel
    => services
      .AddSingleton<FieldRenderers<TBase>>()
      .AddSingleton<AlternateRenderers<TBase>>();
}
