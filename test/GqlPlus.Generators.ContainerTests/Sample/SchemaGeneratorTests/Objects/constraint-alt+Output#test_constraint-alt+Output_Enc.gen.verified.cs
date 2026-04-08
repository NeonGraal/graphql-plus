//HintName: test_constraint-alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Output;

public class testCnstAltOutp<TType>
  : GqlpEncoderBase
  , ItestCnstAltOutp<TType>
{
  public TType? Astype { get; set; }
  public ItestCnstAltOutpObject<TType>? As_CnstAltOutp { get; set; }
}

public class testCnstAltOutpObject<TType>
  : GqlpEncoderBase
  , ItestCnstAltOutpObject<TType>
{

  public testCnstAltOutpObject
    ()
  {
  }
}
