//HintName: test_constraint-alt-obj+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public class testCnstAltObjInp
  : GqlpModelBase
  , ItestCnstAltObjInp
{
  public ItestRefCnstAltObjInp<ItestAltCnstAltObjInp>? AsRefCnstAltObjInp { get; set; }
  public ItestCnstAltObjInpObject? As_CnstAltObjInp { get; set; }
}

public class testCnstAltObjInpObject
  : GqlpModelBase
  , ItestCnstAltObjInpObject
{

  public testCnstAltObjInpObject
    ()
  {
  }
}

public class testRefCnstAltObjInp<TRef>
  : GqlpModelBase
  , ItestRefCnstAltObjInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltObjInpObject<TRef>? As_RefCnstAltObjInp { get; set; }
}

public class testRefCnstAltObjInpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstAltObjInpObject<TRef>
{

  public testRefCnstAltObjInpObject
    ()
  {
  }
}

public class testPrntCnstAltObjInp
  : GqlpModelBase
  , ItestPrntCnstAltObjInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltObjInpObject? As_PrntCnstAltObjInp { get; set; }
}

public class testPrntCnstAltObjInpObject
  : GqlpModelBase
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
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
