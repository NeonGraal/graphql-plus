// Generated from .\test\GqlPlus.ComponentTestBase\Samples\Operation
// Collected from 19141aa  (HEAD -> category-dup) 2025-03-06 Correct various verify errors

namespace GqlPlus;

public class OperationInvalidData
  : TheoryData<string>
{
  public OperationInvalidData()
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

public class OperationValidData
  : TheoryData<string>
{
  public OperationValidData()
  {
    Add("frag-end");
    Add("frag-first");
    Add("var");
    Add("var-null");
  }
}
