//HintName: test_constraint-parent-obj-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public class testCnstPrntObjPrntInp
  : testRefCnstPrntObjPrntInp<ItestAltCnstPrntObjPrntInp>
  , ItestCnstPrntObjPrntInp
{
  public ItestCnstPrntObjPrntInpObject? As_CnstPrntObjPrntInp { get; set; }
}

public class testCnstPrntObjPrntInpObject
  : testRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>
  , ItestCnstPrntObjPrntInpObject
{

  public testCnstPrntObjPrntInpObject
    ()
  {
  }
}

public class testRefCnstPrntObjPrntInp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntObjPrntInp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntObjPrntInpObject<TRef>? As_RefCnstPrntObjPrntInp { get; set; }
}

public class testRefCnstPrntObjPrntInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntObjPrntInpObject<TRef>
{

  public testRefCnstPrntObjPrntInpObject
    ()
  {
  }
}

public class testPrntCnstPrntObjPrntInp
  : GqlpEncoderBase
  , ItestPrntCnstPrntObjPrntInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstPrntObjPrntInpObject? As_PrntCnstPrntObjPrntInp { get; set; }
}

public class testPrntCnstPrntObjPrntInpObject
  : GqlpEncoderBase
  , ItestPrntCnstPrntObjPrntInpObject
{

  public testPrntCnstPrntObjPrntInpObject
    ()
  {
  }
}

public class testAltCnstPrntObjPrntInp
  : testPrntCnstPrntObjPrntInp
  , ItestAltCnstPrntObjPrntInp
{
  public ItestAltCnstPrntObjPrntInpObject? As_AltCnstPrntObjPrntInp { get; set; }
}

public class testAltCnstPrntObjPrntInpObject
  : testPrntCnstPrntObjPrntInpObject
  , ItestAltCnstPrntObjPrntInpObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntObjPrntInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
