//HintName: test_constraint-alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public class testCnstAltDualOutp
  : GqlpEncoderBase
  , ItestCnstAltDualOutp
{
  public ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp>? AsRefCnstAltDualOutp { get; set; }
  public ItestCnstAltDualOutpObject? As_CnstAltDualOutp { get; set; }
}

public class testCnstAltDualOutpObject
  : GqlpEncoderBase
  , ItestCnstAltDualOutpObject
{

  public testCnstAltDualOutpObject
    ()
  {
  }
}

public class testRefCnstAltDualOutp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDualOutpObject<TRef>? As_RefCnstAltDualOutp { get; set; }
}

public class testRefCnstAltDualOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltDualOutpObject<TRef>
{

  public testRefCnstAltDualOutpObject
    ()
  {
  }
}

public class testPrntCnstAltDualOutp
  : GqlpEncoderBase
  , ItestPrntCnstAltDualOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltDualOutpObject? As_PrntCnstAltDualOutp { get; set; }
}

public class testPrntCnstAltDualOutpObject
  : GqlpEncoderBase
  , ItestPrntCnstAltDualOutpObject
{

  public testPrntCnstAltDualOutpObject
    ()
  {
  }
}

public class testAltCnstAltDualOutp
  : testPrntCnstAltDualOutp
  , ItestAltCnstAltDualOutp
{
  public ItestAltCnstAltDualOutpObject? As_AltCnstAltDualOutp { get; set; }
}

public class testAltCnstAltDualOutpObject
  : testPrntCnstAltDualOutpObject
  , ItestAltCnstAltDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstAltDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
