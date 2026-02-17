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
  TT? AsT { get; }
  testNull? AsNull { get; }
  Itest_OptObject<TT>? As__Opt { get; }
}

public interface Itest_OptObject<TT>
  : IGqlpModelImplementationBase
{
}

public interface Itest_List<TT>
  : IGqlpModelImplementationBase
{
  ICollection<TT>? AsT { get; }
  Itest_ListObject<TT>? As__List { get; }
}

public interface Itest_ListObject<TT>
  : IGqlpModelImplementationBase
{
}

public interface Itest_Dict<TK,TT>
  : IGqlpModelImplementationBase
{
  IDictionary<TK, TT>? AsT { get; }
  Itest_DictObject<TK,TT>? As__Dict { get; }
}

public interface Itest_DictObject<TK,TT>
  : IGqlpModelImplementationBase
{
}

public interface Itest_Map<TT>
  : IGqlpModelImplementationBase
{
  IDictionary<string, TT>? AsT { get; }
  Itest_MapObject<TT>? As__Map { get; }
}

public interface Itest_MapObject<TT>
  : IGqlpModelImplementationBase
{
}

public interface Itest_Array<TT>
  : IGqlpModelImplementationBase
{
  IDictionary<decimal, TT>? AsT { get; }
  Itest_ArrayObject<TT>? As__Array { get; }
}

public interface Itest_ArrayObject<TT>
  : IGqlpModelImplementationBase
{
}

public interface Itest_IfElse<TT>
  : IGqlpModelImplementationBase
{
  IDictionary<bool, TT>? AsT { get; }
  Itest_IfElseObject<TT>? As__IfElse { get; }
}

public interface Itest_IfElseObject<TT>
  : IGqlpModelImplementationBase
{
}

public interface Itest_Set<TK>
  : IGqlpModelImplementationBase
{
  IDictionary<TK, GqlpUnit>? AsUnit_ { get; }
  Itest_SetObject<TK>? As__Set { get; }
}

public interface Itest_SetObject<TK>
  : IGqlpModelImplementationBase
{
}

public interface Itest_Mask<TK>
  : IGqlpModelImplementationBase
{
  IDictionary<TK, bool>? AsBoolean { get; }
  Itest_MaskObject<TK>? As__Mask { get; }
}

public interface Itest_MaskObject<TK>
  : IGqlpModelImplementationBase
{
}

public interface Itest_Key
  : IGqlpModelImplementationBase
{
}

public interface Itest_Any
  : IGqlpModelImplementationBase
{
  Itest_AnyObject? As__Any { get; }
}

public interface Itest_AnyObject
  : IGqlpModelImplementationBase
{
}
