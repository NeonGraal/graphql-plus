//HintName: test_generic-alt-simple+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public class testGnrcAltSmplDual
  : GqlpEncoderBase
  , ItestGnrcAltSmplDual
{
  public ItestRefGnrcAltSmplDual<string>? AsRefGnrcAltSmplDual { get; set; }
  public ItestGnrcAltSmplDualObject? As_GnrcAltSmplDual { get; set; }
}

public class testGnrcAltSmplDualObject
  : GqlpEncoderBase
  , ItestGnrcAltSmplDualObject
{

  public testGnrcAltSmplDualObject
    ()
  {
  }
}

public class testRefGnrcAltSmplDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltSmplDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplDualObject<TRef>? As_RefGnrcAltSmplDual { get; set; }
}

public class testRefGnrcAltSmplDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltSmplDualObject<TRef>
{

  public testRefGnrcAltSmplDualObject
    ()
  {
  }
}
