//HintName: test_constraint-parent-dual-grandparent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public class testCnstPrntDualGrndDual
  : testRefCnstPrntDualGrndDual<ItestAltCnstPrntDualGrndDual>
  , ItestCnstPrntDualGrndDual
{
  public ItestCnstPrntDualGrndDualObject? As_CnstPrntDualGrndDual { get; set; }
}

public class testCnstPrntDualGrndDualObject
  : testRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>
  , ItestCnstPrntDualGrndDualObject
{

  public testCnstPrntDualGrndDualObject
    ()
  {
  }
}

public class testRefCnstPrntDualGrndDual<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntDualGrndDual<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntDualGrndDualObject<TRef>? As_RefCnstPrntDualGrndDual { get; set; }
}

public class testRefCnstPrntDualGrndDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntDualGrndDualObject<TRef>
{

  public testRefCnstPrntDualGrndDualObject
    ()
  {
  }
}

public class testGrndCnstPrntDualGrndDual
  : GqlpEncoderBase
  , ItestGrndCnstPrntDualGrndDual
{
  public string? AsString { get; set; }
  public ItestGrndCnstPrntDualGrndDualObject? As_GrndCnstPrntDualGrndDual { get; set; }
}

public class testGrndCnstPrntDualGrndDualObject
  : GqlpEncoderBase
  , ItestGrndCnstPrntDualGrndDualObject
{

  public testGrndCnstPrntDualGrndDualObject
    ()
  {
  }
}

public class testPrntCnstPrntDualGrndDual
  : testGrndCnstPrntDualGrndDual
  , ItestPrntCnstPrntDualGrndDual
{
  public ItestPrntCnstPrntDualGrndDualObject? As_PrntCnstPrntDualGrndDual { get; set; }
}

public class testPrntCnstPrntDualGrndDualObject
  : testGrndCnstPrntDualGrndDualObject
  , ItestPrntCnstPrntDualGrndDualObject
{

  public testPrntCnstPrntDualGrndDualObject
    ()
  {
  }
}

public class testAltCnstPrntDualGrndDual
  : testPrntCnstPrntDualGrndDual
  , ItestAltCnstPrntDualGrndDual
{
  public ItestAltCnstPrntDualGrndDualObject? As_AltCnstPrntDualGrndDual { get; set; }
}

public class testAltCnstPrntDualGrndDualObject
  : testPrntCnstPrntDualGrndDualObject
  , ItestAltCnstPrntDualGrndDualObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntDualGrndDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
