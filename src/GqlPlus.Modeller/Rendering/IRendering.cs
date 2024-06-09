﻿using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Rendering;

public interface IRendering
{
  RenderStructure Render(IRenderContext context);
}

public interface IRenderer<TModel>
{
  RenderStructure Render(TModel model, IRenderContext context);
}

public interface IRenderContext
{
  bool TryGetType<TModel>(string context, string? name, [NotNullWhen(true)] out TModel? model)
    where TModel : IRendering;
}
