//HintName: test_alt-dual+Input_Impl.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

public class testAltDualInp
  : GqlpModelImplementationBase
  , ItestAltDualInp
{
  public ItestObjDualAltDualInp? AsObjDualAltDualInp { get; set; }
  public ItestAltDualInpObject? As_AltDualInp { get; set; }
}

public class testAltDualInpObject
  : GqlpModelImplementationBase
  , ItestAltDualInpObject
{

  public testAltDualInpObject()
  {
  }
}

public class testObjDualAltDualInp
  : GqlpModelImplementationBase
  , ItestObjDualAltDualInp
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualInpObject? As_ObjDualAltDualInp { get; set; }
}

public class testObjDualAltDualInpObject
  : GqlpModelImplementationBase
  , ItestObjDualAltDualInpObject
{
  public decimal Alt { get; set; }

  public testObjDualAltDualInpObject(decimal alt)
  {
    Alt = alt;
  }
}
