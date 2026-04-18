//HintName: test_Definition_Model.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

public class decimal
  : GqlpDomainNumber
  , decimal
{
}

public class string
  : GqlpDomainString
  , string
{
}

public class test_Basic
  : GqlpModelBase
  , Itest_Basic
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class test_Internal
  : GqlpModelBase
  , Itest_Internal
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class test_Key
  : GqlpModelBase
  , Itest_Key
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class test_Object
  : GqlpModelBase
  , Itest_Object
{
  public Itest_ObjectObject? As__Object { get; set; }
}

public class test_ObjectObject
  : GqlpModelBase
  , Itest_ObjectObject
{

  public test_ObjectObject
    ()
  {
  }
}

public class test_Domain
  : GqlpModelBase
  , Itest_Domain
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class test_Dual
  : GqlpModelBase
  , Itest_Dual
{
  public Itest_DualObject? As__Dual { get; set; }
}

public class test_DualObject
  : GqlpModelBase
  , Itest_DualObject
{

  public test_DualObject
    ()
  {
  }
}

public class test_Enum
  : GqlpModelBase
  , Itest_Enum
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class test_Input
  : GqlpModelBase
  , Itest_Input
{
  public Itest_InputObject? As__Input { get; set; }
}

public class test_InputObject
  : GqlpModelBase
  , Itest_InputObject
{

  public test_InputObject
    ()
  {
  }
}

public class test_Output
  : GqlpModelBase
  , Itest_Output
{
  public Itest_OutputObject? As__Output { get; set; }
}

public class test_OutputObject
  : GqlpModelBase
  , Itest_OutputObject
{

  public test_OutputObject
    ()
  {
  }
}

public class test_Union
  : GqlpModelBase
  , Itest_Union
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class test_Simple
  : GqlpModelBase
  , Itest_Simple
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
