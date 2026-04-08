//HintName: test_generic-parent-dual-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public class testGnrcPrntDualPrntInp
  : testRefGnrcPrntDualPrntInp<ItestAltGnrcPrntDualPrntInp>
  , ItestGnrcPrntDualPrntInp
{
  public ItestGnrcPrntDualPrntInpObject? As_GnrcPrntDualPrntInp { get; set; }
}

public class testGnrcPrntDualPrntInpObject
  : testRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>
  , ItestGnrcPrntDualPrntInpObject
{

  public testGnrcPrntDualPrntInpObject
    ()
  {
  }
}

public class testRefGnrcPrntDualPrntInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntDualPrntInp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntDualPrntInpObject<TRef>? As_RefGnrcPrntDualPrntInp { get; set; }
}

public class testRefGnrcPrntDualPrntInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntDualPrntInpObject<TRef>
{

  public testRefGnrcPrntDualPrntInpObject
    ()
  {
  }
}

public class testAltGnrcPrntDualPrntInp
  : GqlpEncoderBase
  , ItestAltGnrcPrntDualPrntInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualPrntInpObject? As_AltGnrcPrntDualPrntInp { get; set; }
}

public class testAltGnrcPrntDualPrntInpObject
  : GqlpEncoderBase
  , ItestAltGnrcPrntDualPrntInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualPrntInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
