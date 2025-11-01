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
  public test_Opt _Opt { get; set; }
}

public class test_List<TT>
  : Itest_List<TT>
{
  public ICollection<TT> AsT { get; set; }
  public test_List _List { get; set; }
}

public class test_Dict<TK,TT>
  : Itest_Dict<TK,TT>
{
  public IDictionary<TK, TT> AsT { get; set; }
  public test_Dict _Dict { get; set; }
}

public class test_Map<TT>
  : Itest_Map<TT>
{
  public IDictionary<testString, TT> AsT { get; set; }
  public test_Map _Map { get; set; }
}

public class test_Array<TT>
  : Itest_Array<TT>
{
  public IDictionary<testNumber, TT> AsT { get; set; }
  public test_Array _Array { get; set; }
}

public class test_IfElse<TT>
  : Itest_IfElse<TT>
{
  public IDictionary<testBoolean, TT> AsT { get; set; }
  public test_IfElse _IfElse { get; set; }
}

public class test_Set<TK>
  : Itest_Set<TK>
{
  public IDictionary<TK, testUnit> AsUnit { get; set; }
  public test_Set _Set { get; set; }
}

public class test_Mask<TK>
  : Itest_Mask<TK>
{
  public IDictionary<TK, testBoolean> As^ { get; set; }
  public test_Mask _Mask { get; set; }
}

public class test_Key
  : Itest_Key
{
}

public class test_Any
  : Itest_Any
{
  public test_Any _Any { get; set; }
}
