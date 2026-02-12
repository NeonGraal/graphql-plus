//HintName: test_Schema_Impl.gen.cs
// Generated from Schema.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public class test_Opt<TT>
  : Itest_Opt<TT>
{
  public TT AsT { get; set; }
  public testNull AsNull { get; set; }
  public Itest_OptObject<TT> As_Opt { get; set; }
}

public class test_List<TT>
  : Itest_List<TT>
{
  public ICollection<TT> AsT { get; set; }
  public Itest_ListObject<TT> As_List { get; set; }
}

public class test_Dict<TK,TT>
  : Itest_Dict<TK,TT>
{
  public IDictionary<TK, TT> AsT { get; set; }
  public Itest_DictObject<TK,TT> As_Dict { get; set; }
}

public class test_Map<TT>
  : Itest_Map<TT>
{
  public IDictionary<string, TT> AsT { get; set; }
  public Itest_MapObject<TT> As_Map { get; set; }
}

public class test_Array<TT>
  : Itest_Array<TT>
{
  public IDictionary<decimal, TT> AsT { get; set; }
  public Itest_ArrayObject<TT> As_Array { get; set; }
}

public class test_IfElse<TT>
  : Itest_IfElse<TT>
{
  public IDictionary<bool, TT> AsT { get; set; }
  public Itest_IfElseObject<TT> As_IfElse { get; set; }
}

public class test_Set<TK>
  : Itest_Set<TK>
{
  public IDictionary<TK, testUnit> AsUnit_ { get; set; }
  public Itest_SetObject<TK> As_Set { get; set; }
}

public class test_Mask<TK>
  : Itest_Mask<TK>
{
  public IDictionary<TK, bool> AsBoolean { get; set; }
  public Itest_MaskObject<TK> As_Mask { get; set; }
}

public class test_Key
  : Itest_Key
{
}

public class test_Any
  : Itest_Any
{
  public Itest_AnyObject As_Any { get; set; }
}
