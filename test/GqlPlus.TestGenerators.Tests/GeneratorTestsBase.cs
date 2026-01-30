using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GqlPlus;

public class GeneratorTestsBase
{
  private readonly VerifySettings _settings = new VerifySettings().CheckAutoVerify();

  protected Task AttachAndVerify([NotNull] GeneratorDriver driver)
  {
    GeneratorDriverRunResult runResult = driver.GetRunResult();

    IEnumerable<GeneratedText> results = runResult.Results
      .SelectMany(r => r.GeneratedSources
        .Select(t => new GeneratedText(t.HintName, t.SourceText)));

    foreach (GeneratedText result in results) {
      TestContext.Current.AddAttachment(result.Name, result.Text.ToString());
    }

    return Verify(driver, _settings);
  }

  private record struct GeneratedText(string Name, SourceText Text);
}
