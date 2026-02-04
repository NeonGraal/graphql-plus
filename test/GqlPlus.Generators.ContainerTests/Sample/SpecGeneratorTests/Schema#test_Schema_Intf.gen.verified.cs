//HintName: test_Schema_Intf.gen.cs
// Generated from Schema.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public interface Itest_Opt<TT>
{
  public TT AsT { get; set; }
  public testNull AsNull { get; set; }
  public test_Opt _Opt { get; set; }
}

public interface Itest_OptObject<TT>
{
}

public interface Itest_List<TT>
{
  public ICollection<TT> AsT { get; set; }
  public test_List _List { get; set; }
}

public interface Itest_ListObject<TT>
{
}

public interface Itest_Dict<TK,TT>
{
  public IDictionary<TK, TT> AsT { get; set; }
  public test_Dict _Dict { get; set; }
}

public interface Itest_DictObject<TK,TT>
{
}

public interface Itest_Map<TT>
{
  public IDictionary<testString, TT> AsT { get; set; }
  public test_Map _Map { get; set; }
}

public interface Itest_MapObject<TT>
{
}

public interface Itest_Array<TT>
{
  public IDictionary<testNumber, TT> AsT { get; set; }
  public test_Array _Array { get; set; }
}

public interface Itest_ArrayObject<TT>
{
}

public interface Itest_IfElse<TT>
{
  public IDictionary<testBoolean, TT> AsT { get; set; }
  public test_IfElse _IfElse { get; set; }
}

public interface Itest_IfElseObject<TT>
{
}

public interface Itest_Set<TK>
{
  public IDictionary<TK, testUnit> AsUnit_ { get; set; }
  public test_Set _Set { get; set; }
}

public interface Itest_SetObject<TK>
{
}

public interface Itest_Mask<TK>
{
  public IDictionary<TK, testBoolean> As^ { get; set; }
  public test_Mask _Mask { get; set; }
}

public interface Itest_MaskObject<TK>
{
}

public interface Itest_Key
{
}

public interface Itest_Any
{
  public test_Any _Any { get; set; }
}

public interface Itest_AnyObject
{
}
