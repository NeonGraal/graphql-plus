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
      .AddItemRenderer<EnumMemberModel, EnumMemberRenderer>()
      .AddTypeRenderer<TypeUnionModel, TypeUnionRenderer>()
      .AddItemRenderer<UnionMemberModel, UnionMemberRenderer>()
      // Object
      .AddBaseRenderer<DualBaseModel, DualBaseRenderer>()
      .AddRenderer<DualFieldModel, DualFieldRenderer>()
      .AddBaseRenderer<InputBaseModel, InputBaseRenderer>()
      .AddRenderer<InputFieldModel, InputFieldRenderer>()
      .AddRenderer<InputParameterModel, InputParameterRenderer>()
      .AddDefaultRenderer<OutputArgumentModel>()
      .AddBaseRenderer<OutputBaseModel, OutputBaseRenderer>()
      .AddDefaultRenderer<OutputEnumModel>()
      .AddRenderer<OutputFieldModel, OutputFieldRenderer>()
      .AddRenderer<TypeDualModel, TypeDualRenderer>()
      .AddObjectRenderers<DualFieldModel, DualBaseModel>()
      .AddRenderer<TypeInputModel, TypeInputRenderer>()
      .AddObjectRenderers<InputFieldModel, InputBaseModel>()
      .AddRenderer<TypeOutputModel, TypeOutputRenderer>()
      .AddObjectRenderers<OutputFieldModel, OutputBaseModel>()
    ;

  private static IServiceCollection AddRenderer<TModel, TRenderer>(this IServiceCollection services)
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
    where TRenderer : class, IRenderer<TModel>, ITypeRenderer
    => services
      .AddSingleton<TRenderer>()
      .AddProvider<TRenderer, IRenderer<TModel>>()
      .AddProvider<TRenderer, ITypeRenderer>();

  private static IServiceCollection AddObjectRenderers<TField, TBase>(this IServiceCollection services)
    where TBase : IObjBaseModel
    where TField : ModelBase
    => services
    .AddRenderer<AlternateModel<TBase>, AlternateRenderer<TBase>>()
    .AddRenderer<ObjectForModel<AlternateModel<TBase>>, ObjectForRenderer<AlternateModel<TBase>>>()
    .AddRenderer<ObjectForModel<TField>, ObjectForRenderer<TField>>()
    .AddSingleton<TypeObjectRenderers<TField, TBase>>();

  private static IServiceCollection AddBaseRenderer<TBase, TRenderer>(this IServiceCollection services)
    where TBase : ModelBase, IObjBaseModel
    where TRenderer : class, IRenderer<TBase>
    => services
      .AddSingleton<ObjectFieldRenderers<TBase>>()
      .AddRenderer<TBase, TRenderer>()
      .AddRenderer<ObjDescribedModel<TBase>, BaseDescribedRenderer<TBase>>();

  private static IServiceCollection AddDefaultRenderer<TModel>(this IServiceCollection services)
    where TModel : IRendering
    => services.AddSingleton<IRenderer<TModel>, DefaultRenderer<TModel>>();
}
