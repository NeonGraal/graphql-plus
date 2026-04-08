//HintName: test_alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

public class testAltDualInp
  : GqlpEncoderBase
  , ItestAltDualInp
{
  public ItestObjDualAltDualInp? AsObjDualAltDualInp { get; set; }
  public ItestAltDualInpObject? As_AltDualInp { get; set; }
}

public class testAltDualInpObject
  : GqlpEncoderBase
  , ItestAltDualInpObject
{

  public testAltDualInpObject
    ()
  {
  }
}

public class testObjDualAltDualInp
  : GqlpEncoderBase
  , ItestObjDualAltDualInp
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualInpObject? As_ObjDualAltDualInp { get; set; }
}

public class testObjDualAltDualInpObject
  : GqlpEncoderBase
  , ItestObjDualAltDualInpObject
{
  public decimal Alt { get; set; }

  public testObjDualAltDualInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
