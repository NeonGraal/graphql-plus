//HintName: test_generic-alt+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Dual;

public class testGnrcAltDual<TType>
  : GqlpEncoderBase
  , ItestGnrcAltDual<TType>
{
  public TType? Astype { get; set; }
  public ItestGnrcAltDualObject<TType>? As_GnrcAltDual { get; set; }
}

public class testGnrcAltDualObject<TType>
  : GqlpEncoderBase
  , ItestGnrcAltDualObject<TType>
{

  public testGnrcAltDualObject
    ()
  {
  }
}
