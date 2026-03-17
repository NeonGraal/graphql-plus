//HintName: test_constraint-parent-obj-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
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
}

public class testRefCnstPrntObjPrntOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntObjPrntOutp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntObjPrntOutpObject<TRef>? As_RefCnstPrntObjPrntOutp { get; set; }
}

public class testRefCnstPrntObjPrntOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntObjPrntOutpObject<TRef>
{
}

public class testPrntCnstPrntObjPrntOutp
  : GqlpModelImplementationBase
  , ItestPrntCnstPrntObjPrntOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstPrntObjPrntOutpObject? As_PrntCnstPrntObjPrntOutp { get; set; }
}

public class testPrntCnstPrntObjPrntOutpObject
  : GqlpModelImplementationBase
  , ItestPrntCnstPrntObjPrntOutpObject
{
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
