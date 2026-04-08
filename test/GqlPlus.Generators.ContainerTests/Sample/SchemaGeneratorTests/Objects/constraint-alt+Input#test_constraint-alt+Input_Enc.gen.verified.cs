//HintName: test_constraint-alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Input;

public class testCnstAltInp<TType>
  : GqlpEncoderBase
  , ItestCnstAltInp<TType>
{
  public TType? Astype { get; set; }
  public ItestCnstAltInpObject<TType>? As_CnstAltInp { get; set; }
}

public class testCnstAltInpObject<TType>
  : GqlpEncoderBase
  , ItestCnstAltInpObject<TType>
{

  public testCnstAltInpObject
    ()
  {
  }
}
