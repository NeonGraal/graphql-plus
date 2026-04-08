//HintName: test_alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

public class testAltDualOutp
  : GqlpEncoderBase
  , ItestAltDualOutp
{
  public ItestObjDualAltDualOutp? AsObjDualAltDualOutp { get; set; }
  public ItestAltDualOutpObject? As_AltDualOutp { get; set; }
}

public class testAltDualOutpObject
  : GqlpEncoderBase
  , ItestAltDualOutpObject
{

  public testAltDualOutpObject
    ()
  {
  }
}

public class testObjDualAltDualOutp
  : GqlpEncoderBase
  , ItestObjDualAltDualOutp
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualOutpObject? As_ObjDualAltDualOutp { get; set; }
}

public class testObjDualAltDualOutpObject
  : GqlpEncoderBase
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
