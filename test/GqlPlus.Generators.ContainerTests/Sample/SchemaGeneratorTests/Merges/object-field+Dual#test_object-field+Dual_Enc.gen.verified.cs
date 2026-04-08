//HintName: test_object-field+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

public class testObjFieldDual
  : GqlpEncoderBase
  , ItestObjFieldDual
{
  public ItestObjFieldDualObject? As_ObjFieldDual { get; set; }
}

public class testObjFieldDualObject
  : GqlpEncoderBase
  , ItestObjFieldDualObject
{
  public ItestFldObjFieldDual Field { get; set; }

  public testObjFieldDualObject
    ( ItestFldObjFieldDual field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldDual
  : GqlpEncoderBase
  , ItestFldObjFieldDual
{
  public ItestFldObjFieldDualObject? As_FldObjFieldDual { get; set; }
}

public class testFldObjFieldDualObject
  : GqlpEncoderBase
  , ItestFldObjFieldDualObject
{

  public testFldObjFieldDualObject
    ()
  {
  }
}
