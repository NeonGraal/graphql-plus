//HintName: test_Definition_Enc.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

public enum bool
{
  false,
  true,
}

public enum GqlpNull
{
  null,
}

public enum GqlpUnit
{
  _,
}

public enum void
{
}

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
  : GqlpEncoderBase
  , Itest_Basic
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
  public Unit AsUnit { get; set; }
}

public class test_Internal
  : GqlpEncoderBase
  , Itest_Internal
{
  public Null AsNull { get; set; }
  public Void AsVoid { get; set; }
}

public class test_Key
  : GqlpEncoderBase
  , Itest_Key
{
  public _Basic As_Basic { get; set; }
  public _Internal As_Internal { get; set; }
  public _Simple As_Simple { get; set; }
}

public class test_Object
  : GqlpEncoderBase
  , Itest_Object
{
  public Itest_ObjectObject? As__Object { get; set; }
}

public class test_ObjectObject
  : GqlpEncoderBase
  , Itest_ObjectObject
{

  public test_ObjectObject
    ()
  {
  }
}

public class test_Domain
  : GqlpEncoderBase
  , Itest_Domain
{
}

public class test_Dual
  : GqlpEncoderBase
  , Itest_Dual
{
  public Itest_DualObject? As__Dual { get; set; }
}

public class test_DualObject
  : GqlpEncoderBase
  , Itest_DualObject
{

  public test_DualObject
    ()
  {
  }
}

public class test_Enum
  : GqlpEncoderBase
  , Itest_Enum
{
}

public class test_Input
  : GqlpEncoderBase
  , Itest_Input
{
  public Itest_InputObject? As__Input { get; set; }
}

public class test_InputObject
  : GqlpEncoderBase
  , Itest_InputObject
{

  public test_InputObject
    ()
  {
  }
}

public class test_Output
  : GqlpEncoderBase
  , Itest_Output
{
  public Itest_OutputObject? As__Output { get; set; }
}

public class test_OutputObject
  : GqlpEncoderBase
  , Itest_OutputObject
{

  public test_OutputObject
    ()
  {
  }
}

public class test_Union
  : GqlpEncoderBase
  , Itest_Union
{
}

public class test_Simple
  : GqlpEncoderBase
  , Itest_Simple
{
  public _Enum As_Enum { get; set; }
  public _Domain As_Domain { get; set; }
  public _Union As_Union { get; set; }
}
