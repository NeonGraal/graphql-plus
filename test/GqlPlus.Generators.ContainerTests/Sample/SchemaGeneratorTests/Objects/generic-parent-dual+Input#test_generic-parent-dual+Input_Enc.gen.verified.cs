//HintName: test_generic-parent-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public class testGnrcPrntDualInp
  : testRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
  , ItestGnrcPrntDualInp
{
  public ItestGnrcPrntDualInpObject? As_GnrcPrntDualInp { get; set; }
}

public class testGnrcPrntDualInpObject
  : testRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>
  , ItestGnrcPrntDualInpObject
{

  public testGnrcPrntDualInpObject
    ()
  {
  }
}

public class testRefGnrcPrntDualInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntDualInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntDualInpObject<TRef>? As_RefGnrcPrntDualInp { get; set; }
}

public class testRefGnrcPrntDualInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntDualInpObject<TRef>
{

  public testRefGnrcPrntDualInpObject
    ()
  {
  }
}

public class testAltGnrcPrntDualInp
  : GqlpEncoderBase
  , ItestAltGnrcPrntDualInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualInpObject? As_AltGnrcPrntDualInp { get; set; }
}

public class testAltGnrcPrntDualInpObject
  : GqlpEncoderBase
  , ItestAltGnrcPrntDualInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
