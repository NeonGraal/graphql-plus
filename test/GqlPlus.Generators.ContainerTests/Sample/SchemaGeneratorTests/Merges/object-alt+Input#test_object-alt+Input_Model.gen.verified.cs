//HintName: test_object-alt+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Input;

public class testObjAltInp
  : GqlpModelBase
  , ItestObjAltInp
{
  public ItestObjAltInpType? AsObjAltInpType { get; set; }
  public ItestObjAltInpObject? As_ObjAltInp { get; set; }
}

public class testObjAltInpObject
  : GqlpModelBase
  , ItestObjAltInpObject
{

  public testObjAltInpObject
    ()
  {
  }
}

public class testObjAltInpType
  : GqlpModelBase
  , ItestObjAltInpType
{
  public ItestObjAltInpTypeObject? As_ObjAltInpType { get; set; }
}

public class testObjAltInpTypeObject
  : GqlpModelBase
  , ItestObjAltInpTypeObject
{

  public testObjAltInpTypeObject
    ()
  {
  }
}
