//HintName: test_alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

public class testAltDualDual
  : GqlpEncoderBase
  , ItestAltDualDual
{
  public ItestObjDualAltDualDual? AsObjDualAltDualDual { get; set; }
  public ItestAltDualDualObject? As_AltDualDual { get; set; }
}

public class testAltDualDualObject
  : GqlpEncoderBase
  , ItestAltDualDualObject
{

  public testAltDualDualObject
    ()
  {
  }
}

public class testObjDualAltDualDual
  : GqlpEncoderBase
  , ItestObjDualAltDualDual
{
  public string? AsString { get; set; }
  public ItestObjDualAltDualDualObject? As_ObjDualAltDualDual { get; set; }
}

public class testObjDualAltDualDualObject
  : GqlpEncoderBase
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
