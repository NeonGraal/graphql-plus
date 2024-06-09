using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Rendering;

public static class AllRenderers
{
  public static IServiceCollection AddRenderers(this IServiceCollection services)
  => services
      // Common
      .AddRenderer<ConstantModel, ConstantRenderer>()
      .AddRenderer<SimpleModel, SimpleRenderer>()
      .AddRenderer<CollectionModel, CollectionRenderer>()
      .AddRenderer<ModifierModel, ModifierRenderer>()
      // Globals
      .AddRenderer<CategoryModel, CategoryRenderer>()
      .AddRenderer<DirectiveModel, DirectiveRenderer>()
      .AddRenderer<SettingModel, SettingRenderer>()
    ;

  private static IServiceCollection AddRenderer<TModel, TRenderer>(this IServiceCollection services)
    where TRenderer : class, IRendering<TModel>
    => services.AddSingleton<IRendering<TModel>, TRenderer>();
}
