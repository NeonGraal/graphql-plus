//HintName: test_object-constraint+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-constraint+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public class testObjCnstDual<TType>
  : GqlpEncoderBase
  , ItestObjCnstDual<TType>
{
  public ItestObjCnstDualObject<TType>? As_ObjCnstDual { get; set; }
}

public class testObjCnstDualObject<TType>
  : GqlpEncoderBase
  , ItestObjCnstDualObject<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }

  public testObjCnstDualObject
    ( TType field
    , TType str
    )
  {
    Field = field;
    Str = str;
  }
}
