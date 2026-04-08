//HintName: test_constraint-parent-dual-grandparent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public class testCnstPrntDualGrndOutp
  : testRefCnstPrntDualGrndOutp<ItestAltCnstPrntDualGrndOutp>
  , ItestCnstPrntDualGrndOutp
{
  public ItestCnstPrntDualGrndOutpObject? As_CnstPrntDualGrndOutp { get; set; }
}

public class testCnstPrntDualGrndOutpObject
  : testRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>
  , ItestCnstPrntDualGrndOutpObject
{

  public testCnstPrntDualGrndOutpObject
    ()
  {
  }
}

public class testRefCnstPrntDualGrndOutp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntDualGrndOutp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntDualGrndOutpObject<TRef>? As_RefCnstPrntDualGrndOutp { get; set; }
}

public class testRefCnstPrntDualGrndOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntDualGrndOutpObject<TRef>
{

  public testRefCnstPrntDualGrndOutpObject
    ()
  {
  }
}

public class testGrndCnstPrntDualGrndOutp
  : GqlpEncoderBase
  , ItestGrndCnstPrntDualGrndOutp
{
  public string? AsString { get; set; }
  public ItestGrndCnstPrntDualGrndOutpObject? As_GrndCnstPrntDualGrndOutp { get; set; }
}

public class testGrndCnstPrntDualGrndOutpObject
  : GqlpEncoderBase
  , ItestGrndCnstPrntDualGrndOutpObject
{

  public testGrndCnstPrntDualGrndOutpObject
    ()
  {
  }
}

public class testPrntCnstPrntDualGrndOutp
  : testGrndCnstPrntDualGrndOutp
  , ItestPrntCnstPrntDualGrndOutp
{
  public ItestPrntCnstPrntDualGrndOutpObject? As_PrntCnstPrntDualGrndOutp { get; set; }
}

public class testPrntCnstPrntDualGrndOutpObject
  : testGrndCnstPrntDualGrndOutpObject
  , ItestPrntCnstPrntDualGrndOutpObject
{

  public testPrntCnstPrntDualGrndOutpObject
    ()
  {
  }
}

public class testAltCnstPrntDualGrndOutp
  : testPrntCnstPrntDualGrndOutp
  , ItestAltCnstPrntDualGrndOutp
{
  public ItestAltCnstPrntDualGrndOutpObject? As_AltCnstPrntDualGrndOutp { get; set; }
}

public class testAltCnstPrntDualGrndOutpObject
  : testPrntCnstPrntDualGrndOutpObject
  , ItestAltCnstPrntDualGrndOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntDualGrndOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
