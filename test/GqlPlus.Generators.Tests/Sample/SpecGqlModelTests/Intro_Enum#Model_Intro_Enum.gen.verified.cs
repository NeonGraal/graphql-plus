//HintName: Model_Intro_Enum.gen.cs
// Generated from Intro_Enum.graphql+

/*
*/

namespace GqlTest.Model_Intro_Enum;

public interface I_TypeEnum
{
}
public class Output_TypeEnum
{
}

public interface I_EnumLabel
{
  _Identifier enum { get; }
}
public class Dual_EnumLabel
{
  public _Identifier enum { get; set; }
}

public interface I_EnumValue
{
  _Identifier label { get; }
}
public class Output_EnumValue
{
  public _Identifier label { get; set; }
}
