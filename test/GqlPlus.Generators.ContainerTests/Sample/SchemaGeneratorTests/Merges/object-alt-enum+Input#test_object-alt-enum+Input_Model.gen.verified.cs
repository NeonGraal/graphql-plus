//HintName: test_object-alt-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Input;

public class testObjAltEnumInp
  : GqlpModelBase
  , ItestObjAltEnumInp
{
  public bool? AsBooleantrue { get; set; }
  public bool? AsBooleanfalse { get; set; }
  public ItestObjAltEnumInpObject? As_ObjAltEnumInp { get; set; }
}

public class testObjAltEnumInpObject
  : GqlpModelBase
  , ItestObjAltEnumInpObject
{

  public testObjAltEnumInpObject
    ()
  {
  }
}
