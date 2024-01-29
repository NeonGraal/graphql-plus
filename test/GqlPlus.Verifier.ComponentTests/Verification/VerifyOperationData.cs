
// Generated from .\test\GqlPlus.Verifier.ComponentTests\Verification\Operation

namespace GqlPlus.Verifier.Verification;

public partial class VerifyOperationTests
{
  private static Dictionary<string, string> s_operationInvalid = new() {
    ["empty"] = "",
    ["var-unused"] = "($var):Boolean",
    ["var-undef"] = ":Boolean($var)",
    ["null-def-invalid"] = "($var:Id=null):Boolean($var)",
    ["list-map-def"] = "($var:Id[]={a:b}):Boolean($var)",
    ["map-list-def"] = "($var:Id[*]=[a]):Boolean($var)",
    ["list-null-map-def"] = "($var:Id[]?={a:b}):Boolean($var)",
    ["map-null-list-def"] = "($var:Id[*]?=[a]):Boolean($var)",
    ["frag-unused"] = "&named:Named{name}{name}",
    ["frag-undef"] = "{...named}",
  };

  public class OperationInvalid : TheoryData<string>
  {
    public OperationInvalid()
    {
      Add("empty");
      Add("var-unused");
      Add("var-undef");
      Add("null-def-invalid");
      Add("list-map-def");
      Add("map-list-def");
      Add("list-null-map-def");
      Add("map-null-list-def");
      Add("frag-unused");
      Add("frag-undef");
    }
  }
  private static Dictionary<string, string> s_operationValid = new() {
    ["var"] = "($var):Boolean($var)",
    ["var-null"] = "($var:Id?=null):Boolean($var)",
    ["frag-first"] = "&named:Named{name}{|named}",
    ["frag-end"] = "{...named}fragment named on Named{name}",
  };

  public class OperationValid : TheoryData<string>
  {
    public OperationValid()
    {
      Add("var");
      Add("var-null");
      Add("frag-first");
      Add("frag-end");
    }
  }
}
