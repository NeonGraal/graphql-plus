using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Encoding;

public static class AllEncoders
{
  public static IServiceCollection AddEncoders(this IServiceCollection services, Action<IEncoderRepositoryBuilder> config)
    => services
      .AddSingleton(new EncoderRepositoryBuilder().FluentInterface(config))
      .AddSingleton<IEncoderRepository, EncoderRepository>();

  internal static IEncoderRepositoryBuilder AddSchemaEncoders(this IEncoderRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .CommonEncoders()
      .SchemaEncoders()
      .OperationEncoders()
      .TypesEncoders()
      .SimpleEncoders()
      .ObjectEncoders()
      .DualEncoders()
      .InputEncoders()
      .OutputEncoders();

  internal static IEncoderRepositoryBuilder AddTypeEncoder<TModel>(this IEncoderRepositoryBuilder builder, Factory<ITypeEncoder<TModel>, IEncoderRepository> factory)
    where TModel : IModelBase
    => builder.ThrowIfNull()
      .AddListEncoder<ITypeEncoder, ITypeEncoder<TModel>, TModel>(factory);

  private static IEncoderRepositoryBuilder CommonEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(AliasedEncoder<AliasedModel>.FactoryAliased)
      .AddEncoder(DescribedEncoder<DescribedModel>.FactoryDescribed)
      .AddEncoder(NamedEncoder<NamedModel>.FactoryNamed)
      .AddEncoder(ConstantEncoder.Factory)
      .AddEncoder(SimpleEncoder.Factory)
      .AddEncoder(CollectionEncoder.Factory)
      .AddEncoder<ModifierModel>(ModifierEncoder.Factory);

  private static IEncoderRepositoryBuilder SchemaEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(SchemaEncoder.Factory)
      .AddEncoder(CategoriesEncoder.Factory)
      .AddEncoder(CategoryEncoder.Factory)
      .AddEncoder(DirectivesEncoder.Factory)
      .AddEncoder(DirectiveEncoder.Factory)
      .AddEncoder(SettingEncoder.Factory);

  private static IEncoderRepositoryBuilder OperationEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(OperationsEncoder.Factory)
      .AddEncoder(OperationEncoder.Factory)
      // .AddSingleton<AndBaseTypeEncoders<OperationModel>>()
      .AddEncoder(OpDirectiveEncoder.Factory)
      .AddEncoder(OpFragmentEncoder.Factory)
      .AddEncoder(OpResultEncoder.Factory)
      .AddEncoder(OpSelectionEncoder.Factory)
      // .AddEncoder(OpSelectionsEncoder.Factory)
      .AddEncoder(OpVariableEncoder.Factory);

  private static IEncoderRepositoryBuilder TypesEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(AllTypesEncoder.Factory)
      .AddEncoder(DomainRefEncoder.Factory)
      .AddEncoder(TypeRefEncoder<TypeRefModel<SimpleKindModel>, SimpleKindModel>.Factory)
      .AddEncoder(TypeRefEncoder<TypeRefModel<TypeKindModel>, TypeKindModel>.Factory)
      .AddTypeEncoder(SpecialTypeEncoder.Factory);

  private static IEncoderRepositoryBuilder SimpleEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .DomainEncoders()
      // Enum
      .AddEncoder(EnumLabelEncoder.Factory)
      .AddTypeEncoder(TypeEnumEncoder.Factory)
      .AddEncoder(EnumValueEncoder.Factory)
      // Union
      .AddEncoder(UnionMemberEncoder.Factory)
      .AddTypeEncoder(TypeUnionEncoder.Factory);

  private static IEncoderRepositoryBuilder DomainEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(DomainLabelEncoder.Factory)
      .DomainEncoders<DomainLabelModel>()
      .AddEncoder(DomainRangeEncoder.Factory)
      .DomainEncoders<DomainRangeModel>()
      .AddEncoder(DomainRegexEncoder.Factory)
      .DomainEncoders<DomainRegexModel>()
      .AddEncoder(DomainTrueFalseEncoder.Factory)
      .DomainEncoders<DomainTrueFalseModel>();

  private static IEncoderRepositoryBuilder DomainEncoders<TItem>(this IEncoderRepositoryBuilder builder)
    where TItem : BaseDomainItemModel
    => builder
      .AddEncoder(DomainItemEncoder<TItem>.Factory)
      .AddTypeEncoder(BaseDomainEncoder<TItem>.Factory);

  private static IEncoderRepositoryBuilder ObjectEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(ObjectBaseEncoder<ObjBaseModel>.Factory)
      .AddEncoder(TypeParamEncoder.Factory)
      .AddEncoder(ObjectAlternateEncoder.Factory)
      .AddEncoder(ObjectForEncoder<AlternateModel>.Factory)
      .AddEncoder(TypeArgEncoder.Factory);

  private static IEncoderRepositoryBuilder DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(DualFieldEncoder.Factory)
      .AddEncoder(ObjectForEncoder<DualFieldModel>.Factory)
      .AddTypeEncoder(TypeDualEncoder.Factory);

  private static IEncoderRepositoryBuilder InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(InputFieldEncoder.Factory)
      .AddEncoder(InputParamEncoder.Factory)
      .AddEncoder(ObjectForEncoder<InputFieldModel>.Factory)
      .AddTypeEncoder(TypeInputEncoder.Factory);

  private static IEncoderRepositoryBuilder OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder(OutputEnumEncoder.Factory)
      .AddEncoder(OutputFieldEncoder.Factory)
      .AddEncoder(ObjectForEncoder<OutputFieldModel>.Factory)
      .AddTypeEncoder(TypeOutputEncoder.Factory);
}
