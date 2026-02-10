//HintName: test_Schema_Intf.gen.cs
// Generated from Schema.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public interface Itest_Opt<TT>
{
  public TT AsT { get; set; }
  public testNull AsNull { get; set; }
  public Itest_OptObject As_Opt { get; set; }
}

public interface Itest_OptObject<TT>
{
}

public interface Itest_List<TT>
{
  public ICollection<TT> AsT { get; set; }
  public Itest_ListObject As_List { get; set; }
}

public interface Itest_ListObject<TT>
{
}

public interface Itest_Dict<TK,TT>
{
  public IDictionary<TK, TT> AsT { get; set; }
  public Itest_DictObject As_Dict { get; set; }
}

public interface Itest_DictObject<TK,TT>
{
}

public interface Itest_Map<TT>
{
  public IDictionary<testString, TT> AsT { get; set; }
  public Itest_MapObject As_Map { get; set; }
}

public interface Itest_MapObject<TT>
{
}

public interface Itest_Array<TT>
{
  public IDictionary<testNumber, TT> AsT { get; set; }
  public Itest_ArrayObject As_Array { get; set; }
}

public interface Itest_ArrayObject<TT>
{
}

public interface Itest_IfElse<TT>
{
  public IDictionary<testBoolean, TT> AsT { get; set; }
  public Itest_IfElseObject As_IfElse { get; set; }
}

public interface Itest_IfElseObject<TT>
{
}

public interface Itest_Set<TK>
{
  public IDictionary<TK, testUnit> AsUnit_ { get; set; }
  public Itest_SetObject As_Set { get; set; }
}

public interface Itest_SetObject<TK>
{
}

public interface Itest_Mask<TK>
{
  public IDictionary<TK, testBoolean> AsBoolean { get; set; }
  public Itest_MaskObject As_Mask { get; set; }
}

public interface Itest_MaskObject<TK>
{
}

public interface Itest_Key
{
}

public interface Itest_Any
{
  public Itest_AnyObject As_Any { get; set; }
}

public interface Itest_AnyObject
{
}
