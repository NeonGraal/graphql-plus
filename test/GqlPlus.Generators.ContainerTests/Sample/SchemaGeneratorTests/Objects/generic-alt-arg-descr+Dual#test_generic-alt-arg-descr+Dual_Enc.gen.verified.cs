//HintName: test_generic-alt-arg-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public class testGnrcAltArgDescrDual<TType>
  : GqlpEncoderBase
  , ItestGnrcAltArgDescrDual<TType>
{
  public ItestRefGnrcAltArgDescrDual<TType>? AsRefGnrcAltArgDescrDual { get; set; }
  public ItestGnrcAltArgDescrDualObject<TType>? As_GnrcAltArgDescrDual { get; set; }
}

public class testGnrcAltArgDescrDualObject<TType>
  : GqlpEncoderBase
  , ItestGnrcAltArgDescrDualObject<TType>
{

  public testGnrcAltArgDescrDualObject
    ()
  {
  }
}

public class testRefGnrcAltArgDescrDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltArgDescrDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDescrDualObject<TRef>? As_RefGnrcAltArgDescrDual { get; set; }
}

public class testRefGnrcAltArgDescrDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltArgDescrDualObject<TRef>
{

  public testRefGnrcAltArgDescrDualObject
    ()
  {
  }
}
