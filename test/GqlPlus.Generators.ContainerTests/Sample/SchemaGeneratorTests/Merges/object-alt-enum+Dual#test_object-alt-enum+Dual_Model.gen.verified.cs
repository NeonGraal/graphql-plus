//HintName: test_object-alt-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Dual;

public class testObjAltEnumDual
  : GqlpModelImplementationBase
  , ItestObjAltEnumDual
{
  public bool? AsBooleantrue { get; set; }
  public bool? AsBooleanfalse { get; set; }
  public ItestObjAltEnumDualObject? As_ObjAltEnumDual { get; set; }
}

public class testObjAltEnumDualObject
  : GqlpModelImplementationBase
  , ItestObjAltEnumDualObject
{

  public testObjAltEnumDualObject
    ()
  {
  }
}
