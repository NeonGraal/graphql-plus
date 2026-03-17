//HintName: test_alt-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

public class testAltDualOutp
  : GqlpModelImplementationBase
  , ItestAltDualOutp
{
  public ItestObjDualAltDualOutp? AsObjDualAltDualOutp { get; set; }
  public ItestAltDualOutpObject? As_AltDualOutp { get; set; }
}

public class testAltDualOutpObject
  : GqlpModelImplementationBase
  , ItestAltDualOutpObject
{
}

public class testObjDualAltDualOutp
  : GqlpModelImplementationBase
  , ItestObjDualAltDualOutp
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualOutpObject? As_ObjDualAltDualOutp { get; set; }
}

public class testObjDualAltDualOutpObject
  : GqlpModelImplementationBase
  , ItestObjDualAltDualOutpObject
{
  public decimal Alt { get; set; }

  public testObjDualAltDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
