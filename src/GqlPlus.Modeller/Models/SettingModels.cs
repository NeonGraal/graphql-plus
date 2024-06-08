namespace GqlPlus.Models;
public record class SettingModel(
  string Name,
  ConstantModel Value
) : DescribedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("value", Value.Render(context))
    ;
}
