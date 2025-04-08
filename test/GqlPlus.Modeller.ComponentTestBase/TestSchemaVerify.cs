using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Resolving;
using Shouldly;

namespace GqlPlus;

public abstract class TestSchemaVerify(
    ISchemaVerifyChecks checks
) : SampleChecks
{
  [Fact]
  public async Task Verify_All()
    => await Verify_Model(await SchemaValidDataAll(), "!ALL", "");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Verify_Groups(string group)
    => await Verify_Model(await SchemaValidDataGroup(group), "!" + group, "");

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Verify_Merges(string model)
    => await ReplaceFileAsync("Merges", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Verify_Objects(string model)
    => await ReplaceFileAsync("Objects", model, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Verify_Globals(string global)
    => await ReplaceFileAsync("Globals", global, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Verify_Simple(string simple)
    => await ReplaceFileAsync("Simple", simple, Verify_Model);

  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task Verify_Schema(string sample)
  {
    IGqlpSchema ast = await checks.ParseSample("Schema", sample);

    (Structured result, ITypesContext context) = checks.Verify_Asts([ast]);

    await CheckResultErrors("Schema", "", sample, context.Errors);

    await VerifyResult(result, "Schema", sample, "");
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task Verify_Spec(string sample)
  {
    IGqlpSchema ast = await checks.ParseSample("Spec", sample, "Specification");

    (Structured result, ITypesContext context) = checks.Verify_Asts([ast]);

    await CheckResultErrors("Schema", "Specification", sample, context.Errors);

    await VerifyResult(result, "Spec", sample, "");
  }

  private async Task Verify_Model(string input, string testDirectory, string test)
      => await Verify_Model([input], test, testDirectory);

  private async Task Verify_Model(IEnumerable<string> inputs, string test, string testDirectory)
  {
    IEnumerable<IGqlpSchema> asts = inputs.Select(input => checks.ParseInput(input, "Sample"));

    (Structured result, ITypesContext context) = checks.Verify_Asts(asts);

    await VerifyResult(result, "Sample", test, testDirectory);

    context.Errors.ShouldBeEmpty(test);
  }

  protected abstract Task VerifyResult(Structured result, string label, string test, string testDirectory);

  protected virtual Task CheckResultErrors(string category, string directory, string file, ITokenMessages errors, bool includeVerify = false)
    => Task.CompletedTask; // No errors expected
}
