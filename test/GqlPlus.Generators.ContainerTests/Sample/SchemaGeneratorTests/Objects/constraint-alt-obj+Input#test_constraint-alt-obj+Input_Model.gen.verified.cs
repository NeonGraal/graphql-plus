//HintName: test_constraint-alt-obj+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public class testCnstAltObjInp
  : GqlpModelImplementationBase
  , ItestCnstAltObjInp
{
  public ItestRefCnstAltObjInp<ItestAltCnstAltObjInp>? AsRefCnstAltObjInp { get; set; }
  public ItestCnstAltObjInpObject? As_CnstAltObjInp { get; set; }
}

public class testCnstAltObjInpObject
  : GqlpModelImplementationBase
  , ItestCnstAltObjInpObject
{
}

public class testRefCnstAltObjInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltObjInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltObjInpObject<TRef>? As_RefCnstAltObjInp { get; set; }
}

public class testRefCnstAltObjInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltObjInpObject<TRef>
{
}

public class testPrntCnstAltObjInp
  : GqlpModelImplementationBase
  , ItestPrntCnstAltObjInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltObjInpObject? As_PrntCnstAltObjInp { get; set; }
}

public class testPrntCnstAltObjInpObject
  : GqlpModelImplementationBase
  , ItestPrntCnstAltObjInpObject
{
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
