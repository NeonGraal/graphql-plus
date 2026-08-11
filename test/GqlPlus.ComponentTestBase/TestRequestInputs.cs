namespace GqlPlus;

public abstract class TestRequestInputs
  : SampleChecks
{
  [Theory]
  [ClassData(typeof(SamplesRequestData))]
  public async Task Test_Request(string sample)
  {
    string request = await ReadRequest(sample);

    await Label_Input("Request", request, ["Request"], sample);
  }

  protected abstract Task Label_Input(string label, string input, string[] dirs, string test, string section = "");

  protected virtual async Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    string request = inputs.Joined(Environment.NewLine);

    await Label_Input(label, request, [label], test);
  }

  protected virtual Task Sample_Input(string input, string section, string test)
    => Label_Input("Sample", input, [section], test, section);
}
