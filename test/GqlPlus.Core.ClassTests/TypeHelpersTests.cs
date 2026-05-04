namespace GqlPlus;

public class TypeHelpersTests
{
  [Theory, ClassData<ExpandTypeNameData>]
  public void ExpandTypeName_ReturnsCorrect(Type input, string expected)
  {
    string result = input.ExpandTypeName();
    result.ShouldBe(expected);
  }
}

public class ExpandTypeNameData
  : TheoryData<Type, string>
{
  public ExpandTypeNameData()
  {
    Add(typeof(int), "Int32");
    Add(typeof(List<string>), "List<String>");
    Add(typeof(Dictionary<string, List<int>>), "Dictionary<String,List<Int32>>");
    Add(typeof(Nullable<int>), "Nullable<Int32>");
  }
}
