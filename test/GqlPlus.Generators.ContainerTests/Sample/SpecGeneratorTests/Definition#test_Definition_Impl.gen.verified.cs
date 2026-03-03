//HintName: test_Definition_Impl.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  : GqlpModelImplementationBase
  , Itest_Basic
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
  public Unit AsUnit { get; set; }
}

public class test_Internal
  : GqlpModelImplementationBase
  , Itest_Internal
{
  public Null AsNull { get; set; }
  public Void AsVoid { get; set; }
}

public class test_Key
  : GqlpModelImplementationBase
  , Itest_Key
{
  public _Basic As_Basic { get; set; }
  public _Internal As_Internal { get; set; }
  public _Simple As_Simple { get; set; }
}

public class test_Object
  : GqlpModelImplementationBase
  , Itest_Object
{
  public Itest_ObjectObject? As__Object { get; set; }
}

public class test_ObjectObject
  : GqlpModelImplementationBase
  , Itest_ObjectObject
{

  public test_ObjectObject
    ()
  {
  }
}

public class test_Domain
  : GqlpModelImplementationBase
  , Itest_Domain
{
}

public class test_Dual
  : GqlpModelImplementationBase
  , Itest_Dual
{
  public Itest_DualObject? As__Dual { get; set; }
}

public class test_DualObject
  : GqlpModelImplementationBase
  , Itest_DualObject
{

  public test_DualObject
    ()
  {
  }
}

public class test_Enum
  : GqlpModelImplementationBase
  , Itest_Enum
{
}

public class test_Input
  : GqlpModelImplementationBase
  , Itest_Input
{
  public Itest_InputObject? As__Input { get; set; }
}

public class test_InputObject
  : GqlpModelImplementationBase
  , Itest_InputObject
{

  public test_InputObject
    ()
  {
  }
}

public class test_Output
  : GqlpModelImplementationBase
  , Itest_Output
{
  public Itest_OutputObject? As__Output { get; set; }
}

public class test_OutputObject
  : GqlpModelImplementationBase
  , Itest_OutputObject
{

  public test_OutputObject
    ()
  {
  }
}

public class test_Union
  : GqlpModelImplementationBase
  , Itest_Union
{
}

public class test_Simple
  : GqlpModelImplementationBase
  , Itest_Simple
{
  public _Enum As_Enum { get; set; }
  public _Domain As_Domain { get; set; }
  public _Union As_Union { get; set; }
}
