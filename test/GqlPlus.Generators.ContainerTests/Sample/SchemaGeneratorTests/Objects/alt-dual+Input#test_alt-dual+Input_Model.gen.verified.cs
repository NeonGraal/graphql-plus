//HintName: test_alt-dual+Input_Model.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

public class testAltDualInp
  : GqlpModelBase
  , ItestAltDualInp
{
  public ItestObjDualAltDualInp? AsObjDualAltDualInp { get; set; }
  public ItestAltDualInpObject? As_AltDualInp { get; set; }
}

public class testAltDualInpObject
  : GqlpModelBase
  , ItestAltDualInpObject
{

  public testAltDualInpObject
    ()
  {
  }
}

public class testObjDualAltDualInp
  : GqlpModelBase
  , ItestObjDualAltDualInp
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualInpObject? As_ObjDualAltDualInp { get; set; }
}

public class testObjDualAltDualInpObject
  : GqlpModelBase
  , ItestObjDualAltDualInpObject
{
  public decimal Alt { get; set; }

  public testObjDualAltDualInpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
