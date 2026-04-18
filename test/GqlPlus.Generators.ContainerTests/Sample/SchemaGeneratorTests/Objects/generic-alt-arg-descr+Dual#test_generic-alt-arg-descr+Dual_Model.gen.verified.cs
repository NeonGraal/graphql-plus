//HintName: test_generic-alt-arg-descr+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public class testGnrcAltArgDescrDual<TType>
  : GqlpModelBase
  , ItestGnrcAltArgDescrDual<TType>
{
  public ItestRefGnrcAltArgDescrDual<TType>? AsRefGnrcAltArgDescrDual { get; set; }
  public ItestGnrcAltArgDescrDualObject<TType>? As_GnrcAltArgDescrDual { get; set; }
}

public class testGnrcAltArgDescrDualObject<TType>
  : GqlpModelBase
  , ItestGnrcAltArgDescrDualObject<TType>
{

  public testGnrcAltArgDescrDualObject
    ()
  {
  }
}

public class testRefGnrcAltArgDescrDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgDescrDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDescrDualObject<TRef>? As_RefGnrcAltArgDescrDual { get; set; }
}

public class testRefGnrcAltArgDescrDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgDescrDualObject<TRef>
{

  public testRefGnrcAltArgDescrDualObject
    ()
  {
  }
}
