//HintName: test_constraint-alt+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Dual;

public class testCnstAltDual<TType>
  : GqlpEncoderBase
  , ItestCnstAltDual<TType>
{
  public TType? Astype { get; set; }
  public ItestCnstAltDualObject<TType>? As_CnstAltDual { get; set; }
}

public class testCnstAltDualObject<TType>
  : GqlpEncoderBase
  , ItestCnstAltDualObject<TType>
{

  public testCnstAltDualObject
    ()
  {
  }
}
