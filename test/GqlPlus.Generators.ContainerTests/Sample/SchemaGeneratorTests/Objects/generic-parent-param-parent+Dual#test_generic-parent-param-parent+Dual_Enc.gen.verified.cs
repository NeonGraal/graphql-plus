//HintName: test_generic-parent-param-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public class testGnrcPrntParamPrntDual
  : testRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
  , ItestGnrcPrntParamPrntDual
{
  public ItestGnrcPrntParamPrntDualObject? As_GnrcPrntParamPrntDual { get; set; }
}

public class testGnrcPrntParamPrntDualObject
  : testRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>
  , ItestGnrcPrntParamPrntDualObject
{

  public testGnrcPrntParamPrntDualObject
    ()
  {
  }
}

public class testRefGnrcPrntParamPrntDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntParamPrntDual<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntParamPrntDualObject<TRef>? As_RefGnrcPrntParamPrntDual { get; set; }
}

public class testRefGnrcPrntParamPrntDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntParamPrntDualObject<TRef>
{

  public testRefGnrcPrntParamPrntDualObject
    ()
  {
  }
}

public class testAltGnrcPrntParamPrntDual
  : GqlpEncoderBase
  , ItestAltGnrcPrntParamPrntDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamPrntDualObject? As_AltGnrcPrntParamPrntDual { get; set; }
}

public class testAltGnrcPrntParamPrntDualObject
  : GqlpEncoderBase
  , ItestAltGnrcPrntParamPrntDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamPrntDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
