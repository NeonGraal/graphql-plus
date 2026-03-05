//HintName: test_alt-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

public class testAltDualDual
  : GqlpModelImplementationBase
  , ItestAltDualDual
{
  public ItestObjDualAltDualDual? AsObjDualAltDualDual { get; set; }
  public ItestAltDualDualObject? As_AltDualDual { get; set; }
}

public class testAltDualDualObject
  : GqlpModelImplementationBase
  , ItestAltDualDualObject
{

  public testAltDualDualObject
    ()
  {
  }
}

public class testObjDualAltDualDual
  : GqlpModelImplementationBase
  , ItestObjDualAltDualDual
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualDualObject? As_ObjDualAltDualDual { get; set; }
}

public class testObjDualAltDualDualObject
  : GqlpModelImplementationBase
  , ItestObjDualAltDualDualObject
{
  public decimal Alt { get; set; }

  public testObjDualAltDualDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
