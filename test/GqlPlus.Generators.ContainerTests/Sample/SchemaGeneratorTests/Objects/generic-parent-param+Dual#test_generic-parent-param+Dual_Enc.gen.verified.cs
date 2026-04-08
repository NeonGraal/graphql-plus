//HintName: test_generic-parent-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public class testGnrcPrntParamDual
  : testRefGnrcPrntParamDual<ItestAltGnrcPrntParamDual>
  , ItestGnrcPrntParamDual
{
  public ItestGnrcPrntParamDualObject? As_GnrcPrntParamDual { get; set; }
}

public class testGnrcPrntParamDualObject
  : testRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>
  , ItestGnrcPrntParamDualObject
{

  public testGnrcPrntParamDualObject
    ()
  {
  }
}

public class testRefGnrcPrntParamDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntParamDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntParamDualObject<TRef>? As_RefGnrcPrntParamDual { get; set; }
}

public class testRefGnrcPrntParamDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntParamDualObject<TRef>
{

  public testRefGnrcPrntParamDualObject
    ()
  {
  }
}

public class testAltGnrcPrntParamDual
  : GqlpEncoderBase
  , ItestAltGnrcPrntParamDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamDualObject? As_AltGnrcPrntParamDual { get; set; }
}

public class testAltGnrcPrntParamDualObject
  : GqlpEncoderBase
  , ItestAltGnrcPrntParamDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
