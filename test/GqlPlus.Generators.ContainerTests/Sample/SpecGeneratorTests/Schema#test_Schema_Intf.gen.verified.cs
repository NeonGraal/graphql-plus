//HintName: test_Schema_Intf.gen.cs
// Generated from Schema.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public interface Itest_Opt<TT>
{
  public TT AsT { get; set; }
  public ItestNull AsNull { get; set; }
}

public interface Itest_OptObject<TT>
{
}

public interface Itest_List<TT>
{
  public ICollection<TT> AsT { get; set; }
}

public interface Itest_ListObject<TT>
{
}

public interface Itest_Dict<TK,TT>
{
  public IDictionary<TK, TT> AsT { get; set; }
}

public interface Itest_DictObject<TK,TT>
{
}

public interface Itest_Map<TT>
{
  public IDictionary<testString, TT> AsT { get; set; }
}

public interface Itest_MapObject<TT>
{
}

public interface Itest_Array<TT>
{
  public IDictionary<testNumber, TT> AsT { get; set; }
}

public interface Itest_ArrayObject<TT>
{
}

public interface Itest_IfElse<TT>
{
  public IDictionary<testBoolean, TT> AsT { get; set; }
}

public interface Itest_IfElseObject<TT>
{
}

public interface Itest_Set<TK>
{
  public IDictionary<TK, ItestUnit> AsUnit_ { get; set; }
}

public interface Itest_SetObject<TK>
{
}

public interface Itest_Mask<TK>
{
  public IDictionary<TK, ItestBoolean> As^ { get; set; }
}

public interface Itest_MaskObject<TK>
{
}

public interface Itest_Key
{
}

public interface Itest_Any
{
}

public interface Itest_AnyObject
{
}
