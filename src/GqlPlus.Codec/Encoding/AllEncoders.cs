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
      .AddEncoder(AliasedEncoder<AliasedModel>.Factory)
      .AddEncoder(NamedEncoder<NamedModel>.Factory)
      .AddEncoder(ConstantEncoder.Factory)
      .AddEncoder(SimpleEncoder.Factory)
      .AddEncoder(CollectionEncoder.Factory)
      .AddEncoder<ModifierModel>(ModifierEncoder.Factory)
      // Schema
      .AddEncoder(SchemaEncoder.Factory)
      .AddEncoder(CategoriesEncoder.Factory)
      .AddEncoder(CategoryEncoder.Factory)
      .AddEncoder(DirectivesEncoder.Factory)
      .AddEncoder(DirectiveEncoder.Factory)
      .AddEncoder(SettingEncoder.Factory)
      // Types
      .AddEncoder(AllTypesEncoder.Factory)
      .AddEncoder(DomainRefEncoder.Factory)
      .AddEncoder(TypeRefEncoder<TypeRefModel<SimpleKindModel>, SimpleKindModel>.Factory)
      .AddEncoder(TypeRefEncoder<TypeRefModel<TypeKindModel>, TypeKindModel>.Factory)
      .AddTypeEncoder(SpecialTypeEncoder.Factory)
      // Domain
      .AddEncoder(DomainLabelEncoder.Factory)
      .AddEncoder(DomainItemEncoder<DomainLabelModel>.Factory)
      .AddTypeEncoder(BaseDomainEncoder<DomainLabelModel>.Factory)
      .AddEncoder(DomainRangeEncoder.Factory)
      .AddEncoder(DomainItemEncoder<DomainRangeModel>.Factory)
      .AddTypeEncoder(BaseDomainEncoder<DomainRangeModel>.Factory)
      .AddEncoder(DomainRegexEncoder.Factory)
      .AddEncoder(DomainItemEncoder<DomainRegexModel>.Factory)
      .AddTypeEncoder(BaseDomainEncoder<DomainRegexModel>.Factory)
      .AddEncoder(DomainTrueFalseEncoder.Factory)
      .AddEncoder(DomainItemEncoder<DomainTrueFalseModel>.Factory)
      .AddTypeEncoder(BaseDomainEncoder<DomainTrueFalseModel>.Factory)
      // Enum
      .AddEncoder(EnumLabelEncoder.Factory)
      .AddTypeEncoder(TypeEnumEncoder.Factory)
      .AddEncoder(EnumValueEncoder.Factory)
      // Union
      .AddEncoder(UnionMemberEncoder.Factory)
      .AddTypeEncoder(TypeUnionEncoder.Factory)
      // Object
      .AddEncoder(ObjectBaseEncoder<ObjBaseModel>.Factory)
      .AddEncoder(TypeParamEncoder.Factory)
      .AddEncoder(ObjectAlternateEncoder.Factory)
      .AddEncoder(ObjectForEncoder<AlternateModel>.Factory)
      .AddEncoder<TypeArgModel>(TypeArgEncoder.Factory)
      // Dual
      .AddEncoder(DualFieldEncoder.Factory)
      .AddEncoder(ObjectForEncoder<DualFieldModel>.Factory)
      .AddTypeEncoder(TypeDualEncoder.Factory)
      // Input
      .AddEncoder(InputFieldEncoder.Factory)
      .AddEncoder(InputParamEncoder.Factory)
      .AddEncoder(ObjectForEncoder<InputFieldModel>.Factory)
      .AddTypeEncoder(TypeInputEncoder.Factory)
      // Output
      .AddEncoder(OutputEnumEncoder.Factory)
      .AddEncoder(OutputFieldEncoder.Factory)
      .AddEncoder(ObjectForEncoder<OutputFieldModel>.Factory)
      .AddTypeEncoder(TypeOutputEncoder.Factory);

  internal static IEncoderRepositoryBuilder AddTypeEncoder<TModel>(this IEncoderRepositoryBuilder builder, Factory<ITypeEncoder<TModel>, IEncoderRepository> factory)
    where TModel : IModelBase
    => builder.ThrowIfNull()
      .AddListEncoder<ITypeEncoder, ITypeEncoder<TModel>, TModel>(factory);
}
