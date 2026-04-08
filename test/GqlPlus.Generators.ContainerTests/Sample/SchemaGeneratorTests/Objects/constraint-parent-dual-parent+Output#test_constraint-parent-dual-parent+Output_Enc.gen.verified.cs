//HintName: test_constraint-parent-dual-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public class testCnstPrntDualPrntOutp
  : testRefCnstPrntDualPrntOutp<ItestAltCnstPrntDualPrntOutp>
  , ItestCnstPrntDualPrntOutp
{
  public ItestCnstPrntDualPrntOutpObject? As_CnstPrntDualPrntOutp { get; set; }
}

public class testCnstPrntDualPrntOutpObject
  : testRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>
  , ItestCnstPrntDualPrntOutpObject
{

  public testCnstPrntDualPrntOutpObject
    ()
  {
  }
}

public class testRefCnstPrntDualPrntOutp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntDualPrntOutp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntDualPrntOutpObject<TRef>? As_RefCnstPrntDualPrntOutp { get; set; }
}

public class testRefCnstPrntDualPrntOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntDualPrntOutpObject<TRef>
{

  public testRefCnstPrntDualPrntOutpObject
    ()
  {
  }
}

public class testPrntCnstPrntDualPrntOutp
  : GqlpEncoderBase
  , ItestPrntCnstPrntDualPrntOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstPrntDualPrntOutpObject? As_PrntCnstPrntDualPrntOutp { get; set; }
}

public class testPrntCnstPrntDualPrntOutpObject
  : GqlpEncoderBase
  , ItestPrntCnstPrntDualPrntOutpObject
{

  public testPrntCnstPrntDualPrntOutpObject
    ()
  {
  }
}

public class testAltCnstPrntDualPrntOutp
  : testPrntCnstPrntDualPrntOutp
  , ItestAltCnstPrntDualPrntOutp
{
  public ItestAltCnstPrntDualPrntOutpObject? As_AltCnstPrntDualPrntOutp { get; set; }
}

public class testAltCnstPrntDualPrntOutpObject
  : testPrntCnstPrntDualPrntOutpObject
  , ItestAltCnstPrntDualPrntOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntDualPrntOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
