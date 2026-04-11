//HintName: test_Schema_Intf.gen.cs
// Generated from {CurrentDirectory}Schema.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public interface Itest_Opt<TT>
  : IGqlpInterfaceBase
{
  TT? AsT { get; }
  GqlpNull? AsNull { get; }
  Itest_OptObject<TT>? As__Opt { get; }
}

public interface Itest_OptObject<TT>
  : IGqlpInterfaceBase
{
}

public interface Itest_List<TT>
  : IGqlpInterfaceBase
{
  ICollection<TT>? AsT { get; }
  Itest_ListObject<TT>? As__List { get; }
}

public interface Itest_ListObject<TT>
  : IGqlpInterfaceBase
{
}

public interface Itest_Dict<TK,TT>
  : IGqlpInterfaceBase
{
  IDictionary<TK, TT>? AsT { get; }
  Itest_DictObject<TK,TT>? As__Dict { get; }
}

public interface Itest_DictObject<TK,TT>
  : IGqlpInterfaceBase
{
}

public interface Itest_Map<TT>
  : IGqlpInterfaceBase
{
  IDictionary<string, TT>? AsT { get; }
  Itest_MapObject<TT>? As__Map { get; }
}

public interface Itest_MapObject<TT>
  : IGqlpInterfaceBase
{
}

public interface Itest_Array<TT>
  : IGqlpInterfaceBase
{
  IDictionary<decimal, TT>? AsT { get; }
  Itest_ArrayObject<TT>? As__Array { get; }
}

public interface Itest_ArrayObject<TT>
  : IGqlpInterfaceBase
{
}

public interface Itest_IfElse<TT>
  : IGqlpInterfaceBase
{
  IDictionary<bool, TT>? AsT { get; }
  Itest_IfElseObject<TT>? As__IfElse { get; }
}

public interface Itest_IfElseObject<TT>
  : IGqlpInterfaceBase
{
}

public interface Itest_Set<TK>
  : IGqlpInterfaceBase
{
  IDictionary<TK, GqlpUnit>? AsUnit { get; }
  Itest_SetObject<TK>? As__Set { get; }
}

public interface Itest_SetObject<TK>
  : IGqlpInterfaceBase
{
}

public interface Itest_Mask<TK>
  : IGqlpInterfaceBase
{
  IDictionary<TK, bool>? AsBoolean { get; }
  Itest_MaskObject<TK>? As__Mask { get; }
}

public interface Itest_MaskObject<TK>
  : IGqlpInterfaceBase
{
}

public interface Itest_Key
  : IGqlpInterfaceBase
{
}

public interface Itest_Any
  : IGqlpInterfaceBase
{
  Itest_AnyObject? As__Any { get; }
}

public interface Itest_AnyObject
  : IGqlpInterfaceBase
{
}
