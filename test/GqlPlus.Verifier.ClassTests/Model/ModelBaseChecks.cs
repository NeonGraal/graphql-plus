namespace GqlPlus.Verifier.Model;

internal abstract class ModelBaseChecks<TModel>
  where TModel : IRendering
{
  protected static void Model_Expected(TModel model, string expected)
  {
    var render = model.Render();

    render.ToYaml().Should().Be(expected);
  }

  internal string YamlQuoted(string input)
    => $"'{input.Replace("'", "''")}'";
}
