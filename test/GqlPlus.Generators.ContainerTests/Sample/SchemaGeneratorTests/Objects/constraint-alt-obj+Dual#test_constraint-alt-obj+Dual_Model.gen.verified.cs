//HintName: test_constraint-alt-obj+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public class testCnstAltObjDual
  : GqlpModelBase
  , ItestCnstAltObjDual
{
  public ItestRefCnstAltObjDual<ItestAltCnstAltObjDual>? AsRefCnstAltObjDual { get; set; }
  public ItestCnstAltObjDualObject? As_CnstAltObjDual { get; set; }
}

public class testCnstAltObjDualObject
  : GqlpModelBase
  , ItestCnstAltObjDualObject
{

  public testCnstAltObjDualObject
    ()
  {
  }
}

public class testRefCnstAltObjDual<TRef>
  : GqlpModelBase
  , ItestRefCnstAltObjDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltObjDualObject<TRef>? As_RefCnstAltObjDual { get; set; }
}

public class testRefCnstAltObjDualObject<TRef>
  : GqlpModelBase
  , ItestRefCnstAltObjDualObject<TRef>
{

  public testRefCnstAltObjDualObject
    ()
  {
  }
}

public class testPrntCnstAltObjDual
  : GqlpModelBase
  , ItestPrntCnstAltObjDual
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltObjDualObject? As_PrntCnstAltObjDual { get; set; }
}

public class testPrntCnstAltObjDualObject
  : GqlpModelBase
  , ItestPrntCnstAltObjDualObject
{

  public testPrntCnstAltObjDualObject
    ()
  {
  }
}

public class testAltCnstAltObjDual
  : testPrntCnstAltObjDual
  , ItestAltCnstAltObjDual
{
  public ItestAltCnstAltObjDualObject? As_AltCnstAltObjDual { get; set; }
}

public class testAltCnstAltObjDualObject
  : testPrntCnstAltObjDualObject
  , ItestAltCnstAltObjDualObject
{
  public decimal Alt { get; set; }

  public testAltCnstAltObjDualObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
