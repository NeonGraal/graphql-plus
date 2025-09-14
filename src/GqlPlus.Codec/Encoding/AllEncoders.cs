using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Encoding;

public static class AllEncoders
{
  public static IServiceCollection AddEncoders(this IServiceCollection services)
  => services
      // Common
      .AddEncoder<AliasedModel, AliasedEncoder<AliasedModel>>()
      .AddEncoder<DescribedModel, DescribedEncoder<DescribedModel>>()
      .AddEncoder<NamedModel, NamedEncoder<NamedModel>>()
      .AddEncoder<ConstantModel, ConstantEncoder>()
      .AddEncoder<SimpleModel, SimpleEncoder>()
      .AddEncoder<CollectionModel, CollectionEncoder>()
      .AddEncoder<ModifierModel, ModifierEncoder>()
      // Schema
      .AddEncoder<SchemaModel, SchemaEncoder>()
      .AddEncoder<CategoriesModel, CategoriesEncoder>()
      .AddEncoder<CategoryModel, CategoryEncoder>()
      .AddSingleton<AndBaseTypeEncoders<CategoryModel>>()
      .AddEncoder<DirectivesModel, DirectivesEncoder>()
      .AddEncoder<DirectiveModel, DirectiveEncoder>()
      .AddSingleton<AndBaseTypeEncoders<DirectiveModel>>()
      .AddEncoder<SettingModel, SettingEncoder>()
      // Types
      .AddEncoder<BaseTypeModel, AllTypesEncoder>()
      .AddEncoder<DomainRefModel, DomainRefEncoder>()
      .AddEncoder<TypeRefModel<SimpleKindModel>, TypeRefEncoder<TypeRefModel<SimpleKindModel>, SimpleKindModel>>()
      .AddEncoder<TypeRefModel<TypeKindModel>, TypeRefEncoder<TypeRefModel<TypeKindModel>, TypeKindModel>>()
      .AddTypeEncoder<SpecialTypeModel, SpecialTypeEncoder>()
      // Simple
      // Domain
      .AddDomainEncoder<DomainLabelModel, DomainLabelEncoder>()
      .AddDomainEncoder<DomainRangeModel, DomainRangeEncoder>()
      .AddDomainEncoder<DomainRegexModel, DomainRegexEncoder>()
      .AddDomainEncoder<DomainTrueFalseModel, DomainTrueFalseEncoder>()
      // Enum
      .AddTypeEncoder<TypeEnumModel, TypeEnumEncoder>()
      .AddItemEncoder<AliasedModel, EnumLabelModel, EnumLabelEncoder>()
      .AddEncoder<EnumValueModel, EnumValueEncoder>()
      // Union
      .AddTypeEncoder<TypeUnionModel, TypeUnionEncoder>()
      .AddItemEncoder<NamedModel, UnionMemberModel, UnionMemberEncoder>()
      // Object
      .AddEncoder<TypeParamModel, TypeParamEncoder>()
      .AddEncoder<ObjTypeArgModel, ObjTypeArgEncoder>()
      // Dual
      .AddEncoder<DualBaseModel, DualBaseEncoder>()
      .AddBaseEncoder<DualBaseModel>()
      .AddEncoder<DualFieldModel, DualFieldEncoder>()
      .AddTypeEncoder<TypeDualModel, TypeDualEncoder>()
      .AddObjectEncoders<DualBaseModel, DualFieldModel, DualAlternateModel>()
      // Input
      .AddEncoder<InputBaseModel, InputBaseEncoder>()
      .AddBaseEncoder<InputBaseModel>()
      .AddEncoder<InputFieldModel, InputFieldEncoder>()
      .AddEncoder<InputParamModel, InputParamEncoder>()
      .AddTypeEncoder<TypeInputModel, TypeInputEncoder>()
      .AddObjectEncoders<InputBaseModel, InputFieldModel, InputAlternateModel>()
      // Output
      .AddEncoder<OutputBaseModel, OutputBaseEncoder>()
      .AddBaseEncoder<OutputBaseModel>()
      .AddEncoder<OutputEnumModel, OutputEnumEncoder>()
      .AddEncoder<OutputFieldModel, OutputFieldEncoder>()
      .AddTypeEncoder<TypeOutputModel, TypeOutputEncoder>()
      .AddObjectEncoders<OutputBaseModel, OutputFieldModel, OutputAlternateModel>()
    ;

  private static IServiceCollection AddEncoder<TModel, TEncoder>(this IServiceCollection services)
    where TModel : IModelBase
    where TEncoder : class, IEncoder<TModel>
    => services.AddSingleton<IEncoder<TModel>, TEncoder>();

  private static IServiceCollection AddDomainEncoder<TItem, TEncoder>(this IServiceCollection services)
    where TItem : BaseDomainItemModel
    where TEncoder : class, IEncoder<TItem>
    => services
      .AddEncoder<TItem, TEncoder>()
      .AddSingleton<ParentTypeEncoders<TItem, DomainItemModel<TItem>>>()
      .AddTypeEncoder<BaseDomainModel<TItem>, BaseDomainEncoder<TItem>>()
      .AddEncoder<DomainItemModel<TItem>, DomainItemEncoder<TItem>>();

  private static IServiceCollection AddItemEncoder<TItem, TAll, TEncoder>(this IServiceCollection services)
    where TItem : NamedModel
    where TAll : NamedModel
    where TEncoder : class, IEncoder<TAll>
    => services
      .AddEncoder<TAll, TEncoder>()
      .AddSingleton<ParentTypeEncoders<TItem, TAll>>();

  private static IServiceCollection AddTypeEncoder<TModel, TEncoder>(this IServiceCollection services)
    where TModel : IModelBase
    where TEncoder : class, IEncoder<TModel>, ITypeEncoder
    => services
      .AddSingleton<TEncoder>()
      .AddProvider<TEncoder, IEncoder<TModel>>()
      .AddProvider<TEncoder, ITypeEncoder>();

  private static IServiceCollection AddObjectEncoders<TBase, TField, TAlt>(this IServiceCollection services)
    where TBase : IObjBaseModel
    where TField : IObjFieldModel
    where TAlt : ObjAlternateModel<TBase>
    => services
      .AddEncoder<ObjectForModel<TAlt>, ObjectForEncoder<TAlt>>()
      .AddEncoder<ObjectForModel<TField>, ObjectForEncoder<TField>>()
      .AddEncoder<TAlt, ObjectAlternateEncoder<TAlt, TBase>>()
      .AddSingleton<TypeObjectEncoders<TBase, TField, TAlt>>();

  private static IServiceCollection AddBaseEncoder<TBase>(this IServiceCollection services)
    where TBase : ModelBase, IObjBaseModel
    => services
      .AddSingleton<FieldEncoders<TBase>>()
      .AddSingleton<AlternateEncoders<TBase>>();
}
