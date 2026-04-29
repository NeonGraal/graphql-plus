using GqlPlus.Ast.Schema;

namespace GqlPlus;

public static class BuiltInData
{
  public static Map<IAstType> BasicMap { get; }
      = BuiltIn.Basic.ToMap(m => m.Name);

  public static Map<IAstType> InternalMap { get; }
      = BuiltIn.Internal.ToMap(m => m.Name);
}

public class BuiltInBasicData()
  : TheoryData<string>(BuiltInData.BasicMap.Keys)
{ }

public class BuiltInInternalData()
  : TheoryData<string>(BuiltInData.InternalMap.Keys)
{ }
