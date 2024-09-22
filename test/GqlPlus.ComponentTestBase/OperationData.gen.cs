// Generated from .\test\GqlPlus.ComponentTestBase\Samples\Operation
// Collected from 9328e1e  (HEAD -> samples, origin/samples) 2024-09-22 Split schema errors into parse and verify


namespace GqlPlus;

public class OperationInvalidData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "empty",
    "frag-undef",
    "frag-unused",
    "list-map-def",
    "list-null-map-def",
    "map-list-def",
    "map-null-list-def",
    "null-def-invalid",
    "var-undef",
    "var-unused",
  ];

  public OperationInvalidData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}

public class OperationValidData
  : TheoryData<string>
{
  public static readonly string[] Keys = [
    "frag-end",
    "frag-first",
    "var",
    "var-null",
  ];

  public OperationValidData()
  {
    foreach (string key in Keys) {
      Add(key);
    }
  }
}
