//HintName: test_Definition_Impl.gen.cs
// Generated from Definition.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

public class testNumber
  : DomainNumber
  , ItestNumber
{
}

public class testString
  : DomainString
  , ItestString
{
}

public class test_Basic
  : Itest_Basic
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
  public Unit AsUnit { get; set; }
}

public class test_Internal
  : Itest_Internal
{
  public Null AsNull { get; set; }
  public Void AsVoid { get; set; }
}

public class test_Key
  : Itest_Key
{
  public _Basic As_Basic { get; set; }
  public _Internal As_Internal { get; set; }
  public _Simple As_Simple { get; set; }
}

public class test_Object
  : Itest_Object
{
}

public class test_Domain
  : Itest_Domain
{
}

public class test_Dual
  : Itest_Dual
{
}

public class test_Enum
  : Itest_Enum
{
}

public class test_Input
  : Itest_Input
{
}

public class test_Output
  : Itest_Output
{
}

public class test_Union
  : Itest_Union
{
}

public class test_Simple
  : Itest_Simple
{
  public _Enum As_Enum { get; set; }
  public _Domain As_Domain { get; set; }
  public _Union As_Union { get; set; }
}
