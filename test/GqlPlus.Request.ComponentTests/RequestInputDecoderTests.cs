using GqlPlus.Decoding;

namespace GqlPlus.Request;

public class RequestInputDecoderTests(
    ComponentFixture<RequestTestServices> fixture
) : TestRequestInputs
  , IClassFixture<ComponentFixture<RequestTestServices>>
{
  private readonly IRequestInputDecoder _decoder = fixture.GetService<IRequestInputDecoder>();

  protected override async Task Label_Input(string label, string input, string[] dirs, string test, string section = "")
  {
    DecodedRequest decoded = _decoder.Decode(input);

    string? operationShow = decoded.ParsedOperation?.Show();
    List<string> lines = [];

    if (decoded.Category is not null) {
      lines.Add($"Category: {decoded.Category}");
    }

    if (decoded.Operation is not null) {
      lines.Add($"Operation: {decoded.Operation}");
    }

    if (!decoded.Parameters.IsEmpty) {
      lines.Add($"Parameters: {decoded.Parameters}");
    }

    if (!string.IsNullOrWhiteSpace(operationShow)) {
      lines.Add("ParsedOperation:");
      lines.Add(operationShow.TrimEnd());
    }

    if (decoded.Errors.Count > 0) {
      lines.Add("Errors:");
      lines.AddRange(decoded.Errors.Select(e => $"  {e.Message}"));
    }

    string target = string.Join(Environment.NewLine, lines);
    await target.AttachAndVerify(label + " " + test, CustomSettings(label, "", test, section));
  }
}
