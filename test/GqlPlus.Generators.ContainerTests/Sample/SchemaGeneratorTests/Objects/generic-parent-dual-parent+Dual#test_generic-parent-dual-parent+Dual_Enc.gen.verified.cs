//HintName: test_generic-parent-dual-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public class testGnrcPrntDualPrntDual
  : testRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
  , ItestGnrcPrntDualPrntDual
{
  public ItestGnrcPrntDualPrntDualObject? As_GnrcPrntDualPrntDual { get; set; }
}

public class testGnrcPrntDualPrntDualObject
  : testRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>
  , ItestGnrcPrntDualPrntDualObject
{

  public testGnrcPrntDualPrntDualObject
    ()
  {
  }
}

public class testRefGnrcPrntDualPrntDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntDualPrntDual<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntDualPrntDualObject<TRef>? As_RefGnrcPrntDualPrntDual { get; set; }
}

public class testRefGnrcPrntDualPrntDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntDualPrntDualObject<TRef>
{

  public testRefGnrcPrntDualPrntDualObject
    ()
  {
  }
}

public class testAltGnrcPrntDualPrntDual
  : GqlpEncoderBase
  , ItestAltGnrcPrntDualPrntDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualPrntDualObject? As_AltGnrcPrntDualPrntDual { get; set; }
}

public class testAltGnrcPrntDualPrntDualObject
  : GqlpEncoderBase
  , ItestAltGnrcPrntDualPrntDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualPrntDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
