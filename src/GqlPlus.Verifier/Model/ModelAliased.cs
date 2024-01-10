namespace GqlPlus.Verifier.Model;

public abstract record class ModelAliased(string Name)
  : ModelNamed(Name)
{
  public string[] Aliases { get; set; } = [];

  public override RenderValue Render()
    => base.Render()
      .Add("aliases", Aliases.Render());
}
