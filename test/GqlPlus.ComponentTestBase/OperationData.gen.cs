// Generated from .\test\GqlPlus.ComponentTestBase\Samples\Operation
// Collected from 5e5c83d  (HEAD -> union-tests, origin/yaml, origin/main, origin/json, origin/include, origin/HEAD, main) 2024-09-24 Merge pull request #3 from graphql-plus/samples


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
