//HintName: test_Definition_Impl.gen.cs
// Generated from Definition.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Definition;

public class DomaintestNumber
  : ItestNumber
{
}

public class DomaintestString
  : ItestString
{
}

public class Uniontest_Basic
  : Itest_Basic
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
  public Unit AsUnit { get; set; }
}

public class Uniontest_Internal
  : Itest_Internal
{
  public Null AsNull { get; set; }
  public Void AsVoid { get; set; }
}

public class Uniontest_Key
  : Itest_Key
{
  public _Basic As_Basic { get; set; }
  public _Internal As_Internal { get; set; }
  public _Simple As_Simple { get; set; }
}

public class Dualtest_Object
  : Itest_Object
{
}

public class Uniontest_Domain
  : Itest_Domain
{
}

public class Dualtest_Dual
  : Itest_Dual
{
}

public class Uniontest_Enum
  : Itest_Enum
{
}

public class Inputtest_Input
  : Itest_Input
{
}

public class Outputtest_Output
  : Itest_Output
{
}

public class Uniontest_Union
  : Itest_Union
{
}

public class Uniontest_Simple
  : Itest_Simple
{
  public _Enum As_Enum { get; set; }
  public _Domain As_Domain { get; set; }
  public _Union As_Union { get; set; }
}
