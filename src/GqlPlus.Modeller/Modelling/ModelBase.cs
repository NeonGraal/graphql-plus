﻿using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public abstract record class ModelBase
  : IRendering
{
  private string? _tag;

  protected virtual string Tag => _tag ??= GetType().TypeTag();

  internal virtual RenderStructure Render(IRenderContext context)
    => RenderStructure.New(Tag);

#pragma warning disable CA1033 // Interface methods should be callable by child types
  RenderStructure IRendering.Render(IRenderContext context)
    => Render(context);
}
