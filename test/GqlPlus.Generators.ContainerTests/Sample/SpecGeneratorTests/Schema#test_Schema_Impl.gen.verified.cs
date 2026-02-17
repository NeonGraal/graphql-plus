//HintName: test_Schema_Impl.gen.cs
// Generated from {CurrentDirectory}Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public class test_Opt<TT>
  : GqlpModelImplementationBase
  , Itest_Opt<TT>
{
  public TT? AsT { get; set; }
  public testNull? AsNull { get; set; }
  public Itest_OptObject<TT>? As__Opt { get; set; }
}

public class test_OptObject<TT>
  : GqlpModelImplementationBase
  , Itest_OptObject<TT>
{

  public test_OptObject()
  {
  }
}

public class test_List<TT>
  : GqlpModelImplementationBase
  , Itest_List<TT>
{
  public ICollection<TT>? AsT { get; set; }
  public Itest_ListObject<TT>? As__List { get; set; }
}

public class test_ListObject<TT>
  : GqlpModelImplementationBase
  , Itest_ListObject<TT>
{

  public test_ListObject()
  {
  }
}

public class test_Dict<TK,TT>
  : GqlpModelImplementationBase
  , Itest_Dict<TK,TT>
{
  public IDictionary<TK, TT>? AsT { get; set; }
  public Itest_DictObject<TK,TT>? As__Dict { get; set; }
}

public class test_DictObject<TK,TT>
  : GqlpModelImplementationBase
  , Itest_DictObject<TK,TT>
{

  public test_DictObject()
  {
  }
}

public class test_Map<TT>
  : GqlpModelImplementationBase
  , Itest_Map<TT>
{
  public IDictionary<string, TT>? AsT { get; set; }
  public Itest_MapObject<TT>? As__Map { get; set; }
}

public class test_MapObject<TT>
  : GqlpModelImplementationBase
  , Itest_MapObject<TT>
{

  public test_MapObject()
  {
  }
}

public class test_Array<TT>
  : GqlpModelImplementationBase
  , Itest_Array<TT>
{
  public IDictionary<decimal, TT>? AsT { get; set; }
  public Itest_ArrayObject<TT>? As__Array { get; set; }
}

public class test_ArrayObject<TT>
  : GqlpModelImplementationBase
  , Itest_ArrayObject<TT>
{

  public test_ArrayObject()
  {
  }
}

public class test_IfElse<TT>
  : GqlpModelImplementationBase
  , Itest_IfElse<TT>
{
  public IDictionary<bool, TT>? AsT { get; set; }
  public Itest_IfElseObject<TT>? As__IfElse { get; set; }
}

public class test_IfElseObject<TT>
  : GqlpModelImplementationBase
  , Itest_IfElseObject<TT>
{

  public test_IfElseObject()
  {
  }
}

public class test_Set<TK>
  : GqlpModelImplementationBase
  , Itest_Set<TK>
{
  public IDictionary<TK, GqlpUnit>? AsUnit_ { get; set; }
  public Itest_SetObject<TK>? As__Set { get; set; }
}

public class test_SetObject<TK>
  : GqlpModelImplementationBase
  , Itest_SetObject<TK>
{

  public test_SetObject()
  {
  }
}

public class test_Mask<TK>
  : GqlpModelImplementationBase
  , Itest_Mask<TK>
{
  public IDictionary<TK, bool>? AsBoolean { get; set; }
  public Itest_MaskObject<TK>? As__Mask { get; set; }
}

public class test_MaskObject<TK>
  : GqlpModelImplementationBase
  , Itest_MaskObject<TK>
{

  public test_MaskObject()
  {
  }
}

public class test_Key
  : GqlpModelImplementationBase
  , Itest_Key
{
}

public class test_Any
  : GqlpModelImplementationBase
  , Itest_Any
{
  public Itest_AnyObject? As__Any { get; set; }
}

public class test_AnyObject
  : GqlpModelImplementationBase
  , Itest_AnyObject
{

  public test_AnyObject()
  {
  }
}
