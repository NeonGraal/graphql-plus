//HintName: test_object-alt-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Dual;

public class testObjAltEnumDual
  : GqlpModelBase
  , ItestObjAltEnumDual
{
  public bool? AsBooleantrue { get; set; }
  public bool? AsBooleanfalse { get; set; }
  public ItestObjAltEnumDualObject? As_ObjAltEnumDual { get; set; }
}

public class testObjAltEnumDualObject
  : GqlpModelBase
  , ItestObjAltEnumDualObject
{

  public testObjAltEnumDualObject
    ()
  {
  }
}
