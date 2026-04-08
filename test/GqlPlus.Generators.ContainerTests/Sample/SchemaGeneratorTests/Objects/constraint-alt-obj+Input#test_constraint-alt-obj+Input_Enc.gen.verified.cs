//HintName: test_constraint-alt-obj+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public class testCnstAltObjInp
  : GqlpEncoderBase
  , ItestCnstAltObjInp
{
  public ItestRefCnstAltObjInp<ItestAltCnstAltObjInp>? AsRefCnstAltObjInp { get; set; }
  public ItestCnstAltObjInpObject? As_CnstAltObjInp { get; set; }
}

public class testCnstAltObjInpObject
  : GqlpEncoderBase
  , ItestCnstAltObjInpObject
{

  public testCnstAltObjInpObject
    ()
  {
  }
}

public class testRefCnstAltObjInp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltObjInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltObjInpObject<TRef>? As_RefCnstAltObjInp { get; set; }
}

public class testRefCnstAltObjInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstAltObjInpObject<TRef>
{

  public testRefCnstAltObjInpObject
    ()
  {
  }
}

public class testPrntCnstAltObjInp
  : GqlpEncoderBase
  , ItestPrntCnstAltObjInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltObjInpObject? As_PrntCnstAltObjInp { get; set; }
}

public class testPrntCnstAltObjInpObject
  : GqlpEncoderBase
  , ItestPrntCnstAltObjInpObject
{

  public testPrntCnstAltObjInpObject
    ()
  {
  }
}

public class testAltCnstAltObjInp
  : testPrntCnstAltObjInp
  , ItestAltCnstAltObjInp
{
  public ItestAltCnstAltObjInpObject? As_AltCnstAltObjInp { get; set; }
}

public class testAltCnstAltObjInpObject
  : testPrntCnstAltObjInpObject
  , ItestAltCnstAltObjInpObject
{
  public decimal Alt { get; set; }

  public testAltCnstAltObjInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
