//HintName: test_object-alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Output;

public class testObjAltOutp
  : GqlpEncoderBase
  , ItestObjAltOutp
{
  public ItestObjAltOutpType? AsObjAltOutpType { get; set; }
  public ItestObjAltOutpObject? As_ObjAltOutp { get; set; }
}

public class testObjAltOutpObject
  : GqlpEncoderBase
  , ItestObjAltOutpObject
{

  public testObjAltOutpObject
    ()
  {
  }
}

public class testObjAltOutpType
  : GqlpEncoderBase
  , ItestObjAltOutpType
{
  public ItestObjAltOutpTypeObject? As_ObjAltOutpType { get; set; }
}

public class testObjAltOutpTypeObject
  : GqlpEncoderBase
  , ItestObjAltOutpTypeObject
{

  public testObjAltOutpTypeObject
    ()
  {
  }
}
