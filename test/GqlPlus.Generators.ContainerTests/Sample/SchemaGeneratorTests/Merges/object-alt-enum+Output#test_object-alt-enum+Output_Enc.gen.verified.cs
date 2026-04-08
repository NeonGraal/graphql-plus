//HintName: test_object-alt-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Output;

public class testObjAltEnumOutp
  : GqlpEncoderBase
  , ItestObjAltEnumOutp
{
  public bool? AsBooleantrue { get; set; }
  public bool? AsBooleanfalse { get; set; }
  public ItestObjAltEnumOutpObject? As_ObjAltEnumOutp { get; set; }
}

public class testObjAltEnumOutpObject
  : GqlpEncoderBase
  , ItestObjAltEnumOutpObject
{

  public testObjAltEnumOutpObject
    ()
  {
  }
}
