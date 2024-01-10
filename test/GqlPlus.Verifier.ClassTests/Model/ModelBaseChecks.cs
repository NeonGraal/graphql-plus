namespace GqlPlus.Verifier.Model;

internal abstract class ModelBaseChecks : IModelBaseChecks
{
  internal static void Model_Expected(IRendering model, string[] expected)
  {
    var render = model.Render().ToYaml();

    render.ToLines().Should().BeEquivalentTo(expected);
  }

  internal static string YamlQuoted(string input)
    => $"'{input.Replace("'", "''")}'";

  void IModelBaseChecks.Model_Expected(IRendering model, string[] expected) => Model_Expected(model, expected);
  string IModelBaseChecks.YamlQuoted(string input) => YamlQuoted(input);
}

internal interface IModelBaseChecks
{
  void Model_Expected(IRendering model, string[] expected);
  string YamlQuoted(string input);
}
