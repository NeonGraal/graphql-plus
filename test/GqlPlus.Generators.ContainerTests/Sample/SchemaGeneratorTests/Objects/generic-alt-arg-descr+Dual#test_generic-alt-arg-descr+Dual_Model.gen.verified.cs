//HintName: test_generic-alt-arg-descr+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public class testGnrcAltArgDescrDual<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgDescrDual<TType>
{
  public ItestRefGnrcAltArgDescrDual<TType>? AsRefGnrcAltArgDescrDual { get; set; }
  public ItestGnrcAltArgDescrDualObject<TType>? As_GnrcAltArgDescrDual { get; set; }
}

public class testGnrcAltArgDescrDualObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgDescrDualObject<TType>
{
}

public class testRefGnrcAltArgDescrDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgDescrDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDescrDualObject<TRef>? As_RefGnrcAltArgDescrDual { get; set; }
}

public class testRefGnrcAltArgDescrDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgDescrDualObject<TRef>
{
}
