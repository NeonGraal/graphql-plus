//HintName: test_Schema_Model.gen.cs
// Generated from {CurrentDirectory}Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public class test_Opt<TT>
  : GqlpModelBase
  , Itest_Opt<TT>
{
  public TT? AsT { get; set; }
  public GqlpNull? AsNull { get; set; }
  public Itest_OptObject<TT>? As__Opt { get; set; }
}

public class test_OptObject<TT>
  : GqlpModelBase
  , Itest_OptObject<TT>
{

  public test_OptObject
    ()
  {
  }
}

public class test_List<TT>
  : GqlpModelBase
  , Itest_List<TT>
{
  public ICollection<TT>? AsT { get; set; }
  public Itest_ListObject<TT>? As__List { get; set; }
}

public class test_ListObject<TT>
  : GqlpModelBase
  , Itest_ListObject<TT>
{

  public test_ListObject
    ()
  {
  }
}

public class test_Dict<TK,TT>
  : GqlpModelBase
  , Itest_Dict<TK,TT>
{
  public IDictionary<TK, TT>? AsT { get; set; }
  public Itest_DictObject<TK,TT>? As__Dict { get; set; }
}

public class test_DictObject<TK,TT>
  : GqlpModelBase
  , Itest_DictObject<TK,TT>
{

  public test_DictObject
    ()
  {
  }
}

public class test_Map<TT>
  : GqlpModelBase
  , Itest_Map<TT>
{
  public IDictionary<string, TT>? AsT { get; set; }
  public Itest_MapObject<TT>? As__Map { get; set; }
}

public class test_MapObject<TT>
  : GqlpModelBase
  , Itest_MapObject<TT>
{

  public test_MapObject
    ()
  {
  }
}

public class test_Array<TT>
  : GqlpModelBase
  , Itest_Array<TT>
{
  public IDictionary<decimal, TT>? AsT { get; set; }
  public Itest_ArrayObject<TT>? As__Array { get; set; }
}

public class test_ArrayObject<TT>
  : GqlpModelBase
  , Itest_ArrayObject<TT>
{

  public test_ArrayObject
    ()
  {
  }
}

public class test_IfElse<TT>
  : GqlpModelBase
  , Itest_IfElse<TT>
{
  public IDictionary<bool, TT>? AsT { get; set; }
  public Itest_IfElseObject<TT>? As__IfElse { get; set; }
}

public class test_IfElseObject<TT>
  : GqlpModelBase
  , Itest_IfElseObject<TT>
{

  public test_IfElseObject
    ()
  {
  }
}

public class test_Set<TK>
  : GqlpModelBase
  , Itest_Set<TK>
{
  public IDictionary<TK, GqlpUnit>? AsUnit { get; set; }
  public Itest_SetObject<TK>? As__Set { get; set; }
}

public class test_SetObject<TK>
  : GqlpModelBase
  , Itest_SetObject<TK>
{

  public test_SetObject
    ()
  {
  }
}

public class test_Mask<TK>
  : GqlpModelBase
  , Itest_Mask<TK>
{
  public IDictionary<TK, bool>? AsBoolean { get; set; }
  public Itest_MaskObject<TK>? As__Mask { get; set; }
}

public class test_MaskObject<TK>
  : GqlpModelBase
  , Itest_MaskObject<TK>
{

  public test_MaskObject
    ()
  {
  }
}

public class test_Key
  : GqlpModelBase
  , Itest_Key
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class test_Any
  : GqlpModelBase
  , Itest_Any
{
  public Itest_AnyObject? As__Any { get; set; }
}

public class test_AnyObject
  : GqlpModelBase
  , Itest_AnyObject
{

  public test_AnyObject
    ()
  {
  }
}
