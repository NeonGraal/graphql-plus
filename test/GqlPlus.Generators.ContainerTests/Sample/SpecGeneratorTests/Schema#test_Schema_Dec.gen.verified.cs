//HintName: test_Schema_Dec.gen.cs
// Generated from {CurrentDirectory}Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public interface Itest_Opt<TT>
  // No Base because it's Class
{
  TT? AsT { get; }
  GqlpNull? AsNull { get; }
  Itest_OptObject<TT>? As__Opt { get; }
}

public interface Itest_OptObject<TT>
  // No Base because it's Class
{
}

public interface Itest_List<TT>
  // No Base because it's Class
{
  ICollection<TT>? AsT { get; }
  Itest_ListObject<TT>? As__List { get; }
}

public interface Itest_ListObject<TT>
  // No Base because it's Class
{
}

public interface Itest_Dict<TK,TT>
  // No Base because it's Class
{
  IDictionary<TK, TT>? AsT { get; }
  Itest_DictObject<TK,TT>? As__Dict { get; }
}

public interface Itest_DictObject<TK,TT>
  // No Base because it's Class
{
}

public interface Itest_Map<TT>
  // No Base because it's Class
{
  IDictionary<string, TT>? AsT { get; }
  Itest_MapObject<TT>? As__Map { get; }
}

public interface Itest_MapObject<TT>
  // No Base because it's Class
{
}

public interface Itest_Array<TT>
  // No Base because it's Class
{
  IDictionary<decimal, TT>? AsT { get; }
  Itest_ArrayObject<TT>? As__Array { get; }
}

public interface Itest_ArrayObject<TT>
  // No Base because it's Class
{
}

public interface Itest_IfElse<TT>
  // No Base because it's Class
{
  IDictionary<bool, TT>? AsT { get; }
  Itest_IfElseObject<TT>? As__IfElse { get; }
}

public interface Itest_IfElseObject<TT>
  // No Base because it's Class
{
}

public interface Itest_Set<TK>
  // No Base because it's Class
{
  IDictionary<TK, GqlpUnit>? AsUnit { get; }
  Itest_SetObject<TK>? As__Set { get; }
}

public interface Itest_SetObject<TK>
  // No Base because it's Class
{
}

public interface Itest_Mask<TK>
  // No Base because it's Class
{
  IDictionary<TK, bool>? AsBoolean { get; }
  Itest_MaskObject<TK>? As__Mask { get; }
}

public interface Itest_MaskObject<TK>
  // No Base because it's Class
{
}

public interface Itest_Key
  // No Base because it's Class
{
}

public interface Itest_Any
  // No Base because it's Class
{
  Itest_AnyObject? As__Any { get; }
}

public interface Itest_AnyObject
  // No Base because it's Class
{
}
