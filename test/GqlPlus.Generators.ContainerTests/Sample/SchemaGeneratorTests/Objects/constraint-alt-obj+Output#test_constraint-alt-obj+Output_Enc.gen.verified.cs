//HintName: test_constraint-alt-obj+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public class testCnstAltObjOutp
  : GqlpEncoderBase
  , ItestCnstAltObjOutp
{
  public ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp>? AsRefCnstAltObjOutp { get; set; }
  public ItestCnstAltObjOutpObject? As_CnstAltObjOutp { get; set; }
}

public class testCnstAltObjOutpObject
  : GqlpEncoderBase
  , ItestCnstAltObjOutpObject
{

  public testCnstAltObjOutpObject
    ()
  {
  }
}

public class testRefCnstAltObjOutp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltObjOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltObjOutpObject<TRef>? As_RefCnstAltObjOutp { get; set; }
}

public class testRefCnstAltObjOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltObjOutpObject<TRef>
{

  public testRefCnstAltObjOutpObject
    ()
  {
  }
}

public class testPrntCnstAltObjOutp
  : GqlpEncoderBase
  , ItestPrntCnstAltObjOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltObjOutpObject? As_PrntCnstAltObjOutp { get; set; }
}

public class testPrntCnstAltObjOutpObject
  : GqlpEncoderBase
  , ItestPrntCnstAltObjOutpObject
{

  public testPrntCnstAltObjOutpObject
    ()
  {
  }
}

public class testAltCnstAltObjOutp
  : testPrntCnstAltObjOutp
  , ItestAltCnstAltObjOutp
{
  public ItestAltCnstAltObjOutpObject? As_AltCnstAltObjOutp { get; set; }
}

public class testAltCnstAltObjOutpObject
  : testPrntCnstAltObjOutpObject
  , ItestAltCnstAltObjOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstAltObjOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
