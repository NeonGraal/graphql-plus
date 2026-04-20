//HintName: test_constraint-alt-obj+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public class testCnstAltObjOutp
  : GqlpModelBase
  , ItestCnstAltObjOutp
{
  public ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp>? AsRefCnstAltObjOutp { get; set; }
  public ItestCnstAltObjOutpObject? As_CnstAltObjOutp { get; set; }
}

public class testCnstAltObjOutpObject
  : GqlpModelBase
  , ItestCnstAltObjOutpObject
{

  public testCnstAltObjOutpObject
    ()
  {
  }
}

public class testRefCnstAltObjOutp<TRef>
  : GqlpModelBase
  , ItestRefCnstAltObjOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltObjOutpObject<TRef>? As_RefCnstAltObjOutp { get; set; }
}

public class testRefCnstAltObjOutpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstAltObjOutpObject<TRef>
{

  public testRefCnstAltObjOutpObject
    ()
  {
  }
}

public class testPrntCnstAltObjOutp
  : GqlpModelBase
  , ItestPrntCnstAltObjOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltObjOutpObject? As_PrntCnstAltObjOutp { get; set; }
}

public class testPrntCnstAltObjOutpObject
  : GqlpModelBase
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
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
