//HintName: test_constraint-alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public class testCnstAltDualDual
  : GqlpEncoderBase
  , ItestCnstAltDualDual
{
  public ItestRefCnstAltDualDual<ItestAltCnstAltDualDual>? AsRefCnstAltDualDual { get; set; }
  public ItestCnstAltDualDualObject? As_CnstAltDualDual { get; set; }
}

public class testCnstAltDualDualObject
  : GqlpEncoderBase
  , ItestCnstAltDualDualObject
{

  public testCnstAltDualDualObject
    ()
  {
  }
}

public class testRefCnstAltDualDual<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltDualDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDualDualObject<TRef>? As_RefCnstAltDualDual { get; set; }
}

public class testRefCnstAltDualDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltDualDualObject<TRef>
{

  public testRefCnstAltDualDualObject
    ()
  {
  }
}

public class testPrntCnstAltDualDual
  : GqlpEncoderBase
  , ItestPrntCnstAltDualDual
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltDualDualObject? As_PrntCnstAltDualDual { get; set; }
}

public class testPrntCnstAltDualDualObject
  : GqlpEncoderBase
  , ItestPrntCnstAltDualDualObject
{

  public testPrntCnstAltDualDualObject
    ()
  {
  }
}

public class testAltCnstAltDualDual
  : testPrntCnstAltDualDual
  , ItestAltCnstAltDualDual
{
  public ItestAltCnstAltDualDualObject? As_AltCnstAltDualDual { get; set; }
}

public class testAltCnstAltDualDualObject
  : testPrntCnstAltDualDualObject
  , ItestAltCnstAltDualDualObject
{
  public decimal Alt { get; set; }

  public testAltCnstAltDualDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
