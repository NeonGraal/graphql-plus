//HintName: test_Schema_Impl.gen.cs
// Generated from Schema.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public class test_Opt<TT>
  : Itest_Opt<TT>
{
  public TT AsT { get; set; }
  public ItestNull AsNull { get; set; }
}

public class test_List<TT>
  : Itest_List<TT>
{
  public ICollection<TT> AsT { get; set; }
}

public class test_Dict<TK,TT>
  : Itest_Dict<TK,TT>
{
  public IDictionary<TK, TT> AsT { get; set; }
}

public class test_Map<TT>
  : Itest_Map<TT>
{
  public IDictionary<testString, TT> AsT { get; set; }
}

public class test_Array<TT>
  : Itest_Array<TT>
{
  public IDictionary<testNumber, TT> AsT { get; set; }
}

public class test_IfElse<TT>
  : Itest_IfElse<TT>
{
  public IDictionary<testBoolean, TT> AsT { get; set; }
}

public class test_Set<TK>
  : Itest_Set<TK>
{
  public IDictionary<TK, ItestUnit> AsUnit_ { get; set; }
}

public class test_Mask<TK>
  : Itest_Mask<TK>
{
  public IDictionary<TK, ItestBoolean> As^ { get; set; }
}

public class test_Key
  : Itest_Key
{
}

public class test_Any
  : Itest_Any
{
}
