using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus;

public static class BuiltInData
{
  public static Map<IGqlpType> BasicMap { get; }
      = BuiltIn.Basic.ToMap(m => m.Name);

  public static Map<IGqlpType> InternalMap { get; }
      = BuiltIn.Internal.ToMap(m => m.Name);
}

public class BuiltInBasicData
  : TheoryData<string>
{
  public BuiltInBasicData()
  {
    foreach (string key in BuiltInData.BasicMap.Keys) {
      Add(key);
    }
  }
}

public class BuiltInInternalData
  : TheoryData<string>
{
  public BuiltInInternalData()
  {
    foreach (string key in BuiltInData.InternalMap.Keys) {
      Add(key);
    }
  }
}
