//HintName: Model_Intro_Option.gen.cs
// Generated from Intro_Option.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_Intro_Option;

public interface I_Setting
  : I_Named
{
  _Constant value { get; }
}
public class Output_Setting
  : Output_Named
  , I_Setting
{
  public _Constant value { get; set; }
}
