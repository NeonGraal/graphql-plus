// Generated from .\test\GqlPlus.ComponentTestBase\Operation

namespace GqlPlus;

public class OperationInvalidData
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

  public OperationInvalidData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}

public class OperationValidData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["frag-end"] = "{...named}fragment named on Named{name}",
    ["frag-first"] = "&named:Named{name}{|named}",
    ["var"] = "($var):Boolean($var)",
    ["var-null"] = "($var:Id?=null):Boolean($var)",
  };

  public OperationValidData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}
