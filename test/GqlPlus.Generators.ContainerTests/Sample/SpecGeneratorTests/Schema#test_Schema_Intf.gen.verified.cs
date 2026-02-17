//HintName: test_Schema_Intf.gen.cs
// Generated from {CurrentDirectory}Schema.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public interface Itest_Opt<TT>
  : IGqlpModelImplementationBase
{
  TT AsT { get; }
  testNull AsNull { get; }
  Itest_OptObject<TT> As_Opt { get; }
}

public interface Itest_OptObject<TT>
{
}

public interface Itest_List<TT>
  : IGqlpModelImplementationBase
{
  ICollection<TT> AsT { get; }
  Itest_ListObject<TT> As_List { get; }
}

public interface Itest_ListObject<TT>
{
}

public interface Itest_Dict<TK,TT>
  : IGqlpModelImplementationBase
{
  IDictionary<TK, TT> AsT { get; }
  Itest_DictObject<TK,TT> As_Dict { get; }
}

public interface Itest_DictObject<TK,TT>
{
}

public interface Itest_Map<TT>
  : IGqlpModelImplementationBase
{
  IDictionary<string, TT> AsT { get; }
  Itest_MapObject<TT> As_Map { get; }
}

public interface Itest_MapObject<TT>
{
}

public interface Itest_Array<TT>
  : IGqlpModelImplementationBase
{
  IDictionary<decimal, TT> AsT { get; }
  Itest_ArrayObject<TT> As_Array { get; }
}

public interface Itest_ArrayObject<TT>
{
}

public interface Itest_IfElse<TT>
  : IGqlpModelImplementationBase
{
  IDictionary<bool, TT> AsT { get; }
  Itest_IfElseObject<TT> As_IfElse { get; }
}

public interface Itest_IfElseObject<TT>
{
}

public interface Itest_Set<TK>
  : IGqlpModelImplementationBase
{
  IDictionary<TK, GqlpUnit> AsUnit_ { get; }
  Itest_SetObject<TK> As_Set { get; }
}

public interface Itest_SetObject<TK>
{
}

public interface Itest_Mask<TK>
  : IGqlpModelImplementationBase
{
  IDictionary<TK, bool> AsBoolean { get; }
  Itest_MaskObject<TK> As_Mask { get; }
}

public interface Itest_MaskObject<TK>
{
}

public interface Itest_Key
  : IGqlpModelImplementationBase
{
}

public interface Itest_Any
  : IGqlpModelImplementationBase
{
  Itest_AnyObject As_Any { get; }
}

public interface Itest_AnyObject
{
}
