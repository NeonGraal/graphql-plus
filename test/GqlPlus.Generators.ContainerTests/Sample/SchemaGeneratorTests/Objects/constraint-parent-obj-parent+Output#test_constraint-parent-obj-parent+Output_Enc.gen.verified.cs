//HintName: test_constraint-parent-obj-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public class testCnstPrntObjPrntOutp
  : testRefCnstPrntObjPrntOutp<ItestAltCnstPrntObjPrntOutp>
  , ItestCnstPrntObjPrntOutp
{
  public ItestCnstPrntObjPrntOutpObject? As_CnstPrntObjPrntOutp { get; set; }
}

public class testCnstPrntObjPrntOutpObject
  : testRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>
  , ItestCnstPrntObjPrntOutpObject
{

  public testCnstPrntObjPrntOutpObject
    ()
  {
  }
}

public class testRefCnstPrntObjPrntOutp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntObjPrntOutp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntObjPrntOutpObject<TRef>? As_RefCnstPrntObjPrntOutp { get; set; }
}

public class testRefCnstPrntObjPrntOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstPrntObjPrntOutpObject<TRef>
{

  public testRefCnstPrntObjPrntOutpObject
    ()
  {
  }
}

public class testPrntCnstPrntObjPrntOutp
  : GqlpEncoderBase
  , ItestPrntCnstPrntObjPrntOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstPrntObjPrntOutpObject? As_PrntCnstPrntObjPrntOutp { get; set; }
}

public class testPrntCnstPrntObjPrntOutpObject
  : GqlpEncoderBase
  , ItestPrntCnstPrntObjPrntOutpObject
{

  public testPrntCnstPrntObjPrntOutpObject
    ()
  {
  }
}

public class testAltCnstPrntObjPrntOutp
  : testPrntCnstPrntObjPrntOutp
  , ItestAltCnstPrntObjPrntOutp
{
  public ItestAltCnstPrntObjPrntOutpObject? As_AltCnstPrntObjPrntOutp { get; set; }
}

public class testAltCnstPrntObjPrntOutpObject
  : testPrntCnstPrntObjPrntOutpObject
  , ItestAltCnstPrntObjPrntOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntObjPrntOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
