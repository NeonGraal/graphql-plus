//HintName: test_alt-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

public class testAltDualDual
  : GqlpModelBase
  , ItestAltDualDual
{
  public ItestObjDualAltDualDual? AsObjDualAltDualDual { get; set; }
  public ItestAltDualDualObject? As_AltDualDual { get; set; }
}

public class testAltDualDualObject
  : GqlpModelBase
  , ItestAltDualDualObject
{

  public testAltDualDualObject
    ()
  {
  }
}

public class testObjDualAltDualDual
  : GqlpModelBase
  , ItestObjDualAltDualDual
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualDualObject? As_ObjDualAltDualDual { get; set; }
}

public class testObjDualAltDualDualObject
  : GqlpModelBase
  , ItestObjDualAltDualDualObject
{
  public decimal Alt { get; set; }

  public testObjDualAltDualDualObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
