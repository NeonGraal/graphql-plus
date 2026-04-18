//HintName: test_alt-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

public class testAltDualOutp
  : GqlpModelBase
  , ItestAltDualOutp
{
  public ItestObjDualAltDualOutp? AsObjDualAltDualOutp { get; set; }
  public ItestAltDualOutpObject? As_AltDualOutp { get; set; }
}

public class testAltDualOutpObject
  : GqlpModelBase
  , ItestAltDualOutpObject
{

  public testAltDualOutpObject
    ()
  {
  }
}

public class testObjDualAltDualOutp
  : GqlpModelBase
  , ItestObjDualAltDualOutp
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualOutpObject? As_ObjDualAltDualOutp { get; set; }
}

public class testObjDualAltDualOutpObject
  : GqlpModelBase
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
