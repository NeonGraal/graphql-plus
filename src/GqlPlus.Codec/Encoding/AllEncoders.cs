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
      .AddEncoder(_ => new AliasedEncoder<AliasedModel>())
      .AddEncoder(_ => new DescribedEncoder<DescribedModel>())
      .AddEncoder(_ => new NamedEncoder<NamedModel>())
      .AddEncoder(r => new ConstantEncoder(r))
      .AddEncoder(_ => new SimpleEncoder())
      .AddEncoder(_ => new CollectionEncoder())
      .AddEncoder<ModifierModel>(_ => new ModifierEncoder())
      // Schema
      .AddEncoder(r => new SchemaEncoder(r))
      .AddEncoder(r => new CategoriesEncoder(r))
      .AddEncoder(r => new CategoryEncoder(r))
      .AddEncoder(r => new DirectivesEncoder(r))
      .AddEncoder(r => new DirectiveEncoder(r))
      .AddEncoder(r => new SettingEncoder(r))
      // Types
      .AddEncoder(r => new AllTypesEncoder(r))
      .AddEncoder(_ => new DomainRefEncoder())
      .AddEncoder(_ => new TypeRefEncoder<TypeRefModel<SimpleKindModel>, SimpleKindModel>())
      .AddEncoder(_ => new TypeRefEncoder<TypeRefModel<TypeKindModel>, TypeKindModel>())
      .AddTypeEncoder(_ => new SpecialTypeEncoder())
      // Domain
      .AddEncoder(r => new DomainLabelEncoder(r))
      .AddEncoder(r => new DomainItemEncoder<DomainLabelModel>(r))
      .AddTypeEncoder(r => new BaseDomainEncoder<DomainLabelModel>(r))
      .AddEncoder(_ => new DomainRangeEncoder())
      .AddEncoder(r => new DomainItemEncoder<DomainRangeModel>(r))
      .AddTypeEncoder(r => new BaseDomainEncoder<DomainRangeModel>(r))
      .AddEncoder(_ => new DomainRegexEncoder())
      .AddEncoder(r => new DomainItemEncoder<DomainRegexModel>(r))
      .AddTypeEncoder(r => new BaseDomainEncoder<DomainRegexModel>(r))
      .AddEncoder(_ => new DomainTrueFalseEncoder())
      .AddEncoder(r => new DomainItemEncoder<DomainTrueFalseModel>(r))
      .AddTypeEncoder(r => new BaseDomainEncoder<DomainTrueFalseModel>(r))
      // Enum
      .AddEncoder(_ => new EnumLabelEncoder())
      .AddTypeEncoder(r => new TypeEnumEncoder(r))
      .AddEncoder(_ => new EnumValueEncoder())
      // Union
      .AddEncoder(_ => new UnionMemberEncoder())
      .AddTypeEncoder(r => new TypeUnionEncoder(r))
      // Object
      .AddEncoder(r => new ObjectBaseEncoder<ObjBaseModel>(r))
      .AddEncoder(r => new TypeParamEncoder(r))
      .AddEncoder(r => new ObjectAlternateEncoder(r))
      .AddEncoder(r => new ObjectForEncoder<AlternateModel>(r))
      .AddEncoder<TypeArgModel>(r => new TypeArgEncoder(r))
      // Dual
      .AddEncoder(r => new DualFieldEncoder(r))
      .AddEncoder(r => new ObjectForEncoder<DualFieldModel>(r))
      .AddTypeEncoder(r => new TypeDualEncoder(r))
      // Input
      .AddEncoder(r => new InputFieldEncoder(r))
      .AddEncoder(r => new InputParamEncoder(r))
      .AddEncoder(r => new ObjectForEncoder<InputFieldModel>(r))
      .AddTypeEncoder(r => new TypeInputEncoder(r))
      // Output
      .AddEncoder(r => new OutputEnumEncoder())
      .AddEncoder(r => new OutputFieldEncoder(r))
      .AddEncoder(r => new ObjectForEncoder<OutputFieldModel>(r))
      .AddTypeEncoder(r => new TypeOutputEncoder(r));

  internal static IEncoderRepositoryBuilder AddTypeEncoder<TModel>(this IEncoderRepositoryBuilder builder, Factory<ITypeEncoder<TModel>, IEncoderRepository> factory)
    where TModel : IModelBase
    => builder.ThrowIfNull()
      .AddListEncoder<ITypeEncoder, ITypeEncoder<TModel>, TModel>(factory);
}
