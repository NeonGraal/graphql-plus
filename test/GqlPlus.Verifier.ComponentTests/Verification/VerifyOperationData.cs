
// Generated from .\test\GqlPlus.Verifier.ComponentTests\Verification\Operation

namespace GqlPlus.Verifier.Verification;

public class VerifyOperationInvalidData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["empty"] = "",
    ["frag-undef"] = "{...named}",
    ["frag-unused"] = "&named:Named{name}{name}",
    ["list-map-def"] = "($var:Id[]={a:b}):Boolean($var)",
    ["list-null-map-def"] = "($var:Id[]?={a:b}):Boolean($var)",
    ["map-list-def"] = "($var:Id[*]=[a]):Boolean($var)",
    ["map-null-list-def"] = "($var:Id[*]?=[a]):Boolean($var)",
    ["null-def-invalid"] = "($var:Id=null):Boolean($var)",
    ["var-undef"] = ":Boolean($var)",
    ["var-unused"] = "($var):Boolean",
  };

  public VerifyOperationInvalidData()
  {
    Add("empty");
    Add("frag-undef");
    Add("frag-unused");
    Add("list-map-def");
    Add("list-null-map-def");
    Add("map-list-def");
    Add("map-null-list-def");
    Add("null-def-invalid");
    Add("var-undef");
    Add("var-unused");
  }
}

public class VerifyOperationValidData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["frag-end"] = "{...named}fragment named on Named{name}",
    ["frag-first"] = "&named:Named{name}{|named}",
    ["var"] = "($var):Boolean($var)",
    ["var-null"] = "($var:Id?=null):Boolean($var)",
  };

  public VerifyOperationValidData()
  {
    Add("frag-end");
    Add("frag-first");
    Add("var");
    Add("var-null");
  }
}
