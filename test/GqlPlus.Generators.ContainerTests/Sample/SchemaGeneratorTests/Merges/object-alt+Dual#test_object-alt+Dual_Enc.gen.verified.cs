//HintName: test_object-alt+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Dual;

public class testObjAltDual
  : GqlpEncoderBase
  , ItestObjAltDual
{
  public ItestObjAltDualType? AsObjAltDualType { get; set; }
  public ItestObjAltDualObject? As_ObjAltDual { get; set; }
}

public class testObjAltDualObject
  : GqlpEncoderBase
  , ItestObjAltDualObject
{

  public testObjAltDualObject
    ()
  {
  }
}

public class testObjAltDualType
  : GqlpEncoderBase
  , ItestObjAltDualType
{
  public ItestObjAltDualTypeObject? As_ObjAltDualType { get; set; }
}

public class testObjAltDualTypeObject
  : GqlpEncoderBase
  , ItestObjAltDualTypeObject
{

  public testObjAltDualTypeObject
    ()
  {
  }
}
