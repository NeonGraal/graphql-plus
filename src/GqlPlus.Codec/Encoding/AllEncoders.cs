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
      .AddEncoder<ConstantModel>(r => new ConstantEncoder(r.EncoderFor<SimpleModel>()))
      .AddEncoder<SimpleModel>(_ => new SimpleEncoder())
      .AddEncoder<CollectionModel>(_ => new CollectionEncoder())
      .AddEncoder<ModifierModel>(_ => new ModifierEncoder())
      // Schema
      .AddEncoder<SchemaModel>(r => new SchemaEncoder(
        r.EncoderFor<CategoriesModel>(),
        r.EncoderFor<DirectivesModel>(),
        r.EncoderFor<BaseTypeModel>(),
        r.EncoderFor<SettingModel>()))
      .AddEncoder<CategoriesModel>(r => new CategoriesEncoder(
        new AndBaseTypeEncoders<CategoryModel>(r.EncoderFor<CategoryModel>(), r.EncoderFor<BaseTypeModel>())))
      .AddEncoder<CategoryModel>(r => new CategoryEncoder(
        r.EncoderFor<ModifierModel>(),
        r.EncoderFor<TypeRefModel<TypeKindModel>>()))
      .AddEncoder<DirectivesModel>(r => new DirectivesEncoder(
        new AndBaseTypeEncoders<DirectiveModel>(r.EncoderFor<DirectiveModel>(), r.EncoderFor<BaseTypeModel>())))
      .AddEncoder<DirectiveModel>(r => new DirectiveEncoder(r.EncoderFor<InputParamModel>()))
      .AddEncoder<SettingModel>(r => new SettingEncoder(r.EncoderFor<ConstantModel>()))
      // Types
      .AddEncoder<BaseTypeModel>(r => new AllTypesEncoder(r.TypeEncoders))
      .AddEncoder<DomainRefModel>(_ => new DomainRefEncoder())
      .AddEncoder<TypeRefModel<SimpleKindModel>>(_ => new TypeRefEncoder<TypeRefModel<SimpleKindModel>, SimpleKindModel>())
      .AddEncoder<TypeRefModel<TypeKindModel>>(_ => new TypeRefEncoder<TypeRefModel<TypeKindModel>, TypeKindModel>())
      .AddTypeEncoder<SpecialTypeModel>(_ => new SpecialTypeEncoder())
      // Domain
      .AddEncoder<DomainLabelModel>(r => new DomainLabelEncoder(r.EncoderFor<EnumValueModel>()))
      .AddEncoder<DomainItemModel<DomainLabelModel>>(r => new DomainItemEncoder<DomainLabelModel>(r.EncoderFor<DomainLabelModel>()))
      .AddTypeEncoder<BaseDomainModel<DomainLabelModel>>(r => new BaseDomainEncoder<DomainLabelModel>(
        new ParentTypeEncoders<DomainLabelModel, DomainItemModel<DomainLabelModel>>(
          r.EncoderFor<TypeRefModel<SimpleKindModel>>(),
          r.EncoderFor<DomainLabelModel>(),
          r.EncoderFor<DomainItemModel<DomainLabelModel>>())))
      .AddEncoder<DomainRangeModel>(_ => new DomainRangeEncoder())
      .AddEncoder<DomainItemModel<DomainRangeModel>>(r => new DomainItemEncoder<DomainRangeModel>(r.EncoderFor<DomainRangeModel>()))
      .AddTypeEncoder<BaseDomainModel<DomainRangeModel>>(r => new BaseDomainEncoder<DomainRangeModel>(
        new ParentTypeEncoders<DomainRangeModel, DomainItemModel<DomainRangeModel>>(
          r.EncoderFor<TypeRefModel<SimpleKindModel>>(),
          r.EncoderFor<DomainRangeModel>(),
          r.EncoderFor<DomainItemModel<DomainRangeModel>>())))
      .AddEncoder<DomainRegexModel>(_ => new DomainRegexEncoder())
      .AddEncoder<DomainItemModel<DomainRegexModel>>(r => new DomainItemEncoder<DomainRegexModel>(r.EncoderFor<DomainRegexModel>()))
      .AddTypeEncoder<BaseDomainModel<DomainRegexModel>>(r => new BaseDomainEncoder<DomainRegexModel>(
        new ParentTypeEncoders<DomainRegexModel, DomainItemModel<DomainRegexModel>>(
          r.EncoderFor<TypeRefModel<SimpleKindModel>>(),
          r.EncoderFor<DomainRegexModel>(),
          r.EncoderFor<DomainItemModel<DomainRegexModel>>())))
      .AddEncoder<DomainTrueFalseModel>(_ => new DomainTrueFalseEncoder())
      .AddEncoder<DomainItemModel<DomainTrueFalseModel>>(r => new DomainItemEncoder<DomainTrueFalseModel>(r.EncoderFor<DomainTrueFalseModel>()))
      .AddTypeEncoder<BaseDomainModel<DomainTrueFalseModel>>(r => new BaseDomainEncoder<DomainTrueFalseModel>(
        new ParentTypeEncoders<DomainTrueFalseModel, DomainItemModel<DomainTrueFalseModel>>(
          r.EncoderFor<TypeRefModel<SimpleKindModel>>(),
          r.EncoderFor<DomainTrueFalseModel>(),
          r.EncoderFor<DomainItemModel<DomainTrueFalseModel>>())))
      // Enum
      .AddEncoder<EnumLabelModel>(_ => new EnumLabelEncoder())
      .AddTypeEncoder<TypeEnumModel>(r => new TypeEnumEncoder(
        new ParentTypeEncoders<AliasedModel, EnumLabelModel>(
          r.EncoderFor<TypeRefModel<SimpleKindModel>>(),
          r.EncoderFor<AliasedModel>(),
          r.EncoderFor<EnumLabelModel>())))
      .AddEncoder<EnumValueModel>(_ => new EnumValueEncoder())
      // Union
      .AddEncoder<UnionMemberModel>(_ => new UnionMemberEncoder())
      .AddTypeEncoder<TypeUnionModel>(r => new TypeUnionEncoder(
        new ParentTypeEncoders<NamedModel, UnionMemberModel>(
          r.EncoderFor<TypeRefModel<SimpleKindModel>>(),
          r.EncoderFor<NamedModel>(),
          r.EncoderFor<UnionMemberModel>())))
      // Object
      .AddEncoder<ObjBaseModel>(r => new ObjectBaseEncoder<ObjBaseModel>(r.EncoderFor<TypeArgModel>()))
      .AddEncoder<TypeParamModel>(r => new TypeParamEncoder(r.EncoderFor<TypeRefModel<TypeKindModel>>()))
      .AddEncoder<AlternateModel>(r => new ObjectAlternateEncoder(
        new AlternateEncoders<ObjBaseModel>(r.EncoderFor<CollectionModel>(), r.EncoderFor<ObjBaseModel>())))
      .AddEncoder<ObjectForModel<AlternateModel>>(r => new ObjectForEncoder<AlternateModel>(r.EncoderFor<AlternateModel>()))
      .AddEncoder<TypeArgModel>(r => new TypeArgEncoder(r.EncoderFor<EnumValueModel>()))
      // Dual
      .AddEncoder<DualFieldModel>(r => new DualFieldEncoder(
        new FieldEncoders<ObjBaseModel>(r.EncoderFor<ModifierModel>(), r.EncoderFor<ObjBaseModel>())))
      .AddEncoder<ObjectForModel<DualFieldModel>>(r => new ObjectForEncoder<DualFieldModel>(r.EncoderFor<DualFieldModel>()))
      .AddTypeEncoder<TypeDualModel>(r => new TypeDualEncoder(
        new TypeObjectEncoders<DualFieldModel>(
          r.EncoderFor<ObjBaseModel>(),
          r.EncoderFor<DualFieldModel>(),
          r.EncoderFor<ObjectForModel<DualFieldModel>>(),
          r.EncoderFor<ObjectForModel<DualFieldModel>>(),
          r.EncoderFor<AlternateModel>(),
          r.EncoderFor<ObjectForModel<AlternateModel>>(),
          r.EncoderFor<ObjectForModel<AlternateModel>>(),
          r.EncoderFor<TypeParamModel>())))
      // Input
      .AddEncoder<InputFieldModel>(r => new InputFieldEncoder(
        r.EncoderFor<ConstantModel>(),
        new FieldEncoders<ObjBaseModel>(r.EncoderFor<ModifierModel>(), r.EncoderFor<ObjBaseModel>())))
      .AddEncoder<InputParamModel>(r => new InputParamEncoder(
        r.EncoderFor<TypeArgModel>(),
        r.EncoderFor<ModifierModel>(),
        r.EncoderFor<ConstantModel>()))
      .AddEncoder<ObjectForModel<InputFieldModel>>(r => new ObjectForEncoder<InputFieldModel>(r.EncoderFor<InputFieldModel>()))
      .AddTypeEncoder<TypeInputModel>(r => new TypeInputEncoder(
        new TypeObjectEncoders<InputFieldModel>(
          r.EncoderFor<ObjBaseModel>(),
          r.EncoderFor<InputFieldModel>(),
          r.EncoderFor<ObjectForModel<InputFieldModel>>(),
          r.EncoderFor<ObjectForModel<DualFieldModel>>(),
          r.EncoderFor<AlternateModel>(),
          r.EncoderFor<ObjectForModel<AlternateModel>>(),
          r.EncoderFor<ObjectForModel<AlternateModel>>(),
          r.EncoderFor<TypeParamModel>())))
      // Output
      .AddEncoder<OutputEnumModel>(_ => new OutputEnumEncoder())
      .AddEncoder<OutputFieldModel>(r => new OutputFieldEncoder(
        r.EncoderFor<OutputEnumModel>(),
        new FieldEncoders<ObjBaseModel>(r.EncoderFor<ModifierModel>(), r.EncoderFor<ObjBaseModel>()),
        r.EncoderFor<InputParamModel>()))
      .AddEncoder<ObjectForModel<OutputFieldModel>>(r => new ObjectForEncoder<OutputFieldModel>(r.EncoderFor<OutputFieldModel>()))
      .AddTypeEncoder<TypeOutputModel>(r => new TypeOutputEncoder(
        new TypeObjectEncoders<OutputFieldModel>(
          r.EncoderFor<ObjBaseModel>(),
          r.EncoderFor<OutputFieldModel>(),
          r.EncoderFor<ObjectForModel<OutputFieldModel>>(),
          r.EncoderFor<ObjectForModel<DualFieldModel>>(),
          r.EncoderFor<AlternateModel>(),
          r.EncoderFor<ObjectForModel<AlternateModel>>(),
          r.EncoderFor<ObjectForModel<AlternateModel>>(),
          r.EncoderFor<TypeParamModel>())));
}
