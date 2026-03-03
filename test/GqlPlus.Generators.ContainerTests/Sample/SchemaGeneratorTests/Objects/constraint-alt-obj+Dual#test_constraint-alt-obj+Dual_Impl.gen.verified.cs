//HintName: test_constraint-alt-obj+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public class testCnstAltObjDual
  : GqlpModelImplementationBase
  , ItestCnstAltObjDual
{
  public ItestRefCnstAltObjDual<ItestAltCnstAltObjDual>? AsRefCnstAltObjDual { get; set; }
  public ItestCnstAltObjDualObject? As_CnstAltObjDual { get; set; }
}

public class testCnstAltObjDualObject
  : GqlpModelImplementationBase
  , ItestCnstAltObjDualObject
{

  public testCnstAltObjDualObject
    ()
  {
  }
}

public class testRefCnstAltObjDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltObjDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltObjDualObject<TRef>? As_RefCnstAltObjDual { get; set; }
}

public class testRefCnstAltObjDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltObjDualObject<TRef>
{

  public testRefCnstAltObjDualObject
    ()
  {
  }
}

public class testPrntCnstAltObjDual
  : GqlpModelImplementationBase
  , ItestPrntCnstAltObjDual
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltObjDualObject? As_PrntCnstAltObjDual { get; set; }
}

public class testPrntCnstAltObjDualObject
  : GqlpModelImplementationBase
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
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
