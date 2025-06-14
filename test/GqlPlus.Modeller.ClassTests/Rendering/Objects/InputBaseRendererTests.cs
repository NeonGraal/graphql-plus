﻿namespace GqlPlus.Rendering.Objects;

public class InputBaseRendererTests
  : ObjectArgRendererBase<InputBaseModel, InputArgModel>
{
  private readonly IRenderer<DualBaseModel> _dual;

  public InputBaseRendererTests()
  {
    _dual = RFor<DualBaseModel>();

    Renderer = new InputBaseRenderer(ObjArg, _dual);
  }

  protected override IRenderer<InputBaseModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string input, string contents)
    => RenderAndCheck(new(input, contents) { IsTypeParam = true }, [
      "!_InputBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + input
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithInput(string input, string contents)
    => RenderAndCheck(new(input, contents), [
      "!_InputBase",
      "description: " + contents.Quoted("'"),
      "input: " + input
      ]);

  [Theory, RepeatData]
  public void Render_WithArg_ReturnsStructuredWithInput(string input, string argType)
  {
    InputArgModel argModel = new(argType, "");
    InputBaseModel model = new(input, "") { Args = [argModel] };

    RenderReturnsMap(ObjArg, "_InputArg", argType);

    RenderAndCheck(model, [
      "!_InputBase",
      "input: " + input,
      "typeArgs:", "  -", $"    value: !_InputArg '{argType}'"
      ]);
  }

  [Theory, RepeatData]
  public void Render_WithDual_ReturnsStructuredWithInput(string input)
  {
    InputBaseModel model = new("", "") { Dual = new DualBaseModel(input, "") };

    RenderReturnsMap(_dual, "_DualBase", input);

    RenderAndCheck(model, [$"value: !_DualBase '{input}'"]);
  }
}
