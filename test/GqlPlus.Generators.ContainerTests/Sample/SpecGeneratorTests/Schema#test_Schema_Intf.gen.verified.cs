//HintName: test_Schema_Intf.gen.cs
// Generated from Schema.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public interface Itest_Opt<TT>
{
  TT AsT { get; }
  testNull AsNull { get; }
  Itest_OptObject As_Opt { get; }
}

public interface Itest_OptObject<TT>
{
}

public interface Itest_List<TT>
{
  ICollection<TT> AsT { get; }
  Itest_ListObject As_List { get; }
}

public interface Itest_ListObject<TT>
{
}

public interface Itest_Dict<TK,TT>
{
  IDictionary<TK, TT> AsT { get; }
  Itest_DictObject As_Dict { get; }
}

public interface Itest_DictObject<TK,TT>
{
}

public interface Itest_Map<TT>
{
  IDictionary<string, TT> AsT { get; }
  Itest_MapObject As_Map { get; }
}

public interface Itest_MapObject<TT>
{
}

public interface Itest_Array<TT>
{
  IDictionary<decimal, TT> AsT { get; }
  Itest_ArrayObject As_Array { get; }
}

public interface Itest_ArrayObject<TT>
{
}

public interface Itest_IfElse<TT>
{
  IDictionary<bool, TT> AsT { get; }
  Itest_IfElseObject As_IfElse { get; }
}

public interface Itest_IfElseObject<TT>
{
}

public interface Itest_Set<TK>
{
  IDictionary<TK, testUnit> AsUnit_ { get; }
  Itest_SetObject As_Set { get; }
}

public interface Itest_SetObject<TK>
{
}

public interface Itest_Mask<TK>
{
  IDictionary<TK, bool> AsBoolean { get; }
  Itest_MaskObject As_Mask { get; }
}

public interface Itest_MaskObject<TK>
{
}

public interface Itest_Key
{
}

public interface Itest_Any
{
  Itest_AnyObject As_Any { get; }
}

public interface Itest_AnyObject
{
}
