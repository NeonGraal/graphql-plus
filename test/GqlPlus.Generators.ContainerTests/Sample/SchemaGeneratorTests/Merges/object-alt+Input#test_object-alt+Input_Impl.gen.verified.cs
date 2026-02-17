//HintName: test_object-alt+Input_Impl.gen.cs
// Generated from {CurrentDirectory}object-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Input;

public class testObjAltInp
  : GqlpModelImplementationBase
  , ItestObjAltInp
{
  public ItestObjAltInpType? AsObjAltInpType { get; set; }
  public ItestObjAltInpObject? As_ObjAltInp { get; set; }
}

public class testObjAltInpObject
  : GqlpModelImplementationBase
  , ItestObjAltInpObject
{

  public testObjAltInpObject()
  {
  }
}

public class testObjAltInpType
  : GqlpModelImplementationBase
  , ItestObjAltInpType
{
  public ItestObjAltInpTypeObject? As_ObjAltInpType { get; set; }
}

public class testObjAltInpTypeObject
  : GqlpModelImplementationBase
  , ItestObjAltInpTypeObject
{

  public testObjAltInpTypeObject()
  {
  }
}
