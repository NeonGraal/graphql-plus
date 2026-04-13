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
      .AddEncoder<SchemaModel>(r => new SchemaEncoder(r))
      .AddEncoder<CategoriesModel>(r => new CategoriesEncoder(r))
      .AddEncoder<CategoryModel>(r => new CategoryEncoder(r))
      .AddEncoder<DirectivesModel>(r => new DirectivesEncoder(r))
      .AddEncoder<DirectiveModel>(r => new DirectiveEncoder(r))
      .AddEncoder<SettingModel>(r => new SettingEncoder(r))
      // Operation
      .AddEncoder<OperationsModel>(r => new OperationsEncoder(r))
      .AddEncoder<OperationModel>(r => new OperationEncoder(r))
      // .AddSingleton<AndBaseTypeEncoders<OperationModel>>()
      .AddEncoder<OpDirectiveModel>(r => new OpDirectiveEncoder())
      .AddEncoder<OpFragmentModel>(r => new OpFragmentEncoder())
      .AddEncoder<OpResultModel>(r => new OpResultEncoder())
      .AddEncoder<OpSelectionModel>(r => new OpSelectionEncoder())
      // .AddEncoder<OpSelectionModel[]>(r => new OpSelectionsEncoder())
      .AddEncoder<OpVariableModel>(r => new OpVariableEncoder())
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
