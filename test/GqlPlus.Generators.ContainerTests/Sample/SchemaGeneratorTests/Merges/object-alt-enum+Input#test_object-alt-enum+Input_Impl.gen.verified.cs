//HintName: test_object-alt-enum+Input_Impl.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Input;

public class testObjAltEnumInp
  : GqlpModelImplementationBase
  , ItestObjAltEnumInp
{
  public bool? AsBooleantrue { get; set; }
  public bool? AsBooleanfalse { get; set; }
  public ItestObjAltEnumInpObject? As_ObjAltEnumInp { get; set; }
}

public class testObjAltEnumInpObject
  : GqlpModelImplementationBase
  , ItestObjAltEnumInpObject
{

  public testObjAltEnumInpObject
    ()
  {
  }
}
