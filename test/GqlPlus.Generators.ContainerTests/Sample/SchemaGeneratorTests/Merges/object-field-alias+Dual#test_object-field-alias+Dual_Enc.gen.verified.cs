//HintName: test_object-field-alias+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

public class testObjFieldAliasDual
  : GqlpEncoderBase
  , ItestObjFieldAliasDual
{
  public ItestObjFieldAliasDualObject? As_ObjFieldAliasDual { get; set; }
}

public class testObjFieldAliasDualObject
  : GqlpEncoderBase
  , ItestObjFieldAliasDualObject
{
  public ItestFldObjFieldAliasDual Field { get; set; }

  public testObjFieldAliasDualObject
    ( ItestFldObjFieldAliasDual field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldAliasDual
  : GqlpEncoderBase
  , ItestFldObjFieldAliasDual
{
  public ItestFldObjFieldAliasDualObject? As_FldObjFieldAliasDual { get; set; }
}

public class testFldObjFieldAliasDualObject
  : GqlpEncoderBase
  , ItestFldObjFieldAliasDualObject
{

  public testFldObjFieldAliasDualObject
    ()
  {
  }
}
