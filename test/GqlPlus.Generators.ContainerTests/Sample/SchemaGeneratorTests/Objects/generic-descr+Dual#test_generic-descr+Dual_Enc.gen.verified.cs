//HintName: test_generic-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Dual;

public class testGnrcDescrDual<TType>
  : GqlpEncoderBase
  , ItestGnrcDescrDual<TType>
{
  public ItestGnrcDescrDualObject<TType>? As_GnrcDescrDual { get; set; }
}

public class testGnrcDescrDualObject<TType>
  : GqlpEncoderBase
  , ItestGnrcDescrDualObject<TType>
{
  public TType Field { get; set; }

  public testGnrcDescrDualObject
    ( TType field
    )
  {
    Field = field;
  }
}
