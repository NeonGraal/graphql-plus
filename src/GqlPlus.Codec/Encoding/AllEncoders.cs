using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Encoding;

public static class AllEncoders
{
  public static IServiceCollection AddEncoders(this IServiceCollection services)
  {
    EncoderRepositoryBuilder builder = new();
    builder.AddSchemaEncoders();
    services.AddSingleton(builder);
    services.TryAddSingleton<IEncoderRepository, EncoderRepository>();
    return services;
  }

  internal static IEncoderRepositoryBuilder AddSchemaEncoders(this IEncoderRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Common
      .AddEncoder<AliasedModel>(_ => new AliasedEncoder<AliasedModel>())
      .AddEncoder<DescribedModel>(_ => new DescribedEncoder<DescribedModel>())
      .AddEncoder<NamedModel>(_ => new NamedEncoder<NamedModel>())
      .AddEncoder<ConstantModel>(r => new ConstantEncoder(r))
      .AddEncoder<SimpleModel>(_ => new SimpleEncoder())
      .AddEncoder<CollectionModel>(_ => new CollectionEncoder())
      .AddEncoder<ModifierModel>(_ => new ModifierEncoder())
      // Schema
      .AddEncoder<SchemaModel>(r => new SchemaEncoder(r))
      .AddEncoder<CategoriesModel>(r => new CategoriesEncoder(r))
      .AddEncoder<CategoryModel>(r => new CategoryEncoder(r))
      .AddEncoder<DirectivesModel>(r => new DirectivesEncoder(r))
      .AddEncoder<DirectiveModel>(r => new DirectiveEncoder(r))
      .AddEncoder<SettingModel>(r => new SettingEncoder(r))
      // Types
      .AddEncoder<BaseTypeModel>(r => new AllTypesEncoder(r))
      .AddEncoder<DomainRefModel>(_ => new DomainRefEncoder())
      .AddEncoder<TypeRefModel<SimpleKindModel>>(_ => new TypeRefEncoder<TypeRefModel<SimpleKindModel>, SimpleKindModel>())
      .AddEncoder<TypeRefModel<TypeKindModel>>(_ => new TypeRefEncoder<TypeRefModel<TypeKindModel>, TypeKindModel>())
      .AddTypeEncoder<SpecialTypeModel>(_ => new SpecialTypeEncoder())
      // Domain
      .AddEncoder<DomainLabelModel>(r => new DomainLabelEncoder(r))
      .AddEncoder<DomainItemModel<DomainLabelModel>>(r => new DomainItemEncoder<DomainLabelModel>(r))
      .AddTypeEncoder<BaseDomainModel<DomainLabelModel>>(r => new BaseDomainEncoder<DomainLabelModel>(r))
      .AddEncoder<DomainRangeModel>(_ => new DomainRangeEncoder())
      .AddEncoder<DomainItemModel<DomainRangeModel>>(r => new DomainItemEncoder<DomainRangeModel>(r))
      .AddTypeEncoder<BaseDomainModel<DomainRangeModel>>(r => new BaseDomainEncoder<DomainRangeModel>(r))
      .AddEncoder<DomainRegexModel>(_ => new DomainRegexEncoder())
      .AddEncoder<DomainItemModel<DomainRegexModel>>(r => new DomainItemEncoder<DomainRegexModel>(r))
      .AddTypeEncoder<BaseDomainModel<DomainRegexModel>>(r => new BaseDomainEncoder<DomainRegexModel>(r))
      .AddEncoder<DomainTrueFalseModel>(_ => new DomainTrueFalseEncoder())
      .AddEncoder<DomainItemModel<DomainTrueFalseModel>>(r => new DomainItemEncoder<DomainTrueFalseModel>(r))
      .AddTypeEncoder<BaseDomainModel<DomainTrueFalseModel>>(r => new BaseDomainEncoder<DomainTrueFalseModel>(r))
      // Enum
      .AddEncoder<EnumLabelModel>(_ => new EnumLabelEncoder())
      .AddTypeEncoder<TypeEnumModel>(r => new TypeEnumEncoder(r))
      .AddEncoder<EnumValueModel>(_ => new EnumValueEncoder())
      // Union
      .AddEncoder<UnionMemberModel>(_ => new UnionMemberEncoder())
      .AddTypeEncoder<TypeUnionModel>(r => new TypeUnionEncoder(r))
      // Object
      .AddEncoder<ObjBaseModel>(r => new ObjectBaseEncoder<ObjBaseModel>(r))
      .AddEncoder<TypeParamModel>(r => new TypeParamEncoder(r))
      .AddEncoder<AlternateModel>(r => new ObjectAlternateEncoder(r))
      .AddEncoder<ObjectForModel<AlternateModel>>(r => new ObjectForEncoder<AlternateModel>(r))
      .AddEncoder<TypeArgModel>(r => new TypeArgEncoder(r))
      // Dual
      .AddEncoder<DualFieldModel>(r => new DualFieldEncoder(r))
      .AddEncoder<ObjectForModel<DualFieldModel>>(r => new ObjectForEncoder<DualFieldModel>(r))
      .AddTypeEncoder<TypeDualModel>(r => new TypeDualEncoder(r))
      // Input
      .AddEncoder<InputFieldModel>(r => new InputFieldEncoder(r))
      .AddEncoder<InputParamModel>(r => new InputParamEncoder(r))
      .AddEncoder<ObjectForModel<InputFieldModel>>(r => new ObjectForEncoder<InputFieldModel>(r))
      .AddTypeEncoder<TypeInputModel>(r => new TypeInputEncoder(r))
      // Output
      .AddEncoder<OutputEnumModel>(_ => new OutputEnumEncoder())
      .AddEncoder<OutputFieldModel>(r => new OutputFieldEncoder(r))
      .AddEncoder<ObjectForModel<OutputFieldModel>>(r => new ObjectForEncoder<OutputFieldModel>(r))
      .AddTypeEncoder<TypeOutputModel>(r => new TypeOutputEncoder(r));
}
