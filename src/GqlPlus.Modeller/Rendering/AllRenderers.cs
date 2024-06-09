using GqlPlus.Modelling.Globals;
using GqlPlus.Modelling.Objects;
using GqlPlus.Modelling.Simple;
using GqlPlus.Modelling;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Rendering;

public static class AllRenderers
{
  public static IServiceCollection AddRenderers(this IServiceCollection services)
  => services
      // Common
      //.AddRenderer<ConstantModel, ConstantRenderer>()
      //.AddRenderer<SimpleModel, SimpleRenderer>()
      //.AddRenderer<CollectionModel, CollectionRenderer>()
      //.AddRenderer<ModifierModel, ModifierRenderer>()
      //// Globals
      //.AddRenderer<CategoryModel, CategoryRenderer>()
      //.AddRenderer<DirectiveModel, DirectiveRenderer>()
      //.AddRenderer<SettingModel, SettingRenderer>()
      //// Simple
      //.AddRenderer<TypeUnionModel, TypeUnionRenderer>()
      //.AddRenderer<UnionMemberModel, UnionMemberRenderer>()

      // Default Renderers
      .AddDefaultRenderer<ConstantModel>()
      .AddDefaultRenderer<SimpleModel>()
      .AddDefaultRenderer<ModifierModel>()
      .AddDefaultRenderer<CollectionModel>()
      // Schema
      .AddDefaultRenderer<SchemaModel>()
      .AddDefaultRenderer<CategoriesModel>()
      .AddDefaultRenderer<CategoryModel>()
      .AddDefaultRenderer<DirectiveModel>()
      .AddDefaultRenderer<DirectivesModel>()
      .AddDefaultRenderer<SettingModel>()
      // Types
      .AddDefaultRenderer<SpecialTypeModel>()
      // Simple
      .AddDefaultRenderer<BaseDomainModel<DomainMemberModel>>()
      .AddDefaultRenderer<BaseDomainModel<DomainRangeModel>>()
      .AddDefaultRenderer<BaseDomainModel<DomainRegexModel>>()
      .AddDefaultRenderer<BaseDomainModel<DomainTrueFalseModel>>()
      .AddDefaultRenderer<DomainMemberModel>()
      .AddDefaultRenderer<DomainRangeModel>()
      .AddDefaultRenderer<DomainRegexModel>()
      .AddDefaultRenderer<DomainTrueFalseModel>()
      .AddDefaultRenderer<TypeEnumModel>()
      .AddDefaultRenderer<TypeUnionModel>()
      // Object
      .AddDefaultRenderer<DualBaseModel>()
      .AddDefaultRenderer<InputBaseModel>()
      .AddDefaultRenderer<OutputBaseModel>()
      .AddDefaultRenderer<DualBaseModel>()
      .AddDefaultRenderer<DualFieldModel>()
      .AddDefaultRenderer<InputBaseModel>()
      .AddDefaultRenderer<InputFieldModel>()
      .AddDefaultRenderer<InputParameterModel>()
      .AddDefaultRenderer<OutputBaseModel>()
      .AddDefaultRenderer<OutputFieldModel>()
      .AddDefaultRenderer<TypeDualModel>()
      .AddDefaultRenderer<TypeInputModel>()
      .AddDefaultRenderer<TypeOutputModel>()
    ;

  private static IServiceCollection AddRenderer<TModel, TRenderer>(this IServiceCollection services)
    where TRenderer : class, IRenderer<TModel>
    => services.AddSingleton<IRenderer<TModel>, TRenderer>();

  private static IServiceCollection AddDefaultRenderer<TModel>(this IServiceCollection services)
    where TModel : IRendering
    => services.AddSingleton<IRenderer<TModel>, DefaultRenderer<TModel>>();
}
