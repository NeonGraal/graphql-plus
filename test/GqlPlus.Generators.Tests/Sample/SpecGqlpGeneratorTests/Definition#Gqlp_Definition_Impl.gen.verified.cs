//HintName: Gqlp_Definition_Impl.gen.cs
// Generated from Definition.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Definition;

public class DomainNumber
  : INumber
{
}

public class DomainString
  : IString
{
}

public class Union_Basic
  : I_Basic
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
  public Unit AsUnit { get; set; }
}

public class Union_Internal
  : I_Internal
{
  public Null AsNull { get; set; }
  public Void AsVoid { get; set; }
}

public class Union_Key
  : I_Key
{
  public _Basic As_Basic { get; set; }
  public _Internal As_Internal { get; set; }
  public _Simple As_Simple { get; set; }
}

public class Dual_Object
  : I_Object
{
}

public class Union_Domain
  : I_Domain
{
}

public class Dual_Dual
  : I_Dual
{
}

public class Union_Enum
  : I_Enum
{
}

public class Input_Input
  : I_Input
{
}

public class Output_Output
  : I_Output
{
}

public class Union_Union
  : I_Union
{
}

public class Union_Simple
  : I_Simple
{
  public _Enum As_Enum { get; set; }
  public _Domain As_Domain { get; set; }
  public _Union As_Union { get; set; }
}
