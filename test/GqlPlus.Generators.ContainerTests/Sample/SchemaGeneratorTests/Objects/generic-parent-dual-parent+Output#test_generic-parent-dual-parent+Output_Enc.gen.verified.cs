//HintName: test_generic-parent-dual-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public class testGnrcPrntDualPrntOutp
  : testRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
  , ItestGnrcPrntDualPrntOutp
{
  public ItestGnrcPrntDualPrntOutpObject? As_GnrcPrntDualPrntOutp { get; set; }
}

public class testGnrcPrntDualPrntOutpObject
  : testRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>
  , ItestGnrcPrntDualPrntOutpObject
{

  public testGnrcPrntDualPrntOutpObject
    ()
  {
  }
}

public class testRefGnrcPrntDualPrntOutp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntDualPrntOutp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntDualPrntOutpObject<TRef>? As_RefGnrcPrntDualPrntOutp { get; set; }
}

public class testRefGnrcPrntDualPrntOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntDualPrntOutpObject<TRef>
{

  public testRefGnrcPrntDualPrntOutpObject
    ()
  {
  }
}

public class testAltGnrcPrntDualPrntOutp
  : GqlpEncoderBase
  , ItestAltGnrcPrntDualPrntOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualPrntOutpObject? As_AltGnrcPrntDualPrntOutp { get; set; }
}

public class testAltGnrcPrntDualPrntOutpObject
  : GqlpEncoderBase
  , ItestAltGnrcPrntDualPrntOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualPrntOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
