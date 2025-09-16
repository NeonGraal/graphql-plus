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
      .AddEncoder<ObjBaseModel, DualBaseEncoder>()
      .AddBaseEncoder<ObjBaseModel>()
      .AddEncoder<DualFieldModel, DualFieldEncoder>()
      .AddTypeEncoder<TypeDualModel, TypeDualEncoder>()
      .AddObjectEncoders<DualFieldModel>()
      // Input
      .AddEncoder<ObjBaseModel, InputBaseEncoder>()
      .AddBaseEncoder<ObjBaseModel>()
      .AddEncoder<InputFieldModel, InputFieldEncoder>()
      .AddEncoder<InputParamModel, InputParamEncoder>()
      .AddTypeEncoder<TypeInputModel, TypeInputEncoder>()
      .AddObjectEncoders<InputFieldModel>()
      // Output
      .AddEncoder<ObjBaseModel, OutputBaseEncoder>()
      .AddBaseEncoder<ObjBaseModel>()
      .AddEncoder<OutputEnumModel, OutputEnumEncoder>()
      .AddEncoder<OutputFieldModel, OutputFieldEncoder>()
      .AddTypeEncoder<TypeOutputModel, TypeOutputEncoder>()
      .AddObjectEncoders<OutputFieldModel>()
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

  private static IServiceCollection AddObjectEncoders<TField>(this IServiceCollection services)
    where TField : IObjFieldModel
    => services
      .AddEncoder<ObjectForModel<ObjAlternateModel>, ObjectForEncoder<ObjAlternateModel>>()
      .AddEncoder<ObjectForModel<TField>, ObjectForEncoder<TField>>()
      .AddEncoder<ObjAlternateModel, ObjectAlternateEncoder>()
      .AddSingleton<TypeObjectEncoders<TField>>();

  private static IServiceCollection AddBaseEncoder<TBase>(this IServiceCollection services)
    where TBase : ModelBase, IObjBaseModel
    => services
      .AddSingleton<FieldEncoders<TBase>>()
      .AddSingleton<AlternateEncoders<TBase>>();
}
